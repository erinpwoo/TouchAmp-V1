using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class MaterialChange : MonoBehaviour
    {
        public Material emissive;
        Transform child;
        Material original;

        void Awake()
        {
            string buttonTag = this.name;
            child = this.gameObject.transform.Find("Cube");
            original = child.GetComponent<Renderer>().material;
            
        }
        void Start()
        {
            
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

    // Update is called once per frame
    void Update()
        {
            
        }

    }

