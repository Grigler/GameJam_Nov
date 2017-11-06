using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleFromMain : MonoBehaviour {

	private GameObject mainCam;

	public GameObject backupCam;

	private Vector3 mainInitialRot;
	private Vector3 thisInitialRot;

	// Use this for initialization
	void Start () {
		#if UNITY_EDITOR
		mainCam = backupCam;
		#else
		mainCam = Camera.main.gameObject;
		#endif

		mainInitialRot = backupCam.transform.rotation.eulerAngles;
		thisInitialRot = this.transform.rotation.eulerAngles;
	}

	void LateUpdate () {
		this.transform.rotation = Quaternion.Euler (thisInitialRot - (mainCam.transform.rotation.eulerAngles - mainInitialRot));
	}
}
