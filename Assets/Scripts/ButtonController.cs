using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Leap.Unity.Interaction
{
    public class ButtonController : MonoBehaviour
    {
        private InteractionButton button;
        Color color;

        void Awake()
        {
            string buttonTag = this.name;
            
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
                    color = new Color(.58F, 0, .83F);
                    break;
                default: //default preset: 36
                    color = Color.clear;
                    break;
            }
        }
        void Start()
        {
            button = GetComponent<InteractionButton>();
        }

        // Update is called once per frame
        void Update()
        {
            button.LightUp();
        }

        public void LightUp() //lights up individual button when called upon -- NEEDS FIXING
        {
            Debug.Log("entering lightup");
            Material material = button.GetComponent<Renderer>().material;
            if (button.isLit == true) {
                Debug.Log(button.name + " is Lit");
                material.EnableKeyword("_EMISSION");
                material.SetColor("_EmissionColor", color);
            }
            else
            {
                Debug.Log("is not lit");
                material.SetColor("_Color", color);
            }
            
        }
    }
}
