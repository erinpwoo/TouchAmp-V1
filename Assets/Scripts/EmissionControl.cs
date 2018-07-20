using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmissionControl : MonoBehaviour {

    public Material material;

	// Use this for initialization
	void Start () {
        material.EnableKeyword("_EMISSION");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
