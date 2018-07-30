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
        public InteractionButton pressedButton;
        public GameObject[] buttons; //fixed array of button indecies
        public InteractionButton[] intButtons;
        List<MaterialChange> objects = new List<MaterialChange>();
        List<int> pattern = new List<int>(); //pattern 
        List<InteractionButton> pressedButtons = new List<InteractionButton>();


        // Use this for initialization
        void Start()
        {


            roundNum = 0;
            isPlaying = true;
            buttonIsPressed = false;
            buttons = GameObject.FindGameObjectsWithTag("Button");
            intButtons = new InteractionButton[9];
            for (int i = 0; i < intButtons.Length; i++)
            {
                intButtons[i] = buttons[i].GetComponent<InteractionButton>();
            }
            for (int i = 0; i < buttons.Length; i++) //adding array of material change objects
            {
                objects.Add(buttons[i].GetComponent<MaterialChange>());
            }

            pattern.Add(Random.Range(0, 7));
            //playGame();

            //TESTING FUNCTIONS
            for (int i = 0; i < 7; i++)
            {
                UpdatePattern();
            }

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
            
            for (int i = 0; i < pattern.Count; i++)
            {
                Debug.Log("Entering Loop: "+i);
                yield return new WaitUntil(() => buttonIsPressed == true); //waits until user presses button
                 Debug.Log("Entering comparison");
                if (pressedButtons[i] == intButtons[pattern[i]])
                {                 
                    Debug.Log("Correct button press");
                    buttonIsPressed = false; //waits until user presses button
                }
                else
                {
                    Debug.Log("Wrong button pressed");
                    break;
                }
            }
            
            
        }

        void playGame()
        {
            /*while (isPlaying == true)
            {
                PlayPattern();
                StartCoroutine(UsersTurn());
                UpdatePattern();
            }*/

        }

        // Update is called once per frame / and here too :C
        void Update()
        {
            
            if (isPlaying == false)
            {
                Debug.Log("Score: " + roundNum);
                Application.Quit();
            }
        }

        public void addPressed(InteractionButton obj) //used in interactionbutton under collision method
        {
            this.pressedButtons.Add(obj);
            buttonIsPressed = true;
        }


    }

}
