using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class YellowFollowers : MonoBehaviour {

	public playerControl control;
	public SteerForPoint steerForPoint;
	public Biped biped;
	public SteerForEvasion steerForFear;
	public SteerForAlignment steerForAlignement;

	// Use this for initialization
	void Start () {
		
		biped = GetComponent<Biped> ();
		biped.enabled = true;
		biped.MaxSpeed = 2.5f;

		steerForAlignement = GetComponent<SteerForAlignment> ();
		steerForAlignement.enabled = true;

		steerForFear = GetComponent<SteerForEvasion> ();
		steerForFear.enabled = false;

		steerForPoint = GetComponent<SteerForPoint> ();
		steerForPoint.enabled = false;

		control.Walk ();

		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
