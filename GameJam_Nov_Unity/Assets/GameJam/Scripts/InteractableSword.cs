using System.Collections;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
	[RequireComponent( typeof( Interactable ) )]
	public class InteractableSword : MonoBehaviour
	{
		private Vector3 oldPosition;
		private Quaternion oldRotation;

		private Hand.AttachmentFlags attatchmentFlags = Hand.defaultAttachmentFlags & ( ~Hand.AttachmentFlags.SnapOnAttach ) & ( ~Hand.AttachmentFlags.DetachOthers );

		public Collider handle;
		public Collider blade;
		public Collider hilt;

		bool canPickUp = false;

		private void OnHandHoverBegin(Hand hand)
		{
			Debug.Log ("Hover Begin");
		}
		private void OnHandHoverEnd(Hand hand)
		{
			Debug.Log ("Hover End");
		}

		private void HandHoverUpdate(Hand hand)
		{
			if (canPickUp) {
				if (hand.GetStandardInteractionButtonDown () || ((hand.controller != null) && hand.controller.GetPressDown (Valve.VR.EVRButtonId.k_EButton_Grip))) {
				
					//Stuff
					if (hand.currentAttachedObject != gameObject) {
						oldPosition = transform.position;
						oldRotation = transform.rotation;
						//Keeps hover update function going
						hand.HoverLock (GetComponent<Interactable> ());

						hand.AttachObject (gameObject, attatchmentFlags);
					} else {
						hand.DetachObject (gameObject);

						hand.HoverUnlock (GetComponent<Interactable> ());

						//Would be replaced with activating RigidBody
						transform.position = oldPosition;
						transform.rotation = oldRotation;
					}
				}
			}
		}

		private void HandAttatchedUpdate(Hand hand)
		{
			Debug.Log ("Attatched");
		}
		private void OnHandFoucsAcquired(Hand hand)
		{
			Debug.Log ("Has focus");
		}
		private void OnHandFoucsLost(Hand hand)
		{
			Debug.Log ("Lost focus");
			canPickUp = false;
		}

		void OnCollisionEnter(Collision col)
		{
			Collider collider = col.collider;
			if(collider == handle)
			{
				Hand h = col.gameObject.GetComponent<Hand> ();
				if(h != null)
				{
					canPickUp = true;
				}
			}
			else if(collider == hilt)
			{
				//Nothing really
			}
			else if(collider == blade)
			{
				//Enemy stuff
			}
		}

	}
}
