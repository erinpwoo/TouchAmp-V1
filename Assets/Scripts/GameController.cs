using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Leap.Unity.Interaction
{
    public class GameController : MonoBehaviour
    {

        public Text roundText;
        public Text endText;
        public Text statusText;

        int roundNum;
        bool isPlaying;
        public bool buttonIsPressed;
        public InteractionButton pressedButton;
        public GameObject[] buttons; //fixed array of button indecies
        public InteractionButton[] intButtons;
        List<int> pattern = new List<int>(); //pattern 
        Stack<InteractionButton> pressedButtons = new Stack<InteractionButton>();


        private void Awake()
        {
            roundNum = 0;
            setRoundText();
            isPlaying = true;
            buttonIsPressed = false;
            buttons = GameObject.FindGameObjectsWithTag("Button");
            intButtons = new InteractionButton[4];
            endText.text = "";
        }

        // Use this for initialization
        void Start()
        {

            
           
            for (int i = 0; i < intButtons.Length; i++)
            {
                intButtons[i] = buttons[i].GetComponent<InteractionButton>();
            }

            StartCoroutine(StartFunc());
         }

        IEnumerator StartFunc()
        {
            pattern.Add(Random.Range(0, 3));
            yield return StartCoroutine(PlayPattern());
            yield return StartCoroutine(UsersTurn());
            yield return StartCoroutine(playGame());
        }

        void UpdatePattern() //increments pattern list, adds new index to call upon -- works 
        {
            
            pattern.Add(Random.Range(0, 3));
            roundNum++;
            setRoundText();
            
        }

        //PlayPattern() works
        IEnumerator PlayPattern() //randomly generates and executes pattern 
        {
            //Debug.Log(pattern.Count +" " + buttons.Length);
            statusText.text = "Waiting...";
            yield return new WaitForSeconds(7);
            
            for (int i = 0; i < pattern.Count; i++)
            {
                statusText.text = "Playing pattern";
                StartCoroutine(buttons[pattern[i]].GetComponent<InteractionButton>().CueLightUp()); //selects Interaction button, applies LightUp()
                Debug.Log("Playing pattern: " + buttons[pattern[i]]);
                yield return new WaitForSeconds(2);
            }
        }

        void setRoundText()
        {
            roundText.text = "Round: " + roundNum.ToString();
        }

        //Stack implementation of user input comparison to pattern
        IEnumerator UsersTurn()
        {
            
            for (int i = 0; i < pattern.Count; i++) //total buttons that must be pressed to pass round
            {
                statusText.text = "Your turn!";

                Debug.Log("Waiting for button to be pressed...");

                yield return new WaitUntil(() => buttonIsPressed == true); //waits until user presses button
                if (pressedButtons.Count != 0)
                {
                    Debug.Log("button in stack: " + pressedButtons.Peek() + "     button to be pressed " + intButtons[pattern[i]]);
                    if (pressedButtons.Peek() == intButtons[pattern[i]]) //checks top of stack and compares to button that should be pressed
                    { 
                        Debug.Log("Correct Button pressed");
                        pressedButtons.Pop(); //pops and waits for new button press

                        //yield return new WaitUntil(() => buttonIsPressed == false);
                    }
                    else
                    {
                        statusText.text = "Wrong button press! GG";
                        Debug.Log("Wrong Button pressed. Display score: " + roundNum);
                        roundText.text = "";
                        endText.text = "Game over. Score: " + roundNum.ToString();
                        isPlaying = false;
                        Application.Quit();
                        break;
                    }
                } else
                {
                    Debug.Log("Stack overflow");
                }
            }
        }

        public void addPressed(InteractionButton obj) //used in interactionbutton under collision method
        {
            this.pressedButtons.Push(obj);
            buttonIsPressed = true;
            Debug.Log("Button added to stack: " + obj);
        }

        IEnumerator playGame()
        {
            UpdatePattern();
            yield return StartCoroutine(PlayPattern());
            yield return StartCoroutine(UsersTurn());
            
        }

    }

}
