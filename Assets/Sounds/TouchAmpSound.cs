using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchAmpSound : MonoBehaviour {

    AudioSource sound;
    AudioListener main;
    bool play;
    bool toggleChange;
    int preset;
    public bool useMic;

    // Use this for initialization
    void Start () {
        sound = GetComponent<AudioSource>();
        play = true;

        if (this.tag == "Button")
        {
            string buttonTag = this.name;
            switch (buttonTag)
            {
                case "Orange Button":
                    preset = 34;
                    break;
                case "Green Button":
                    preset = 26;
                    break;
                case "Red Button":
                    preset = 12;
                    break;
                case "Yellow Button":
                    preset = 20;
                    break;
                case "Light Blue Button":
                    preset = 23;
                    break;
                case "Grey Button":
                    preset = 18;
                    break;
                case "Pink Button":
                    preset = 13;
                    break;
                case "Blue Button":
                    preset = 16;
                    break;
                case "Purple Button":
                    preset = 3;
                    break;
                default: //default preset: 36
                    preset = 36;
                    break;
            }
            Debug.Log("sound preset " + preset + " " + this.name);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
