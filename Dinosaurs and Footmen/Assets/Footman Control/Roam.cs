using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class Roam : MonoBehaviour {

	public playerControl control;
	public SteerForPoint steerForPoint;

	// Use this for initialization
	void Start () {

		Debug.Log ("Initial point: x - " + GetComponent<Transform> ().position.x + ", y - " + GetComponent<Transform> ().position.y + ", z - " + GetComponent<Transform> ().position.z);
		steerForPoint.TargetPoint.Set(steerForPoint.TargetPoint.x, steerForPoint.TargetPoint.y, -8);
		steerForPoint = GetComponent<SteerForPoint>();
		steerForPoint.TargetPoint = GetComponent<Transform> ().position;
		steerForPoint.TargetPoint.Set(steerForPoint.TargetPoint.x, steerForPoint.TargetPoint.y, -8);
		steerForPoint.enabled = true;


	}

	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (steerForPoint.TargetPoint, transform.position) < 0.5f) {
			//control.Idle ();
			steerForPoint.TargetPoint = generateRandomTargetPoint(new Vector2(-20.0f, 20.0f),new Vector2(-20.0f, 20.0f));
		} else {
			control.Walk ();
		}


	}


	// Generates a random point for in some boundaries, for the random roaming
	private Vector3 generateRandomTargetPoint(Vector2 rangeX, Vector2 rangeZ){
		float x = Random.Range (-20.0f, 20.0f);
		float y = 2.76f; // constant because footmen don't fly
		float z = Random.Range(-20.0f, 20.0f);

		return new Vector3 (x, y, z);
	}

}
