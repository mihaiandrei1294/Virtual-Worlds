using UnityEngine;
using System.Collections;

public class chaseAction : MonoBehaviour 
{

	private SkelControl parent; //main script that will have useful variables, used to handle animations
	
	
	private NavMeshAgent agent;
	public float speed = 0.5f;
	
	// Use this for initialization
	void Start ()
	{
		parent = GetComponent<SkelControl>();

		
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log("CHASE");
		agent.SetDestination(parent.target.transform.position);
		
		//play run animation
		parent.RunAnim();


	}
}
