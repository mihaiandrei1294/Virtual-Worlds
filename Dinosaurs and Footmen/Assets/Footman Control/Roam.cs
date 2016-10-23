using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class Roam : MonoBehaviour {

	public playerControl control;
	public SteerForPoint steerForPoint;

	// Use this for initialization
	void Start () {

		steerForPoint = GetComponent<SteerForPoint>();
		steerForPoint.TargetPoint = generateRandomTargetPoint();
		steerForPoint.enabled = true;


	}

	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (steerForPoint.TargetPoint, transform.position) < 0.5f) {
			control.Idle ();
			//steerForPoint.TargetPoint = generateRandomTargetPoint();
		} else {
			control.Walk ();
		}


	}


	// Generates a random point for in some boundaries, for the random roaming
	private Vector3 generateRandomTargetPoint(){
		float x = Random.Range (-20.0f, 20.0f);
		float y = 2.76f; // constant because footmen don't fly
		float z = Random.Range(-20.0f, 20.0f);

		return new Vector3 (x, y, z);
	}

}
