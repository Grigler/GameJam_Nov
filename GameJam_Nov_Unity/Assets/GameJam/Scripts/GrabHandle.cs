using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
	[RequireComponent( typeof( Interactable ) )]
	public class GrabHandle : MonoBehaviour
	{
		private Hand.AttachmentFlags attatchmentFlags = Hand.AttachmentFlags.DetachOthers;// = Hand.defaultAttachmentFlags & ( ~Hand.AttachmentFlags.DetachOthers );
		public Vector3 grabOrientation;

		GameObject inside = null;

		private FixedJoint handJoint;

		Vector3 lastPos;

		public Vector3 vel = new Vector3(0.0f,0.0f,0.0f);

		bool isActive = false;

		void Awake()
		{
			lastPos = this.transform.position;
		}

		void CreateHandJoint()
		{
			handJoint = gameObject.AddComponent<FixedJoint> ();
			handJoint.breakForce = float.PositiveInfinity;
			handJoint.breakTorque = float.PositiveInfinity;
			handJoint.enableCollision = false;
			handJoint.enablePreprocessing = true;
		}

		private void HandHoverUpdate(Hand hand)
		{
			UnityEngine.Debug.Log ("Hover");
			if (hand.GetStandardInteractionButtonDown () || ((hand.controller != null) && hand.controller.GetPressDown (Valve.VR.EVRButtonId.k_EButton_Grip)))
			{
				if (hand.currentAttachedObject != gameObject)
				{
					UnityEngine.Debug.Log ("Attatch");
					//Orienting to hand
					this.transform.position = hand.transform.position;
					this.transform.rotation = Quaternion.Euler(hand.transform.rotation.eulerAngles + grabOrientation);

					//Locking for detatchment
					hand.HoverLock (GetComponent<Interactable>());
					hand.AttachObject (gameObject, attatchmentFlags);

					//Used for velocity gathering
					isActive = true;

					//Connecting to hand with Joint
					//CreateHandJoint();
					//handJoint.connectedBody = hand.GetComponent<Rigidbody>();
				}
			}
			else if(hand.GetStandardInteractionButtonUp()|| ((hand.controller != null) && hand.controller.GetPressUp (Valve.VR.EVRButtonId.k_EButton_Grip)))
			{
				if (hand.currentAttachedObject == gameObject)
				{
					UnityEngine.Debug.Log ("Detatch");
					hand.DetachObject (gameObject);

					hand.HoverUnlock (GetComponent<Interactable> ());

					isActive = false;

					//Disconnecting handJoint
					//Destroy(handJoint);
				}
			}
		}

		void FixedUpdate()
		{
			if (isActive)
			{
				Vector3 dist = this.transform.position - lastPos;
				vel = dist / Time.deltaTime;
				lastPos = this.transform.position;
				//Debug.Log ("Fixed: " + vel);
			}
		}
		public Vector3 GetVel()
		{
			return vel;
		}

		void OnTriggerEnter(Collider col)
		{
			Debug.Log ("Trigger Enter");
			inside = col.gameObject;
		}
		void OnTriggerStay(Collider col)
		{
			Debug.Log ("Trigger Exit");
			inside = null;
		}
	}
}