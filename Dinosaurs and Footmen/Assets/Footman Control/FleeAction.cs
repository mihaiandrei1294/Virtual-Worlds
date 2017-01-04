using UnityEngine;
using System.Collections;

public class FleeAction : MonoBehaviour {

	private FootmanControl parent; //main script that will have useful variables, used to handle animations
	private GameObject skeleton;
	
	private NavMeshAgent agent;
	public float speed = 6f;

	// Use this for initialization
	void Start ()
	{
		parent = GetComponent<FootmanControl>();
		agent = GetComponent<NavMeshAgent>();
		skeleton = GameObject.FindWithTag("skeleton");
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 fleeVector = gameObject.transform.position - skeleton.transform.position;	//= - (skelPos - footPos)
		fleeVector =  fleeVector * (1 + parent.rangeView() - Vector3.Distance(this.transform.position, skeleton.transform.position));	//the closer the skeleton, the more we run away and forget about our target
		
		Vector3 targetVector = parent.target.transform.position - gameObject.transform.position;
		
		Vector3 fleePoint = gameObject.transform.position + fleeVector +targetVector;		// = footPos + fleeVector
		
	
		agent.SetDestination(fleePoint);
		//agent.Resume();
		//play run animation
		parent.RunAnim();
	}
}
