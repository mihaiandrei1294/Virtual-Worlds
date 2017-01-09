using UnityEngine;
using System.Collections;
using RAIN.Core;

public class FootmanControl : MonoBehaviour
{

	//////////////////
	//  ATTRIBUTES  //
	//////////////////

	public GameObject target;
	private bool m_hasSoP = false;
	//boolean indicating if the agent has the Staff of Pain

	private bool skeletonSeen = false;
	// boolean indicating if the footman has ever seen the skeleton
	private float m_rangeView = 20f;
	
	private bool m_isDead = false;
	
	//Handlers
	private FootmanAnimationHandler m_animHandler;
	private FootmanActionHandler m_actionHandler;
	
	
	//objects references
	private GameObject sop;
	private GameObject skeleton;
	private GameObject bigTree;
	//Note : We do not go directly to the big tree but to a Goal location in front of it
	
	
	private StaffControl staff;
	//used to access staff info
	
	
	// The ai
	private AIRig ai;

	
	///////////////
	//  METHODS  //
	///////////////
	
	// Use this for initialization
	void Start ()
	{
		m_animHandler = GetComponent<FootmanAnimationHandler> ();
		m_actionHandler = GetComponent<FootmanActionHandler> ();
		
		//getting objects references
		sop = GameObject.FindWithTag ("SoP");
		skeleton = GameObject.FindWithTag ("skeleton");
		bigTree = GameObject.FindWithTag ("bigTree");

		// Get AI
		ai = GetComponentInChildren<AIRig> ();
		
		staff = (StaffControl)sop.GetComponent (typeof(StaffControl));
		
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
	
	
	
	
	
	//Getters and Setters
	public FootmanAnimationHandler AnimHandler {
		get { return this.m_animHandler; }
	}

	public FootmanActionHandler ActionHandler {
		get{ return this.m_actionHandler; }
	}

	public float RangeView {
		get { return m_rangeView; }
	}

	public bool IsDead {
		get { return m_isDead; }
		set { this.m_isDead = value; }
	}

	public bool HasSoP {
		get { return m_hasSoP; }
		set { this.m_hasSoP = value; }
	}

	public GameObject Target {
		set { this.target = value; }
	}

	public bool SkeletonSeen {
		get { return skeletonSeen; }
		set { skeletonSeen = value; }
	}

	public GameObject Skeleton {
		get { return skeleton; }
	}

	public GameObject BigTree {
		get { return bigTree; }
	}

	public GameObject SoP {
		get { return sop; }
	}

	public AIRig AI {
		get{ return ai; }
	}

	public StaffControl Staff {
		get { return staff; }
	}
}
