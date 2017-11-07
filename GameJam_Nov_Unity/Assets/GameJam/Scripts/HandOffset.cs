using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandOffset : MonoBehaviour
{

	// Update is called once per frame
	void Update () 
	{
		this.transform.rotation = Quaternion.Euler (transform.parent.rotation.eulerAngles +
		new Vector3 (30, 0, 0));
	}
}
