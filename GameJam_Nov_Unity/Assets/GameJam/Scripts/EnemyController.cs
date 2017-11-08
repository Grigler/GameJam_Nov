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
    int rand;
    
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        chaseMin = 0.7f;
        anim = GetComponent<Animator>();
        timer = 0;
        agent.destination = new Vector3(target.transform.position.x, 1, target.transform.position.z);
        rand = Random.Range(0, 100);
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
        agent.destination = new Vector3(target.transform.position.x, 1, target.transform.position.z); 

        
        
        if (rand%2 == 0)
        {
            agent.speed = 4;
            if (true /*!anim.GetCurrentAnimatorStateInfo(0).IsName("locomotion")*/)
            {
               // anim.Play("locomotion");
                anim.SetTrigger("Start Locomotion");
            }
        }
        /*if (rand%2 == 1)
        {
            agent.speed = 10;
            if (!anim.GetCurrentAnimatorStateInfo(0).IsName("run"))
            {
                anim.SetTrigger("Start Run");
            }
        }*/

        
    }

    public void Kill()
    {
        Debug.Log("dicks");
        gameObject.SetActive(false);

    }
}
