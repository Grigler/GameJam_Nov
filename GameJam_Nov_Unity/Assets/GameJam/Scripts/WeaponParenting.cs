using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParenting : MonoBehaviour {

	public List<GameObject> objs = new List<GameObject>();
	public GameObject parent;

	public void Parenting()
	{
		foreach (var i in objs) 
		{
			//i.GetComponent<Rigidbody> ().isKinematic = true;
			//i.GetComponent<Rigidbody>().useGravity = false;
			i.transform.SetParent (parent.transform);
			i.transform.localPosition = new Vector3 (0, 0, 0);
			i.transform.GetComponent<Rigidbody> ().interpolation = RigidbodyInterpolation.None;
			i.transform.GetComponent<Collider> ().isTrigger = true;
		}
	}
	public void UnParenting()
	{
		foreach (var i in objs) 
		{
			//i.GetComponent<Rigidbody> ().isKinematic = false;
			//i.GetComponent<Rigidbody> ().useGravity = true;
			i.transform.SetParent (transform);
			i.transform.GetComponent<Rigidbody> ().interpolation = RigidbodyInterpolation.Interpolate;
			i.transform.GetComponent<Collider> ().isTrigger = false;
		}
	}
}
