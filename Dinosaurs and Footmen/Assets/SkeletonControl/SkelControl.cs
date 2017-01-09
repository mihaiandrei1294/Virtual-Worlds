using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RAIN.Core;

//dummy behavior controller before having behaviour tree

public class SkelControl : MonoBehaviour
{

	//attributes
	private GameObject target;
	//current target
	private float attackRange = 4;
	//attack range
	private List<GameObject> footmenList;
	//array of footmen
	
	//Just a variable for making things work, that will be removed with behavior tree
	private bool isDead = false;
	
	//Handlers
	private SkeletonAnimationHandler m_animHandler;
	private SkeletonActionHandler m_actionHandler;
	
	//Object references
	private GameObject sop;
	private StaffControl staff;
	//used to access staff info
	
	// Changed all attributes to public to be able to acces them from the ai files

	// The ai
	private AIRig ai;


	void Start ()
	{
		//get targets
		GameObject[] footmenArr = GameObject.FindGameObjectsWithTag ("footman");
		footmenList = footmenArr.ToList ();
		
		//get components
		m_animHandler = GetComponent<SkeletonAnimationHandler> ();
		m_actionHandler = GetComponent<SkeletonActionHandler> ();

		// Get AI
		ai = GetComponentInChildren<AIRig> ();
		
		//Find staff of pain
		sop = GameObject.FindWithTag ("SoP");
		staff = (StaffControl)sop.GetComponent (typeof(StaffControl));
		
		
		
		m_actionHandler.NoBehavior ();	//start by deactivating all behaviors. They will be activated with the behavior tree

	
	}

	
	void Update ()
	{
		
		//On F pressed, kill the skeleton
		if (!isDead && Input.GetKeyDown ("f")) {
			Debug.Log ("DIE !");
			isDead = true;
		}
		
		//On R pressed, revive the skeleton
		if (isDead && Input.GetKeyDown ("r")) {
			Debug.Log ("COME AGAIN !");
			isDead = false;
			m_animHandler.IdleAnim ();
			m_actionHandler.NoBehavior ();
		}
		
		

		if (!isDead) {
			//assigning new target if no target
//			if (target == null && footmenList.Count > 0) {
//				target = footmenList [0];
//			}
			
			
			
//			// if no target
//			if (target == null) {
//				m_animHandler.IdleAnim ();
//				m_actionHandler.NoBehavior ();
//			}
//			//else if too far away, just walk if SoP safe, else RUN !
//			else if (Vector3.Distance (target.transform.position, this.transform.position) > 20) {
//				if (staff.isPicked ()) {
//					m_actionHandler.Chase ();
//				} else {
//					m_actionHandler.Walk ();
//				}
//			} else { //If see the target 
//				//startBehavior.enabled = false;
//				
//				Vector3 direction = target.transform.position - this.transform.position;
//				//If two far, chase target
//				if (direction.magnitude > attackRange) {
//					m_actionHandler.Chase ();
//				} else {	//attack
//					m_actionHandler.Attack ();
//				}
//			}
		} else { //play dead
			ai.enabled = false;
			m_actionHandler.Die ();
		}
	}


	//Getters and setters
	public SkeletonAnimationHandler AnimHandler {
		get { return this.m_animHandler; }
	}

	public GameObject Target {
		get { return target; }
		set { this.target = value; }
	}

	public float AttackRange {
		get{ return attackRange; }
	}

	public bool IsDead {
		get{ return isDead; }
		set{ isDead = value; }
	}

	public SkeletonActionHandler ActionHandler {
		get { return m_actionHandler; }
	}

	public GameObject SoP {
		get{ return sop; }
	}

	public StaffControl Staff {
		get{ return staff; }
	}

	public AIRig AI {
		get{ return ai; }
	}

	public List<GameObject> FootmenList {
		get { return footmenList; }
	}

}
