using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    int roundNum;
    bool isPlaying;

    // Use this for initialization
    void InitGame () {
        roundNum = 1;
        isPlaying = true;
	}

    void playRound(int roundNum) //randomly generates and executes pattern 
    {

    }

    void lightUp() //lights up individual button when called upon -- NEEDS FIXING
    {
            string buttonTag = this.name;
            Color color;
            switch (buttonTag)
            {
                case "Orange Button":
                    color = new Color(.2F, .3F, .4F);
                    break;
                case "Green Button":
                    color = Color.green;
                    break;
                case "Red Button":
                    color = Color.red;  
                    break;
                case "Yellow Button":
                    color = Color.yellow;
                    break;
                case "Light Blue Button":
                    color = Color.cyan;
                    break;
                case "Grey Button":
                    color = Color.grey;
                    break;
                case "Pink Button":
                    color = new Color(1F, .71F, .76F);
                    break;
                case "Blue Button":
                    color = Color.blue;
                    break;
                case "Purple Button":
                    color = new Color(.58F,0, .83F);
                    break;
                default: //default preset: 36
                    color = Color.clear;
                    break;
            }
            Material material = GetComponent<Renderer>().material;
            material.SetColor("_EmissionColor", color);
    }

    // Update is called once per frame
    void Update () {
		
	}

}
