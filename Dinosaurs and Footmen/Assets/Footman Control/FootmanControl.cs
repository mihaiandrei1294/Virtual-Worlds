using UnityEngine;
using System.Collections;

public class FootmanControl : MonoBehaviour {

	//////////////////
	//  ATTRIBUTES  //
	//////////////////

	
	public bool hasSoP = false;	//boolean indicating if the robot has the Staff of Pain
	
	public GameObject target;
	private Animator anim;

	
	//objects references
	private GameObject SoP;
	private GameObject skeleton;
	private GameObject bigTree;	//Note : We do not go directly to the big tree but to a Goal location in front of it
	
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
	
	
	private bool forced = false;
	
	
	private Vector3 pos1 = new Vector3(220, 0, 157);
	private Vector3 pos2 = new Vector3(250, 0, 149);
	
	///////////////
	//  METHODS  //
	///////////////
	
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();
		
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
			Debug.Log("Walk Forced");
			agent.SetDestination(bigTree.transform.position);
			
			startBehavior.enabled = false;
			pickBehavior.enabled = false;
			
			forced = true;
		}
		
		if (Input.GetKeyDown("j"))
		{
			Debug.Log(target.name);
			Debug.Log(agent.destination);
		}
		
		if (Input.GetKeyDown("c"))
		{
			agent.SetDestination(pos1);
		}
		
		if (Input.GetKeyDown("v"))
		{
			agent.SetDestination(pos2);
		}
		
		
		if(!forced)
		{
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
				if(startBehavior.enabled == false)
					Debug.Log("Je marche vers l'arbre !");
				//walk to big tree
				Walk(bigTree);
			}
			else	//no sop
			{
				//if too far away to pick
				if (Vector3.Distance(this.transform.position, SoP.transform.position) > 3)
				{
					if(startBehavior.enabled == false)
						Debug.Log("Je marche vers le SOP !");
					
					Walk(SoP);	//move to SoP
				}
				else	//can pick !
				{
					if(pickBehavior.enabled == false)
						Debug.Log("Je prend le SOP !");
					PickSoP();
				}
			}
		}
		}
	}
	
	
	
	public void setTarget(GameObject newtarget)
	{
		this.target = newtarget;
	}
	
	
	//210, 0, 140
	
	//Functions activating behaviors
	public void Walk(GameObject newtarget)	//walk = start (but start already used)
	{
		//activate only if not already activated or going to new target
		if(!startBehavior.enabled || this.target != newtarget)
		{
			Debug.Log("WALK TO " + newtarget.name);
			agent.speed = startBehavior.speed;	//access to speed parameter of startAction
			setTarget(newtarget);
			
			pickBehavior.enabled = false;
			startBehavior.enabled = true;
		}
	}
	
	
	public void RunAway(GameObject newtarget)
	{
		int useless = 1;
		Debug.Log("RUN AWAYYYY");
	}
	
	public void PickSoP()
	{
		//activate only if not already activated
		if(!pickBehavior.enabled)
		{
			
			Debug.Log("PICK SoP");
			pickBehavior.enabled = true;
			startBehavior.enabled = false;
			int useless = 1;
		}
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
