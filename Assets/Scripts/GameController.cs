using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leap.Unity.Interaction
{
    public class GameController : MonoBehaviour
    {

        //BUTTON INDICES:
        //Green = 0; Blue = 1; Yellow = 2; Light blue = 3; Pink = 4; Purple = 5; Red = 6; Grey = 7; Orange = 8

        int roundNum;
        bool isPlaying;
        public GameObject[] buttons; //fixed array of button indecies
        List<int> pattern = new List<int>(); //pattern 
        

        // Use this for initialization
        void Start()
        {
            roundNum = 0;
            isPlaying = true;
            buttons = GameObject.FindGameObjectsWithTag("Button");
            pattern.Add(Random.Range(0, 7));
            //playGame();
            Debug.Log("Start");
        }

        void UpdatePattern() //increments pattern list, adds new index to call upon
        {
            pattern.Add(Random.Range(0, 7));
            roundNum++;
        }

        void PlayPattern() //randomly generates and executes pattern 
        {
            for (int i = 0; i < pattern.Count; i++)
            {
                buttons[pattern[i]].GetComponent<InteractionButton>().StartCoroutine("CueLightUp()"); //selects Interaction button, applies LightUp()
            }
        }

        IEnumerator UsersTurn()
        {
            for (int i = 0; i < pattern.Count; i++)
            {
                while (buttons[pattern[i]].GetComponent<InteractionButton>().isPressed == false) { //checks if any button besides the one that should be pressed is pressed
                    foreach (GameObject button in buttons)
                        {
                            if (button.GetComponent<InteractionButton>().isPressed)
                            {
                                isPlaying = false;
                            }
                        }
                }
                yield return new WaitUntil(() => buttons[pattern[i]].GetComponent<InteractionButton>().isPressed == true); //waits until user presses the correct button
            }
            
        }

        void playGame()
        {
            while (isPlaying == true)
            {
                PlayPattern();
                StartCoroutine("UsersTurn()");
                UpdatePattern();
            }

        }

        // Update is called once per frame
        void Update()
        {
            if (isPlaying == false)
            {
                Debug.Log("Score: " + roundNum);
                Application.Quit();
            }
        }

    }
}
