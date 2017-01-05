using UnityEngine;
using System.Collections;

public class SkeletonActionHandler : MonoBehaviour {

	//components
	private NavMeshAgent agent;

	//scripts
	private chaseAction chaseBehavior;
	private attackAction attackBehavior;
	private dieAction dieBehavior;
	private startAction startBehavior;
	
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		
		chaseBehavior = GetComponent<chaseAction>();
		attackBehavior = GetComponent<attackAction>();
		dieBehavior = GetComponent<dieAction>();
		startBehavior = GetComponent<startAction>();
	}

	//Functions activating behaviors
	public void Chase()
	{
		//activate only if not already activated
		if(!chaseBehavior.enabled)
		{
			
			agent.speed = chaseBehavior.speed;	//access to speed parameter of chaseAction
			
			dieBehavior.enabled = false;
			chaseBehavior.enabled = true;
			attackBehavior.enabled = false;
			startBehavior.enabled = false;
		}
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
		//activate only if not already activated
		if(!startBehavior.enabled)
		{
			agent.speed = startBehavior.speed;	//access to speed parameter of startAction
			
			dieBehavior.enabled = false;
			chaseBehavior.enabled = false;
			attackBehavior.enabled = false;
			startBehavior.enabled = true;
		}
	}
	
	public void Die()
	{
		//activate only if not already activated
		if(!dieBehavior.enabled)
		{
			dieBehavior.enabled = true;
			chaseBehavior.enabled = false;
			attackBehavior.enabled = false;
			startBehavior.enabled = false;
			
			agent.speed = 0;
			agent.ResetPath();
		}
	}
	
	public void NoBehavior()	//deactivate all behaviors
	{
		agent.speed = 0;
		agent.ResetPath();
		
		dieBehavior.enabled = false;
		chaseBehavior.enabled = false;
		attackBehavior.enabled = false;
		startBehavior.enabled = false;
	}
}
