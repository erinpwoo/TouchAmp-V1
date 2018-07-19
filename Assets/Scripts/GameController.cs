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
            for (int i = 0; i < buttons.Length; i ++)
            {
                Debug.Log(i + " " + buttons[i].name);
            }
        }

        void playRound() //randomly generates and executes pattern 
        {
            pattern.Add(Random.Range(0, 7));
            for (int i = 0; i < roundNum; i++)
            {
                buttons[pattern[i]].GetComponent<InteractionButton>().LightUp(); //selects Interaction button, applies LightUp()
            }
        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}
