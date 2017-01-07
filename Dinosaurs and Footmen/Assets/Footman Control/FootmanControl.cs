using UnityEngine;
using System.Collections;
using RAIN.Core;

public class FootmanControl : MonoBehaviour
{

	//////////////////
	//  ATTRIBUTES  //
	//////////////////

	public GameObject target;
	public bool m_hasSoP = false;
	//boolean indicating if the agent has the Staff of Pain

	public bool skeletonSeen = false;
	// boolean indicating if the footman has ever seen the skeleton
	public float m_rangeView = 20f;
	
	private bool m_isDead = false;
	
	//Handlers
	public FootmanAnimationHandler m_animHandler;
	public FootmanActionHandler m_actionHandler;
	
	
	//objects references
	public GameObject SoP;
	public GameObject skeleton;
	public GameObject bigTree;
	//Note : We do not go directly to the big tree but to a Goal location in front of it
	
	
	public StaffControl staff;
	//used to access staff info
	
	
	// The ai
	public AIRig ai;

	
	///////////////
	//  METHODS  //
	///////////////
	
	// Use this for initialization
	void Start ()
	{
		m_animHandler = GetComponent<FootmanAnimationHandler> ();
		m_actionHandler = GetComponent<FootmanActionHandler> ();
		
		//getting objects references
		SoP = GameObject.FindWithTag ("SoP");
		skeleton = GameObject.FindWithTag ("skeleton");
		bigTree = GameObject.FindWithTag ("bigTree");

		// Get AI
		ai = GetComponentInChildren<AIRig> ();
		
		staff = (StaffControl)SoP.GetComponent (typeof(StaffControl));
		
		//then initialization
		m_actionHandler.NoBehavior ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		
		//On K pressed, kill the footman
		if (!m_isDead && Input.GetKeyDown ("k")) {
			Debug.Log ("DIE !");
			
			m_isDead = true;
		}
		

		if (!m_isDead) {
//			//Debug.Log("Distance : " + Vector3.Distance(this.transform.position, skeleton.transform.position).ToString());
//			//if see skeleton
//			if (Vector3.Distance (this.transform.position, skeleton.transform.position) < m_rangeView) {
//				//if one footmen has the sop
//				if (staff.isPicked ()) {
//					//run away in direction of tree
//					m_actionHandler.RunAway (bigTree);
//				} else {	//no sop
//					m_actionHandler.RunAway (SoP);
//				}
//			} else {	//no skeleton
//				//if one footmen has the sop
//				if (staff.isPicked ()) {
//					//walk to big tree
//					m_actionHandler.Walk (bigTree);
//				} else {	//no sop
//					//if too far away to pick
//					if (Vector3.Distance (this.transform.position, SoP.transform.position) > 3) {
//						m_actionHandler.Walk (SoP);	//move to SoP
//					} else {	//can pick !
//						m_actionHandler.PickSoP ();
//					}
//				}
//			}
		} else { //play dead
			ai.enabled = false;
			m_actionHandler.Die ();
		
		}
	}
	
	
	
	
	
	//Getters
	public FootmanAnimationHandler animHandler ()
	{
		return this.m_animHandler;
	}

	public FootmanActionHandler actionHandler ()
	{
		return this.m_actionHandler;
	}

	public float rangeView ()
	{
		return m_rangeView;
	}

	public bool isDead ()
	{
		return m_isDead;
	}

	public bool hasSoP ()
	{
		return m_hasSoP;
	}
	
	
	//Setters
	public void setDead ()
	{
		this.m_isDead = true;
	}

	public void setTarget (GameObject newtarget)
	{
		this.target = newtarget;
	}

	public void setHasSoP (bool newbool)
	{
		this.m_hasSoP = newbool;
	}
}
