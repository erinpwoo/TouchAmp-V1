using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Leap.Unity.Interaction
{
    public class GameController : MonoBehaviour
    {

        //BUTTON INDICES:
        //Green = 0; Blue = 1; Yellow = 2; Light blue = 3; Pink = 4; Purple = 5; Red = 6; Grey = 7; Orange = 8

        int roundNum;
        bool isPlaying;
        public bool buttonIsPressed;
        public GameObject pressedButton;
        public GameObject[] buttons; //fixed array of button indecies
        List<MaterialChange> objects = new List<MaterialChange>();
        List<int> pattern = new List<int>(); //pattern 

        //private UnityAction listener;

        //private void OnEnable()
        //{
        //    EventManager.StartListening("ReturnPressed", listener);
        //}

        //private void OnDisable()
        //{
        //    EventManager.StopListening("ReturnPressed", listener);    
        //}

        //private void Awake()
        //{
        //    listener = new UnityAction(ReturnPressed);
        //}


        // Use this for initialization
        void Start()
        {

            roundNum = 0;
            isPlaying = true;
            buttonIsPressed = false;
            buttons = GameObject.FindGameObjectsWithTag("Button");

            for (int i = 0; i < buttons.Length; i++) //adding array of material change objects
            {
                objects.Add(buttons[i].GetComponent<MaterialChange>());
            }

            pattern.Add(Random.Range(0, 7));
            //playGame();

            //TESTING FUNCTIONS
            UpdatePattern();
            UpdatePattern();
            StartCoroutine(PlayPattern());
            StartCoroutine(UsersTurn());

            Debug.Log("roundNum: " + roundNum);
        }


        void UpdatePattern() //increments pattern list, adds new index to call upon -- works 
        {
            pattern.Add(Random.Range(0, 7));
            roundNum++;
        }

        //PlayPattern() works
        IEnumerator PlayPattern() //randomly generates and executes pattern 
        {
            for (int i = 0; i < pattern.Count; i++)
            {
                StartCoroutine(buttons[pattern[i]].GetComponent<MaterialChange>().CueLightUp()); //selects Interaction button, applies LightUp()
                Debug.Log("Playing pattern: " + buttons[pattern[i]]);
                yield return new WaitForSeconds(2);
            }
        }

        //figure dis shiz out HERE!!!!!!!!!!!!!!
        IEnumerator UsersTurn()
        {

            yield return new WaitUntil(() => buttonIsPressed == true); //waits until user presses button

            for (int i = 0; i < roundNum; i++)
            {
                if (pressedButton == buttons[pattern[i]])
                {
                    buttonIsPressed = false;
                    yield return new WaitUntil(() => buttonIsPressed = true);
                }
                else
                {
                    isPlaying = false;
                }
            }
            
        }

        void playGame()
        {
            while (isPlaying == true)
            {
                PlayPattern();
                StartCoroutine(UsersTurn());
                UpdatePattern();
            }

        }

        // Update is called once per frame / and here too :C
        void Update()
        {
            foreach (MaterialChange mat in objects)
            {
                if (mat.isPressed == true)
                {
                    buttonIsPressed = true;
                    pressedButton = mat.GetComponent<GameObject>();
                }
            }

            if (isPlaying == false)
            {
                Debug.Log("Score: " + roundNum);
                Application.Quit();
            }
        }

    }
}
