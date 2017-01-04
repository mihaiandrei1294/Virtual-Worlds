using UnityEngine;
using System.Collections;
//using UnitySteer.Behaviors;


//walk to target
public class StartFM : MonoBehaviour {

    //public SteerForPoint steerToSoP;

	private FootmanControl parent; //main script that will have useful variables, used to handle animations
	
	
	private NavMeshAgent agent;
	public float speed = 4f;
	
	// Use this for initialization
	void Start ()
	{
		parent = GetComponent<FootmanControl>();
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Debug.Log("START FM to " + target.transform.position.ToString() +" with speed "+ agent.speed.ToString());
		
		agent.SetDestination(parent.target.transform.position);
		//agent.Resume();
		//play run animation
		parent.WalkAnim();
	}
	
	
}
