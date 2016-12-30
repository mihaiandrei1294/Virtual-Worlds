using UnityEngine;
using System.Collections;

//dummy behavior controller before having behaviour tree

public class tempSkelControl : MonoBehaviour {

	public GameObject target;
	private Transform targetpos;
	private Animator anim;

	//scripts
	private chaseAction chaseBehavior;
	private attackAction attackBehavior;
	private dieAction dieBehavior;

	//some private variable about animation boolean names
	private string idle = "isStanding";
	private string run = "isRunning";
	private string attack = "isAttacking";
	private string dead = "isDying";
	
	
	//Just a variable for making things work, that will be removed with behavior tree
	private bool isDead = false;
	
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		targetpos = target.transform;
		
		
		chaseBehavior = GetComponent<chaseAction>();
		attackBehavior = GetComponent<attackAction>();
		dieBehavior = GetComponent<dieAction>();
		
		chaseBehavior.enabled = false;
		attackBehavior.enabled = false;
		dieBehavior.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//On F pressed, kill the skeleton
		if (!isDead && Input.GetKeyDown("f"))
		{
			Debug.Log("DIE !");
			
			isDead = true;
		}
		
		//On R pressed, revive the skeleton
		if (isDead && Input.GetKeyDown("r"))
		{
			Debug.Log("COME AGAIN !");
			
			isDead = false;
			anim.SetBool(dead, false);
		}
		
		
		if(!isDead)
		{
			
			// if no target or target can't be seen
			if(target == null || Vector3.Distance(targetpos.position, this.transform.position) > 20)
			{
				anim.SetBool(idle, true);
				anim.SetBool(run, false);
				anim.SetBool(attack, false);
				
				//disable all behaviors
				chaseBehavior.enabled = false;
				attackBehavior.enabled = false;
			}
			else //If see the target 
			{
				Vector3 direction = targetpos.position - this.transform.position;
				//If two far, chase target
				if(direction.magnitude > 3)
				{
					chaseBehavior.enabled = true;
					attackBehavior.enabled = false;
				}
				else	//attack
				{
					chaseBehavior.enabled = false;
					attackBehavior.enabled = true;
				}
			}
		}
		else
		{
			dieBehavior.enabled = true;
			chaseBehavior.enabled = false;
			attackBehavior.enabled = false;
			
			anim.SetBool(idle, false);
			anim.SetBool(run, false);
			anim.SetBool(attack, false);
			anim.SetBool(dead, true);
		}
	}
	

}
