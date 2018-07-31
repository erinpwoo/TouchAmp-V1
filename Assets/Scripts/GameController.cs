using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Leap.Unity.Interaction
{
    public class GameController : MonoBehaviour
    {

        int roundNum;
        bool isPlaying;
        public bool buttonIsPressed;
        public InteractionButton pressedButton;
        public GameObject[] buttons; //fixed array of button indecies
        public InteractionButton[] intButtons;
        List<MaterialChange> objects = new List<MaterialChange>();
        List<int> pattern = new List<int>(); //pattern 
        Stack<InteractionButton> pressedButtons = new Stack<InteractionButton>();


        private void Awake()
        {
            roundNum = 0;
            isPlaying = true;
            buttonIsPressed = false;
            buttons = GameObject.FindGameObjectsWithTag("Button");
            intButtons = new InteractionButton[9];
        }

        // Use this for initialization
        void Start()
        {


           
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
            for (int i = 0; i < 3; i++)
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
            yield return new WaitForSeconds(10);
            for (int i = 0; i < pattern.Count; i++)
            {
                StartCoroutine(buttons[pattern[i]].GetComponent<MaterialChange>().CueLightUp()); //selects Interaction button, applies LightUp()
                Debug.Log("Playing pattern: " + buttons[pattern[i]]);
                yield return new WaitForSeconds(2);
            }
        }

        //Stack implementation of user input comparison to pattern
        IEnumerator UsersTurn()
        {
            
            for (int i = 0; i < pattern.Count; i++) //total buttons that must be pressed to pass round
            {
                yield return new WaitUntil(() => buttonIsPressed == true); //waits until user presses button
                if (pressedButtons.Count != 0) //ensures stack isn't empty
                {
                    Debug.Log("button in stack: " + pressedButtons.Peek() + "     button to be pressed " + intButtons[pattern[i]]);
                    if (pressedButtons.Peek() == intButtons[pattern[i]]) //checks top of stack and compares to button that should be pressed
                    { 
                        Debug.Log("Correct Button pressed");
                        yield return new WaitUntil(() => buttonIsPressed = false); //waits until user stops pressing button.
                        pressedButtons.Pop(); //pops and waits for new button press
                    }
                    else
                    {
                        Debug.Log("Wrong Button pressed. Display score: " + roundNum);
                        Application.Quit();
                    }
                }
                else
                {
                    Debug.Log("Error: Stack empty");
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
            this.pressedButtons.Push(obj);
            buttonIsPressed = true;
        }


    }

}
