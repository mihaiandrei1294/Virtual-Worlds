using UnityEngine;
using System.Collections;
//using UnitySteer.Behaviors;


//walk to target
public class StartFM : MonoBehaviour {

    //public SteerForPoint steerToSoP;


    public GameObject target;


	private FootmanControl parent; //main script that will have useful variables, used to handle animations
	
	
	private NavMeshAgent agent;
	public float speed = 4f;
	
	// Use this for initialization
	void Start ()
	{
		parent = GetComponent<FootmanControl>();

		target = parent.target;
		
		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		Debug.Log("START FM to " + target.name +" with speed "+ agent.speed.ToString());
		
		agent.SetDestination(target.transform.position);
		
		//play run animation
		parent.WalkAnim();
	}
	
	public void setTarget(GameObject newtarget)
	{
		this.target = newtarget;
	}
}
