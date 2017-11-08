using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {
	public GameObject enemyPrefab;

    static int spawned;
    //static public GameObject[] enemeh = new GameObject[10];
	static public List<GameObject> pool = new List<GameObject>();

    public GameObject target;
    float timer;
	// Use this for initialization
	void Start () {
        spawned = 0;
        timer = 0;

		for (int i = 0; i < 25; i++) 
		{
			GameObject e = GameObject.Instantiate (enemyPrefab) as GameObject;
			e.GetComponent<EnemyController> ().target = GameObject.Find ("Hand1");
			if(e.GetComponent<EnemyController>().target == null)
			{
				e.GetComponent<EnemyController> ().target = GameObject.Find ("FallbackHand");
			}
			pool.Add (e);
			e.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Vector3.Distance(target.transform.position, transform.position) < 60)
        {
            if (timer > 1.5f)
            {
				Spawn ();
            }
        }
        timer += Time.deltaTime;
	}

	void Spawn()
	{
		foreach (var e in pool) 
		{
			if(!e.activeInHierarchy)
			{
				e.transform.position = transform.position;
				e.SetActive (true);
				spawned++;
				timer = 0.0f;
				return;
			}
		}
	}
}
