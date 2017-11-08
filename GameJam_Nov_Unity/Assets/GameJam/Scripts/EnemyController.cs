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

	bool isDying = false;

    // Use this for initialization
    void Awake () {
        if(agent == null)
        {
            agent = GetComponent<NavMeshAgent>();
            chaseMin = 2.5f;
        }
        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }

        timer = 0;
        agent.destination = new Vector3(target.transform.position.x, 1, target.transform.position.z);
        rand = Random.Range(0, 100);

		//ResetVals ();

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
		anim.SetBool ("isDying", isDying);
        //anim.StopPlayback();
	}

	// Update is called once per frame
	void Update () {       
		if (!target.activeInHierarchy)
			target = GameObject.Find ("FallbackHand");
		if(!isDying)
        {
            if (Vector3.SqrMagnitude(target.transform.position - transform.position) <= (chaseMin * chaseMin))
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
	}

    private void LateUpdate()
    {
       if(isDying || anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            isDying = true;
            anim.SetBool("isDying", true);
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("KillMe"))
            {
                ResetVals();
                gameObject.SetActive(false);
                
            }
        }
    }
    void Combat()
    {
		anim.SetTrigger ("StartAttack");

        
    }
    void Chase()
    {
		agent.SetDestination(new Vector3(target.transform.position.x, 1, target.transform.position.z)); 

		anim.SetTrigger ("StopAttack");
    }

    public void Kill()
    {
		anim.SetTrigger ("Kill");
        //isDying = true;
    }
}
