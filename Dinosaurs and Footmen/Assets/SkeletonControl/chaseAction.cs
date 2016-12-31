﻿using UnityEngine;
using System.Collections;

public class chaseAction : MonoBehaviour 
{

	private GameObject target;
	private Transform targetpos;


	private tempSkelControl parent; //main script that will have useful variables, used to handle animations
	
	public float speed = 0.5f;
	
	// Use this for initialization
	void Start ()
	{
		parent = GetComponent<tempSkelControl>();

		target = parent.target;
		targetpos = target.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Rotate towards the target
		Vector3 direction = targetpos.position - this.transform.position;
		direction.y = 0;
		
		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 1f);
		
		
		
		this.transform.Translate(0,0, this.speed);
		
		//play run animation
		parent.RunAnim();


	}
}
