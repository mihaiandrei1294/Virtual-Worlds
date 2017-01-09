using UnityEngine;
using System.Collections;

public class FleeAction : MonoBehaviour
{

	private FootmanControl parent;
	//main script that will have useful variables, used to handle animations
	private GameObject skeleton;
	
	private NavMeshAgent agent;
	public float speed = 6f;

	// Use this for initialization
	void Start ()
	{
		parent = GetComponent<FootmanControl> ();
		agent = GetComponent<NavMeshAgent> ();
		skeleton = GameObject.FindWithTag ("skeleton");
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 fleeVector = this.transform.position - skeleton.transform.position;	//= - (skelPos - footPos)
//		Debug.Log ("flee vector scaling is: " + (1 + parent.rangeView () - Vector3.Distance (this.transform.position, skeleton.transform.position)));
		float scale = (1 + parent.rangeView () - Vector3.Distance (this.transform.position, skeleton.transform.position));
		if (scale < 0)
			scale = 0;
//		float dist = Vector3.Distance (this.transform.position, skeleton.transform.position);
//		float scale = (parent.rangeView () + 5) / dist;
		fleeVector = fleeVector * scale;	//the closer the skeleton, the more we run away and forget about our target
		
		Vector3 targetVector = parent.target.transform.position - this.transform.position;


		float dist2 = Vector3.Distance (this.transform.position, parent.target.transform.position);
//		float scale2 = parent.rangeView () - dist2;
//		if (dist2 < 10)
//			fleeVector = fleeVector * 0;
//
//		targetVector = targetVector * scale2;

		Vector3 fleePoint = gameObject.transform.position + fleeVector + targetVector;		// = footPos + fleeVector
		
		//This fleePoint can be on an obstacle. This can causes lag for SetDestination method to finish as it takes time to figure out a path is impossible.
		//In order to solve that, we first do a RayCast to the target and 
		bool blocked = false;
		NavMeshHit hit;
		
		int numBlock = 1;
		
		do {
			numBlock++;
			blocked = NavMesh.Raycast (fleePoint - new Vector3 (5f, 0f, 5f), fleePoint, out hit, NavMesh.AllAreas);
//			Debug.DrawLine (gameObject.transform.position, fleePoint, blocked ? Color.red : Color.green);
			if (blocked) {
//				Debug.DrawRay (hit.position, Vector3.up * 1000, Color.red);
				fleePoint = fleePoint - new Vector3 (5f, 0f, 5f);
			}
//			Debug.Log (hit.position.ToString () + " == " + fleePoint.ToString ());
			
		} while(blocked && numBlock < 4);

//		Debug.Log ("Footman " + this.ToString () + " destination " + fleePoint.ToString () + ". Run from" + skeleton.transform.position.ToString () + ". Run to " + parent.target.transform.position.ToString ());
		Debug.DrawLine (gameObject.transform.position, fleePoint, Color.yellow);
		Debug.DrawLine (gameObject.transform.position, skeleton.transform.position, Color.red);
		Debug.DrawLine (gameObject.transform.position, parent.target.transform.position, Color.green);

		agent.SetDestination (fleePoint);
		//play run animation
		parent.animHandler ().RunAnim ();
	}
}
