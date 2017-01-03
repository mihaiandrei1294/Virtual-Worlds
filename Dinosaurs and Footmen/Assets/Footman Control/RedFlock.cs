using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class RedFlock : MonoBehaviour {

	public playerControl control;
	public SteerForPoint steerForPoint;
	public Biped biped;
    public GameObject sop;

    // Use this for initialization
    void Start () {
		biped = GetComponent<Biped> ();
		biped.enabled = true;
		biped.MaxSpeed = 2.5f;

		steerForPoint = GetComponent<SteerForPoint> ();
		steerForPoint.enabled = true;

        Transform sopTransform = sop.GetComponent<Transform>();
        Vector3 sopPosition = sopTransform.position;
        steerForPoint.TargetPoint = sopPosition; //z changed from 88 to 107
        control.Walk();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
