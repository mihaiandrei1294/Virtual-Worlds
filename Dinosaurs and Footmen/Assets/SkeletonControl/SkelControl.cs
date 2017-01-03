using UnityEngine;
using System.Collections;

//dummy behavior controller before having behaviour tree

public class SkelControl : MonoBehaviour {

	public GameObject target;
	private Transform targetpos;
	private Animator anim;

	public float attackRange = 4;	//attack range
	
	
	//scripts
	private chaseAction chaseBehavior;
	private attackAction attackBehavior;
	private dieAction dieBehavior;
	private startAction startBehavior;

	private NavMeshAgent agent;
	
	//some private variable about animation boolean names
	private string idle = "isStanding";
	private string run = "isRunning";
	private string attack = "isAttacking";
	private string dead = "isDying";
	private string walk = "isWalking";
	
	
	//Just a variable for making things work, that will be removed with behavior tree
	private bool isDead = false;
	
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
		targetpos = target.transform;
		
		
		chaseBehavior = GetComponent<chaseAction>();
		attackBehavior = GetComponent<attackAction>();
		dieBehavior = GetComponent<dieAction>();
		startBehavior = GetComponent<startAction>();
		
		chaseBehavior.enabled = false;
		attackBehavior.enabled = false;
		dieBehavior.enabled = false;
		startBehavior.enabled = false;
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
			dieBehavior.enabled = false;
		}
		
		

		if(!isDead)
		{
			
			// if no target
			if(target == null)
			{
				IdleAnim();
				
				//disable all behaviors
				chaseBehavior.enabled = false;
				attackBehavior.enabled = false;
				startBehavior.enabled = false;
			}
			//else if too far away, just walk
			else if (Vector3.Distance(targetpos.position, this.transform.position) > 20)
			{
				Walk();
			}
			else //If see the target 
			{
				startBehavior.enabled = false;
				
				Vector3 direction = targetpos.position - this.transform.position;
				//If two far, chase target
				if(direction.magnitude > attackRange)
				{
					Chase();
				}
				else	//attack
				{
					Attack();
				}
			}
		}
		else //play dead
		{
			dieBehavior.enabled = true;
			chaseBehavior.enabled = false;
			attackBehavior.enabled = false;
			startBehavior.enabled = false;
			
		}
	}
	
	
	//Functions activating behaviors
	public void Chase()
	{
		agent.speed = chaseBehavior.speed;	//access to speed parameter of chaseAction
		
		dieBehavior.enabled = false;
		chaseBehavior.enabled = true;
		attackBehavior.enabled = false;
		startBehavior.enabled = false;
	}
	
	public void Attack()
	{
		dieBehavior.enabled = false;
		chaseBehavior.enabled = false;
		attackBehavior.enabled = true;
		startBehavior.enabled = false;
	}
	
	public void Walk()	//walk = start (but start already used)
	{
		agent.speed = startBehavior.speed;	//access to speed parameter of startAction
		
		dieBehavior.enabled = false;
		chaseBehavior.enabled = false;
		attackBehavior.enabled = false;
		startBehavior.enabled = true;
	}
	
	
	//Functions playing animations
	//Note: Animation management is done in the behaviors and not in this file if possible
	public void IdleAnim()
	{
		anim.SetBool(idle, true);
		anim.SetBool(run, false);
		anim.SetBool(attack, false);
		anim.SetBool(dead, false);
		anim.SetBool(walk, false);
	}
	
	public void RunAnim()
	{
		anim.SetBool(idle, false);
		anim.SetBool(run, true);
		anim.SetBool(attack, false);
		anim.SetBool(dead, false);
		anim.SetBool(walk, false);
	}
	
	public void DieAnim()
	{
		anim.SetBool(idle, false);
		anim.SetBool(run, false);
		anim.SetBool(attack, false);
		anim.SetBool(dead, true);
		anim.SetBool(walk, false);
	}
	
	public void WalkAnim()
	{
		anim.SetBool(idle, false);
		anim.SetBool(run, false);
		anim.SetBool(attack, false);
		anim.SetBool(dead, false);
		anim.SetBool(walk, true);
	}
	

}
