using UnityEngine;
using System.Collections;

public class chaseAction : MonoBehaviour
{

	private SkelControl parent;
	//main script that will have useful variables
	
	private NavMeshAgent agent;
	public float speed = 0.5f;
	
	// Use this for initialization
	void Start ()
	{
		parent = GetComponent<SkelControl> ();
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		agent.SetDestination (parent.Target.transform.position);
		
		//play run animation
		parent.AnimHandler.RunAnim ();


	}
}
