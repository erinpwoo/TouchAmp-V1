using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Leap.Unity.Interaction
{
    public class GameController : MonoBehaviour
    {

        int roundNum;
        bool isPlaying;
        public GameObject[] buttons;
        

        // Use this for initialization
        void Start()
        {
            roundNum = 1;
            isPlaying = true;
            buttons = GameObject.FindGameObjectsWithTag("Button");
            for (int i = 0; i < buttons.Length; i ++)
            {
                Debug.Log(i + " " + buttons[i].name);
            }
        }

        void playRound(int roundNum) //randomly generates and executes pattern 
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}
