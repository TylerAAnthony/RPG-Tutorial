using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {

	public delegate void OnFocusChanged(Interactable newFocus);
	public OnFocusChanged onFocusChangedCallback;

	public Interactable focus;

	public LayerMask movementMask;
	public LayerMask interactionMask;

	Camera cam;
	PlayerMotor motor;



	// Use this for initialization
	void Start () {
		cam = Camera.main;
		motor = GetComponent<PlayerMotor> ();
	}
	
	// Update is called once per frame
	void Update () {


		// If left mouse button pressed
		if (Input.GetMouseButtonDown(0)) {
			
			// Shoot out a ray
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// If we hit something
			if (Physics.Raycast(ray, out hit, 100, movementMask)) {

				// Move player to what we hit
				motor.MoveToPoint(hit.point);

				// Stop Focusing any objects
				SetFocus(null);
			}
		}

		// If right mouse button pressed
		if (Input.GetMouseButtonDown(1)) {
			// We create a ray
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			// if  the ray hits
			if (Physics.Raycast(ray, out hit, 100)){

				// Check if we hit an interactable
				Interactable interactable = hit.collider.GetComponent<Interactable>();

				// If we did set it as our focus
				if (interactable != null) {
					SetFocus(interactable);
				}


			}

		}
			
	}

	void SetFocus(Interactable newFocus) {

		if (onFocusChangedCallback != null) {

			onFocusChangedCallback.Invoke (newFocus);
		}
		// if focus has changed
		if (focus != newFocus && focus != null) {

			// let previous focus know that it's no longer being focused
			focus.OnDefocused();
		}

		// Set our focus to what we hit
		focus = newFocus;
		if (focus != null) {

			// let your focus know it is being focused
			focus.OnFocused(transform);
		}
	
	}
	
}
