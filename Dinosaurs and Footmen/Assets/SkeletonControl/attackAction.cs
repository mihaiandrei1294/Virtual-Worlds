﻿using UnityEngine;
using System.Collections;

/*
This is the Attack Action of the Skeleton. This action has to be actived
ONLY when the skeleton is in range of a footman. This action performs an attack.
*/

public class attackAction : MonoBehaviour {


	private Animator anim;
	
	private bool hasHit = false;
	
	
	private SkelControl parent; //main script that will have useful variables, used to handle animations
	
	
	//some private variable about animation boolean names
	private string run = "isRunning";
	private string attack = "isAttacking";

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		parent = GetComponent<SkelControl>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		AnimatorStateInfo currState = anim.GetCurrentAnimatorStateInfo(0);
		
		float animDuration = currState.normalizedTime % 1;
		
		
		if(!currState.IsName("Base.Attack"))
		{
			anim.SetBool(attack, true);
			anim.SetBool(run, false);
			hasHit = false;
		}
		
		//Debug.Log(animDuration);
		
		if (!hasHit && animDuration > 0.35f && animDuration < 0.45f && !anim.IsInTransition(0))
		{
			hasHit = true;
			Destroy(parent.target);
		}
		else if (hasHit && animDuration > 0.45f)
		{
			hasHit = false;
		}
	}
}
