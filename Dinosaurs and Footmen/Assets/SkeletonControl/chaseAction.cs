using UnityEngine;
using System.Collections;

public class chaseAction : MonoBehaviour 
{

	private GameObject target;
	private Transform targetpos;


	private SkelControl parent; //main script that will have useful variables, used to handle animations
	
	
	private NavMeshAgent agent;
	public float speed = 0.5f;
	
	// Use this for initialization
	void Start ()
	{
		parent = GetComponent<SkelControl>();

		target = parent.target;
		targetpos = target.transform;
		
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		agent.SetDestination(targetpos.position);
		
		//play run animation
		parent.RunAnim();


	}
}
