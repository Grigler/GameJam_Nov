using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramid : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().AddTorque(transform.up * 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
