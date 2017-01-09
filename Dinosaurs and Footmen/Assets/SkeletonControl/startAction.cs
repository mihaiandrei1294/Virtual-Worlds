using UnityEngine;
using System.Collections;


//smell FM smells -> move towards them (FM = red FM??)
//FM = red FM for now

public class startAction : MonoBehaviour
{

	private SkelControl parent;
	//main script that will have useful variables
	//private SkeletonAnimationHandler anim; //script used to handle animations
	
	
	private NavMeshAgent agent;
	public float speed = 0.2f;
	
	// Use this for initialization
	void Start ()
	{
		//anim = GetComponent<SkeletonAnimationHandler>();
		parent = GetComponent<SkelControl> ();
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		agent.SetDestination (parent.Target.transform.position);
		
		//play run animation
		parent.AnimHandler.WalkAnim ();
	}
}
