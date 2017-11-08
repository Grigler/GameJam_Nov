using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {    
    public GameObject target;
    public float chaseMin;
    bool isChasing;
    Animator anim;
	bool isRunAnim;

	float timer;
    NavMeshAgent agent;
    int rand;

	bool isDying;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        chaseMin = 0.7f;
        anim = GetComponent<Animator>();
        timer = 0;
        agent.destination = new Vector3(target.transform.position.x, 1, target.transform.position.z);
        rand = Random.Range(0, 100);

		ResetVals ();
    }

	void ResetVals()
	{
		bool isRun = Random.Range (0, 1000.0f) <= 500;
		anim.SetBool("isRun", isRun);
		if (isRun)
			agent.speed = 5;
		else
			agent.speed = 2;
		isDying = false;
	}

	// Update is called once per frame
	void Update () {       

		if(isDying)
		{
			//Wait for animation to finish then kill
			if(anim.GetCurrentAnimatorStateInfo(0).IsName("KillMe"))
			{
				gameObject.SetActive (false);
				ResetVals ();
			}
		}
        else if (Vector3.SqrMagnitude(target.transform.position - transform.position) <= (chaseMin*chaseMin))
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
		anim.SetTrigger ("StartAttack");
        
    }
    void Chase()
    {
        agent.destination = new Vector3(target.transform.position.x, 1, target.transform.position.z); 
        
		anim.SetTrigger ("StopAttack");
    }

    public void Kill()
    {
		anim.SetTrigger ("Kill");
		isDying = true;
    }
}
