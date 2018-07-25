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
            Debug.Log("Name: " + child.name);
            Debug.Log("Child material: " + original);
        }

        private void OnCollisionEnter(Collision collision)
        {
            child.GetComponent<Renderer>().material = emissive;
        }

        private void OnCollisionExit(Collision collision)
        {
            child.GetComponent<Renderer>().material = original;        
        }

        private void OnCollisionStay(Collision collision)
        {
            child.GetComponent<Renderer>().material = emissive;
        }

    // Update is called once per frame
    void Update()
        {
            
        }

    }

