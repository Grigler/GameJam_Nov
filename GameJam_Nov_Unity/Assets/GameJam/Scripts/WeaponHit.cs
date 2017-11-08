using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHit : MonoBehaviour
{
	Rigidbody rb;

	public Vector3 velThreshold;

    public Vector3 lastPos;
    public Vector3 vel;

	void Awake()
	{
		rb = gameObject.GetComponent<Rigidbody> ();
        lastPos = this.transform.position;
	}

    private void FixedUpdate()
    {
        Vector3 dif = this.transform.position - lastPos;
        vel = dif / Time.deltaTime;
        lastPos = this.transform.position;
    }

    void OnTriggerEnter(Collider other)
	{
        Debug.Log("Generic trigger enter");
		if(other.gameObject.tag == "Enemy")
		{
			if (vel.sqrMagnitude >= velThreshold.sqrMagnitude)
            {
                Debug.Log("KILILIKILIKIJFLKDHFLKJHDS");
                other.gameObject.SendMessage("Kill");
            }
			else
				Debug.Log ("Hit it harder, faggot");
		}
	}
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Generic trigger enter");
        if (other.gameObject.tag == "Enemy")
        {
            if (vel.sqrMagnitude >= velThreshold.sqrMagnitude)
            {
                other.gameObject.SendMessage("Kill");
            }
            else
                Debug.Log("Hit it harder, faggot");
        }
    }

	void OnCollisionEnter(Collision col)
	{
		if(vel.sqrMagnitude >= velThreshold.sqrMagnitude)
		{
			if(col.gameObject.tag == "Enemy")
			{
				col.gameObject.SendMessage("Kill");	
			}
		}
	}
}
