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
            roundNum++;
            setRoundText();
            yield return StartCoroutine(PlayPattern());
            yield return StartCoroutine(UsersTurn());
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

        public static void Quit()
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();

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

                yield return new WaitUntil(() => buttonIsPressed == true);
                if (pressedButtons.Count != 0)
                {
                    if (pressedButtons.Peek() == intButtons[pattern[i]])
                    {
                        yield return new WaitUntil(() => buttonIsPressed == false);
                        pressedButtons.Pop();
                    }
                    else
                    {
                        Debug.Log("Correct button press: " + intButtons[pattern[i]]);
                        endText.text = "Game Over. Score: " + roundNum.ToString();
                        roundText.text = "";
                        statusText.text = "";
                        yield return new WaitForSeconds(3);
                        Quit();
                    }
                }
                else
                {
                    Debug.Log("Stack overflow");
                    break;
                }
                
            }
            statusText.text = "Nice! Next round ...";
            StartCoroutine(playGame());
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
