using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bob : MonoBehaviour {

    public float Greg;

	// Use this for initialization
	void Start () {
        Greg = 0.05f;
	}
	
	// Update is called once per frame
	void Update () {       

        transform.Translate(0, Mathf.Cos(Time.time) * Greg, 0);
        
	}
}
