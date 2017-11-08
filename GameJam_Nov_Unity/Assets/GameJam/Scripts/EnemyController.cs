using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {    
    public GameObject target;
    public float chaseMin;
    bool isChasing;
    Animator anim;
    float timer;
    NavMeshAgent agent;    
    
	// Use this for initialization
	void Start () {
        chaseMin = 0.7f;
        anim = GetComponent<Animator>();
        timer = 0;
        transform.position += new Vector3(Random.Range(0, 1000)/1000, 0, Random.Range(0, 1000) / 1000);
        agent.destination = target.transform.position;
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
        
        if (rand == 0)
        {
            agent.speed = 4;
            anim.Play("locomotion");
        }
        if (rand == 1)
        {
            agent.speed = 10;
            anim.Play("run");
        }

        
    }
}
