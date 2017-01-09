using UnityEngine;
using System.Collections;

public class FootmanActionHandler : MonoBehaviour
{

	//components
	private NavMeshAgent agent;
	private CapsuleCollider m_collider;
	
	//scripts
	private FootmanControl parent;
	//main script that will have useful variables
	
	private StartFM startBehavior;
	private PickAction pickBehavior;
	private FleeAction fleeBehavior;
	private dieFootmanAction dieBehavior;

	// Use this for initialization
	void Start ()
	{
		parent = GetComponent<FootmanControl> ();
		
		agent = GetComponent<NavMeshAgent> ();
		m_collider = GetComponent<CapsuleCollider> ();
		
		
		pickBehavior = GetComponent<PickAction> ();
		dieBehavior = GetComponent<dieFootmanAction> ();
		startBehavior = GetComponent<StartFM> ();
		fleeBehavior = GetComponent<FleeAction> ();
	
	}
	
	//Functions activating behaviors
	public void Walk (GameObject newtarget)	//walk = start (but start already used)
	{
		//activate only if not already activated or going to new target
		if (!startBehavior.enabled || parent.target != newtarget) {
			agent.speed = startBehavior.speed;	//access to speed parameter of startAction
			parent.Target = newtarget;
			
			pickBehavior.enabled = false;
			startBehavior.enabled = true;
			fleeBehavior.enabled = false;
			dieBehavior.enabled = false;
		}
	}

	
	public void RunAway (GameObject newtarget)
	{
		if (!fleeBehavior.enabled || parent.target != newtarget) {
			agent.speed = fleeBehavior.speed;	//access to speed parameter of startAction
			parent.Target = newtarget;
			
			pickBehavior.enabled = false;
			startBehavior.enabled = false;
			fleeBehavior.enabled = true;
			dieBehavior.enabled = false;
		}
		
	}

	public void PickSoP ()
	{
		//activate only if not already activated
		if (!pickBehavior.enabled) {
			pickBehavior.enabled = true;
			startBehavior.enabled = false;
			fleeBehavior.enabled = false;
			dieBehavior.enabled = false;
		}
	}

	public void Die ()
	{
		//activate only if not already activated
		if (!dieBehavior.enabled) {
			parent.IsDead = true;
			Debug.Log ("Die");
			pickBehavior.enabled = false;
			startBehavior.enabled = false;
			fleeBehavior.enabled = false;
			dieBehavior.enabled = true;
			
			agent.speed = 0;
			agent.ResetPath ();
			
			m_collider.enabled = false;
			
		}
	}

	public void NoBehavior ()	//deactivate all behaviors
	{
		agent.speed = 0;
		agent.ResetPath ();
		
		dieBehavior.enabled = false;
		pickBehavior.enabled = false;
		startBehavior.enabled = false;
		fleeBehavior.enabled = false;
	}
}
