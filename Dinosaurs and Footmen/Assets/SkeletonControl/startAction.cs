﻿using UnityEngine;
using System.Collections;


//smell FM smells -> move towards them (FM = red FM??)
//FM = red FM for now

public class startAction : MonoBehaviour {

	private GameObject target;
	private Transform targetpos;


	private tempSkelControl parent; //main script that will have useful variables, used to handle animations
	
	
	private NavMeshAgent agent;
	public float speed = 0.2f;
	
	// Use this for initialization
	void Start ()
	{
		parent = GetComponent<tempSkelControl>();

		target = parent.target;
		targetpos = target.transform;
		
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		agent.SetDestination(targetpos.position);
		
		//play run animation
		parent.WalkAnim();
	}
}