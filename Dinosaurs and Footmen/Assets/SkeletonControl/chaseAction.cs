using UnityEngine;
using System.Collections;

public class chaseAction : MonoBehaviour 
{

	private GameObject target;
	private Transform targetpos;
	private Animator anim;

	
	//some private variable about animation boolean names
	private string idle = "isStanding";
	private string run = "isRunning";
	private string attack = "isAttacking";
	
	
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator>();
		target = this.GetComponent<tempSkelControl>().target;
		targetpos = target.transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//Rotate towards the target
		Vector3 direction = targetpos.position - this.transform.position;
		direction.y = 0;
		
		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 1f);
		
		anim.SetBool(idle, false);
		
		this.transform.Translate(0,0, 0.3f);
		anim.SetBool(run, true);
		anim.SetBool(attack, false);


	}
}

// NOTE FOR LATER : THE COLLIDER NEEDS TO HAVE 'IS TRIGGER' ON