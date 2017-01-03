using UnityEngine;
using System.Collections;

public class FootmanControl : MonoBehaviour {

	//////////////////
	//  ATTRIBUTES  //
	//////////////////

	
	public bool hasSoP = false;	//boolean indicating if the robot has the Staff of Pain
	
	public GameObject target;
	private Transform targetpos;
	private Animator anim;

	
	//objects references
	private GameObject SoP;
	private GameObject skeleton;
	private GameObject bigTree;
	
	//scripts
	private StartFM startBehavior;
	private PickAction pickBehavior;
	//private dieAction dieBehavior;
	
	
	private NavMeshAgent agent;
	
	//some private variable about animation boolean names
	private string idle = "isStanding";
	private string run = "isRunning";
	private string dead = "isDying";
	private string walk = "isWalking";
	
	
	
	
	///////////////
	//  METHODS  //
	///////////////
	
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
		targetpos = target.transform;
		
		//getting objects references
		SoP = GameObject.FindWithTag("SoP");
		skeleton = GameObject.FindWithTag("skeleton");
		bigTree = GameObject.FindWithTag("bigTree");
		
		pickBehavior = GetComponent<PickAction>();
		//dieBehavior = GetComponent<dieAction>();
		startBehavior = GetComponent<StartFM>();
		
		startBehavior.enabled = false;
		pickBehavior.enabled = false;
		
		//
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("q"))
		{
			Debug.Log("Walk to SOP");
			Walk(SoP);
		}
		
		//if see skeleton
		if (Vector3.Distance(this.transform.position, skeleton.transform.position) < 20)
		{
			//if the footmen has the sop
			if(hasSoP)
			{
				//run away in direction of tree
				RunAway(bigTree);
			}
			else	//no sop
			{
				RunAway(SoP);
			}
		}
		else	//no skeleton
		{
			//if the footmen has the sop
			if(hasSoP)
			{
				//walk to big tree
				Walk(bigTree);
			}
			else	//no sop
			{
				//if too far away to pick
				if (Vector3.Distance(this.transform.position, SoP.transform.position) > 3)
				{
					Walk(SoP);	//move to SoP
				}
				else	//can pick !
				{
					Pick(SoP);
				}
			}
		}
	}
	
	
	

	
	
	//Functions activating behaviors
	public void Walk(GameObject newtarget)	//walk = start (but start already used)
	{
		
		
		Debug.Log("WALK TO " + newtarget.name);
		agent.speed = startBehavior.speed;	//access to speed parameter of startAction
		startBehavior.setTarget(newtarget);
		
		pickBehavior.enabled = false;
		startBehavior.enabled = true;
		
	}
	
	public void RunAway(GameObject newtarget)
	{
		int useless = 1;
	}
	
	public void Pick(GameObject newtarget)
	{
		Debug.Log("PICK " + newtarget.name);
		pickBehavior.enabled = true;
		startBehavior.enabled = false;
		int useless = 1;
		hasSoP = true;
	}
	
	//Functions playing animations
	//Note: Animation management is done in the behaviors and not in this file if possible
	public void IdleAnim()
	{
		anim.SetBool(idle, true);
		anim.SetBool(run, false);
		anim.SetBool(dead, false);
		anim.SetBool(walk, false);
	}
	
	public void RunAnim()
	{
		anim.SetBool(idle, false);
		anim.SetBool(run, true);
		anim.SetBool(dead, false);
		anim.SetBool(walk, false);
	}
	
	public void DieAnim()
	{
		anim.SetBool(idle, false);
		anim.SetBool(run, false);
		anim.SetBool(dead, true);
		anim.SetBool(walk, false);
	}
	
	public void WalkAnim()
	{
		anim.SetBool(idle, false);
		anim.SetBool(run, false);
		anim.SetBool(dead, false);
		anim.SetBool(walk, true);
	}
}
