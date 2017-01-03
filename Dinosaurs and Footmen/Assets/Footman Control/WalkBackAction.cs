using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class WalkBackAction : MonoBehaviour {

    public SteerForPoint steerToTree;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void Walking()
    {
        steerToTree = GetComponent<SteerForPoint>();
        steerToTree.TargetPoint = GameObject.Find("MotherTree").transform.position;
        steerToTree.enabled = true;
    }

     
}
