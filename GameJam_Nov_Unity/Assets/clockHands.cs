using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clockHands : MonoBehaviour {

    public GameObject hour;
    public GameObject minute;
    int hmultipl = 1;
    int mmultipl = 1;
    float limith = Random.Range(500, 1500) / 1000;
    float limitm = Random.Range(500, 1500) / 1000;
    float countm = 0;
    float counth = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(countm > limitm)
        {
            mmultipl = Random.Range(-100, 100);
            countm = 0;
            limitm = Random.Range(500, 3000) / 1000;
        }

        if(counth > limith)
        {
            hmultipl = Random.Range(-100, 100);
            counth = 0;
            limith = Random.Range(500, 3000) / 1000;
        }
        minute.transform.Rotate(0, 0, Time.deltaTime * mmultipl);
        hour.transform.Rotate(0, 0, Time.deltaTime * hmultipl);
        countm += Time.deltaTime;
        counth += Time.deltaTime;
	}
}
