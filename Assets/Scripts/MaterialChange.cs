using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class MaterialChange : MonoBehaviour
    {
        public Material emissive;
        public Transform child;
        public Material original;
        public bool pressed;

        void Awake()
        {
        pressed = false;
            string buttonTag = this.name;
            child = this.gameObject.transform.Find("Cube");
            original = child.GetComponent<Renderer>().material;
            
        }

        public void OnCollisionEnter(Collision collision)
        {
            child.GetComponent<Renderer>().material = emissive;
        }

        private void OnCollisionExit(Collision collision)
        {
            child.GetComponent<Renderer>().material = original;        
        }

        public void OnCollisionStay(Collision collision)
        {
            child.GetComponent<Renderer>().material = emissive;
        }


        public IEnumerator CueLightUp()
        {
            child.GetComponent<Renderer>().material = emissive;
            yield return new WaitForSeconds(2);
            child.GetComponent<Renderer>().material = original;
        }
    }

