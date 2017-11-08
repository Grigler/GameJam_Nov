using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialColour : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        
        Material mat = gameObject.GetComponent<MeshRenderer>().material;
        mat.SetColor("Albedo", new Color(Random.Range(0, 1000.0f) / 1000.0f, Random.Range(0, 1000.0f) / 1000.0f, Random.Range(0, 1000.0f) / 1000.0f));

        
	}
	
}
