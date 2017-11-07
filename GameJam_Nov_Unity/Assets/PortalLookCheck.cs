using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalLookCheck : MonoBehaviour {

    public GameObject camruh;
    public GameObject destination;
    public float stareTime;
	// Use this for initialization
	void Start () {
        stareTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(camruh.transform.position, camruh.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 2))
        {
            if (hit.collider.gameObject.tag == "Portal")
            {
                stareTime += Time.deltaTime;
            }
            else
            {
                stareTime = 0;
            }
        }

        if(stareTime > 3)
        {
            transform.position = destination.transform.position;
        }

	}
}
