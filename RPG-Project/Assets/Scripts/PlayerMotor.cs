﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour {

	NavMeshAgent agent;

	Transform target;
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update () {
		if (target != null) {
			agent.SetDestination (target.position);
		}
	}
	
	public void MoveToPoint (Vector3 point) {

		agent.SetDestination (point);
	}

	public void FollowTarget (Interactable newTarget) {
		target = newTarget.transform;

	}

	public void StopFollowingTarget(){
		target = null;
	}
}
