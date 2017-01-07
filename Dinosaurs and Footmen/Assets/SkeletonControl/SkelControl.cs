using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RAIN.Core;

//dummy behavior controller before having behaviour tree

public class SkelControl : MonoBehaviour
{

	//public attributes
	public GameObject target;
	//current target
	public float attackRange = 4;
	//attack range
	public List<GameObject> footmenList;
	//array of footmen
	
	//Just a variable for making things work, that will be removed with behavior tree
	public bool isDead = false;
	
	//Handlers
	public SkeletonAnimationHandler m_animHandler;
	public SkeletonActionHandler m_actionHandler;
	
	//Object references
	public GameObject SoP;
	public StaffControl staff;
	//used to access staff info
	
	// Changed all attributes to public to be able to acces them from the ai files

	// The ai
	public AIRig ai;


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
		SoP = GameObject.FindWithTag ("SoP");
		staff = (StaffControl)SoP.GetComponent (typeof(StaffControl));
		
		
		
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

	
	public void setTarget (GameObject newtarget)
	{
		this.target = newtarget;
	}
	
	
	//Getters
	public SkeletonAnimationHandler animHandler ()
	{
		return this.m_animHandler;
	}
	
	
	
	
	
	

}
