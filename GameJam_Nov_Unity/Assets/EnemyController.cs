using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    public GameObject target;
    public float chaseMin;
    bool isChasing;
    Animator anim;
    float timer;
	// Use this for initialization
	void Start () {
        isChasing = true;
        anim = GetComponent<Animator>();
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.SqrMagnitude(target.transform.position - transform.position) <= (chaseMin*chaseMin))
        {
            //Combat
            Combat();
        }
        else
        {
            //Chase
            Chase();
        }
	}
    void Combat()
    {
        anim.Play("breathe");
        timer += Time.deltaTime;
        if (timer >= 1.5f)
        {
            timer = 0;
            int rand = Random.Range(0, 1);
            //DAMANGE PLAYER FUNCTION
            if(rand ==0)
            {
                anim.Play("PunchLf");
            }
            if (rand ==1)
            {
                anim.Play("PunchRf");
            }
            
        }
        
    }
    void Chase()
    {
        int rand = Random.Range(0, 1);
        //CHANGE SPEED DEPENDING ON RUNNING OR WALKING
        if (rand == 0)
        {
            anim.Play("locomotion");
        }
        if (rand == 1)
        {
            anim.Play("run");
        }
    }
}
