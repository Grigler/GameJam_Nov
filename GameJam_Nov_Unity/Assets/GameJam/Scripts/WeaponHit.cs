using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHit : MonoBehaviour
{
	Rigidbody rb;

	public Vector3 velThreshold;

	void Awake()
	{
		rb = gameObject.GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Enemy"))
		{
			if (rb.velocity.sqrMagnitude >= velThreshold.sqrMagnitude)
				other.SendMessage ("Kill");
			else
				Debug.Log ("Hit it harder, faggot");
		}
	}
}
