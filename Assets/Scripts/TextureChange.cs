using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class MaterialChange : MonoBehaviour
    {
        public Material emissive;
        Component cube;

        void Awake()
        {
            string buttonTag = this.name;
            
            
            /*
            switch (buttonTag)
            {
                case "Orange Button":
                    tex.LoadImage(System.IO.File.ReadAllBytes("Assets/Textures/orange"));
                    break;
                case "Green Button":
                    tex.LoadImage(System.IO.File.ReadAllBytes("Assets/Textures/green"));
                    break;
                case "Red Button":
                    tex.LoadImage(System.IO.File.ReadAllBytes("Assets/Textures/red"));
                    break;
                case "Yellow Button":
                    tex.LoadImage(System.IO.File.ReadAllBytes("Assets/Textures/yellow"));
                    break;
                case "Light Blue Button":
                    tex.LoadImage(System.IO.File.ReadAllBytes("Assets/Textures/light_blue"));
                    break;
                case "Grey Button":
                    tex.LoadImage(System.IO.File.ReadAllBytes("Assets/Textures/grey"));
                    break;
                case "Pink Button":
                    tex.LoadImage(System.IO.File.ReadAllBytes("Assets/Textures/pink"));
                    break;
                case "Blue Button":
                    tex.LoadImage(System.IO.File.ReadAllBytes("Assets/Textures/blue"));
                    break;
                case "Purple Button":
                    tex.LoadImage(System.IO.File.ReadAllBytes("Assets/Textures/purple"));
                    break;
                default:
                    break;
            }*/
        }
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

    }

