using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHitTest : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.tag == "Enemy")
		{
			Debug.Log ("HIT");
		}
	}
}
