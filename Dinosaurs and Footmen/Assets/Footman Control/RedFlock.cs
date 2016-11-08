using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class RedFlock : MonoBehaviour {

	public playerControl control;
	public SteerForPoint steerForPoint;
	public Biped biped;

	// Use this for initialization
	void Start () {
		biped = GetComponent<Biped> ();
		biped.enabled = true;
		biped.MaxSpeed = 2.5f;

		steerForPoint = GetComponent<SteerForPoint> ();
		steerForPoint.enabled = true;

		steerForPoint.TargetPoint = new Vector3(330, 0, 156); //z changed from 88 to 107

		control.Walk ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
