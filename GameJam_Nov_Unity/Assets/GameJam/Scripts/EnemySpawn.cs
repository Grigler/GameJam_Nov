using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
    static int spawned;
    public GameObject[] enemeh = new GameObject[10];
    public GameObject target;
	// Use this for initialization
	void Start () {
        spawned = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (Vector3.Distance(target.transform.position, transform.position) < 60)
        {
            if (!enemeh[spawned].activeInHierarchy)
            {
                enemeh[spawned].transform.position = transform.position;
                enemeh[spawned].SetActive(true);
                spawned++;
            }
        }
	}
}
