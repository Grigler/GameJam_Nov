using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : MonoBehaviour {

    public float cos;

    // Use this for initialization
    void Start()
    {
        cos = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Mathf.Cos(Time.time) * cos, 0, Mathf.Cos(Time.time) * cos);

    }
}
