using System.Collections;
using System.Collections.Generic;
using Leap.Unity.Interaction;
using UnityEngine;
using UnityOSC;

public class ButtonPress : InteractionBehaviour
{
    int preset = 0;

    // InteractionButton button;

    public void Press()
    {

        Debug.Log(this.name);
        if (this.tag == "Button")
        {
            string buttonTag = this.name;
            switch (buttonTag)
            {
                case "Orange Button":
                    preset = 1;
                    break;
                case "Green Button":
                    preset = 2;
                    break;
                case "Red Button":
                    preset = 3;
                    break;
                case "Yellow Button":
                    preset = 4;
                    break;
                case "Light Blue Button":
                    preset = 5;
                    break;
                case "Grey Button":
                    preset = 6;
                    break;
                case "Pink Button":
                    preset = 7;
                    break;
                case "Blue Button":
                    preset = 8;
                    break;
                case "Purple Button":
                    preset = 9;
                    break;
                default: //default preset: 36
                    preset = 36;
                    break;
            }
        }
        OSCHandler.Instance.SendMessageToClient("MaxMSP", "127.0.0.1", preset);
    }


}
