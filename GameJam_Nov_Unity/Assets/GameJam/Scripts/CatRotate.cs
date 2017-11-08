using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatRotate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0.0f, -25.0f * Time.deltaTime, 0.0f));
      
    }
}
