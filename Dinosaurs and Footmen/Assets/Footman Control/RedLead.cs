﻿using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class RedLead : MonoBehaviour {


	public playerControl control;
    public SteerForPoint steerForPoint;
    public SteerForPursuit steerForPursuit;
    public Biped biped;
	public SteerForEvasion steerForFear;
	public SteerForAlignment steerForAlignement;	
	public SteerForCohesion steerForCohesion;
	public SteerForNeighborGroup steerForNGroup;
	public SteerForSphericalObstacles steerForObstacles;
	public SteerForReverseTether steerForReverseTheter;
    public GameObject skeleton;
    public GameObject sop;

    // Use this for initialization
    void Start () {

		steerForReverseTheter = GetComponent<SteerForReverseTether> ();
		steerForReverseTheter.enabled = false;

		biped = GetComponent<Biped> ();
		biped.enabled = true;
		biped.MaxSpeed = 2.5f;

		steerForFear = GetComponent<SteerForEvasion> ();
		steerForFear.enabled = false;


        steerForPoint = GetComponent<SteerForPoint>();
        steerForPoint.enabled = false;


        steerForCohesion = GetComponent<SteerForCohesion> ();
		steerForCohesion.enabled = false;



		steerForObstacles = GetComponent<SteerForSphericalObstacles> ();
		steerForObstacles.enabled = true;

		steerForAlignement = GetComponent<SteerForAlignment> ();
		steerForAlignement.enabled = false;

		steerForNGroup = GetComponent<SteerForNeighborGroup> ();
		steerForNGroup.enabled = true;

        Transform sopTransform = sop.GetComponent<Transform>();
        Vector3 sopPosition = sopTransform.position;
        steerForPoint.TargetPoint = sopPosition; //z changed from 88 to 107
		control.Walk ();


	}

	// Update is called once per frame
	void Update () {


		Transform skeletonTransform = skeleton.GetComponent<Transform> ();
		Vector3 skeletonPosition = skeletonTransform.position;
		steerForReverseTheter.TetherPosition = skeletonPosition;

		if (Vector3.Distance (steerForPoint.TargetPoint, transform.position) < 0.5f) {

			//steerForPoint.TargetPoint = generateRandomTargetPoint (new Vector2 (160.0f, 280.0f), new Vector2 (180.0f, 200.0f));
            steerForPursuit.enabled = false;
			steerForReverseTheter.enabled = true;
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
