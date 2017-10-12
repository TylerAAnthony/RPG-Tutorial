using UnityEngine;
using UnityEngine.AI;


public class Interactable : MonoBehaviour {

	public float radius = 3f;
	public Transform interactionTransform;

	bool isFocus = false;  // Is the interactable currently being focused
	Transform player;      // Reference to the player transform

	bool hasInteracted = false; // Have we previously intereacted with this object



	void Update () {
		// If we are curently being focused
		// and we haven't already interacted with the object 
		if (isFocus) {
			float distance = Vector3.Distance (player.position, interactionTransform.position);

			if (!hasInteracted && distance <= radius) {
				Interact ();
				hasInteracted = true;
			}
		}
	}

	// This method is written to be overwritten
	public virtual void Interact () {

		Debug.Log("Interacting with " + transform.name);
	}

	public void OnFocused (Transform playerTransform) {
		isFocus = true;
		player = playerTransform;
		hasInteracted = false;
	}

	public void OnDefocused () {
		isFocus = false;
		player = null;
		hasInteracted = false;
	}


	void OnDrawGizmosSelected () {

		if (interactionTransform == null) {
			interactionTransform = transform;
		}
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere (transform.position, radius);
	}
}
