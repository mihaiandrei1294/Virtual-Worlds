using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class YellowFollowers : MonoBehaviour {

	public playerControl control;
	public SteerForPoint steerForPoint;
	public Biped biped;
	public SteerForEvasion steerForFear;
	public SteerForAlignment steerForAlignement;
	public SteerForCohesion steerForCohesion;
	public SteerForNeighborGroup steerForNGroup;
	public SteerForSphericalObstacles steerForObstacles;

	// Use this for initialization
	void Start () {
		
		biped = GetComponent<Biped> ();
		biped.enabled = true;
		biped.MaxSpeed = 2.5f;

		steerForFear = GetComponent<SteerForEvasion> ();
		steerForFear.enabled = false;


		steerForPoint = GetComponent<SteerForPoint> ();
		steerForPoint.enabled = true;

		steerForCohesion = GetComponent<SteerForCohesion> ();
		steerForCohesion.enabled = true;



		steerForObstacles = GetComponent<SteerForSphericalObstacles> ();
		steerForObstacles.enabled = true;

		steerForAlignement = GetComponent<SteerForAlignment> ();
		steerForAlignement.enabled = true;

		steerForNGroup = GetComponent<SteerForNeighborGroup> ();
		steerForNGroup.enabled = true;

		steerForPoint.TargetPoint = new Vector3(215, 0, 107); //z changed from 88 to 107
		control.Walk ();

		
	}
	
	// Update is called once per frame
	void Update () {

		//if (steerForCohesion.enabled == false) {
			//steerForCohesion.enabled = true;
			//Debug.Log ("Changed steer for choesion!");
		//}

		if (Vector3.Distance (steerForPoint.TargetPoint, transform.position) < 1f) {
			steerForPoint.TargetPoint = generateRandomTargetPoint (new Vector2 (160.0f, 280.0f), new Vector2 (180.0f, 200.0f));

			control.Run ();
			biped.MaxSpeed = 6;


		}
	}

	// Generates a random point for in some boundaries, for the random roaming
	private Vector3 generateRandomTargetPoint(Vector2 rangeX, Vector2 rangeZ){
		float x = Random.Range (rangeX.x, rangeX.y);
		float y = 0; // constant because footmen don't fly
		float z = Random.Range(rangeZ.x, rangeZ.y);

		return new Vector3 (x, y, z);
	}
}
