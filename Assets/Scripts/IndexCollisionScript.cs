using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexCollisionScript : MonoBehaviour {

    void Start()
    {
       
    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " has collided");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Button")
        {
            Debug.Log(collision.transform.name + " has collided");
        }
       
    }

}
