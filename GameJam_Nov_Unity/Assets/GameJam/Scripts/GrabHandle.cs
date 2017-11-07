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
			Debug.Log ("Hovering");
			if (true || hand.gameObject == inside) 
			{
				if (hand.GetStandardInteractionButtonDown () || ((hand.controller != null) && hand.controller.GetPressDown (Valve.VR.EVRButtonId.k_EButton_Grip)))
				{
					if (hand.currentAttachedObject != gameObject)
					{
						//Orienting to hand
						this.transform.position = hand.transform.position;
						this.transform.rotation = Quaternion.Euler(grabOrientation);

						//Locking for detatchment
						hand.HoverLock (GetComponent<Interactable> ());
						hand.AttachObject (gameObject, attatchmentFlags);

						//Connecting to hand with Joint
						//CreateHandJoint();
						//handJoint.connectedBody = hand.GetComponent<Rigidbody>();
					}
					else
					{
						hand.DetachObject (gameObject);

						hand.HoverUnlock (GetComponent<Interactable> ());

						//Disconnecting handJoint
						//Destroy(handJoint);
					}
				}
			}
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