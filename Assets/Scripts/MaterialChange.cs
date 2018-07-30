using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class MaterialChange : MonoBehaviour
    {

        public Material emissive;
        public Transform child;
        public Material original;
        public bool isPressed;

        void Awake()
        {
            string buttonTag = this.name;
            child = this.gameObject.transform.Find("Cube");
            original = child.GetComponent<Renderer>().material;
            isPressed = false;
        }

        public void OnCollisionEnter(Collision collision)
        {
            child.GetComponent<Renderer>().material = emissive;
            isPressed = true;
        }


         private void OnCollisionExit(Collision collision)
        {
            child.GetComponent<Renderer>().material = original;
            isPressed = false;
        }

        public void OnCollisionStay(Collision collision)
        {
            child.GetComponent<Renderer>().material = emissive;
            isPressed = true;
        }

        public IEnumerator CueLightUp()
        {
            child.GetComponent<Renderer>().material = emissive;
            yield return new WaitForSeconds(2);
            child.GetComponent<Renderer>().material = original;
        }

        
    }

