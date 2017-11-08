using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyMovement : MonoBehaviour {
    void Update()
    {
        transform.Rotate(new Vector3(25.0f * Time.deltaTime, -25.0f * Time.deltaTime, 0.0f));

    }
}


