using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnY : MonoBehaviour {

	// Update is called once per frame
	void Update ()
	{
		transform.Rotate (new Vector3 (0, 25.0f * Time.deltaTime, 0));
	}
}
