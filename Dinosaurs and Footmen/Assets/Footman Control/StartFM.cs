using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class StartFM : MonoBehaviour {

    public SteerForPoint steerToSoP;


    // Use this for initialization
    void Start()
    {
        steerToSoP = GetComponent<SteerForPoint>();
        steerToSoP.TargetPoint = GameObject.Find("StaffOfPain").transform.position;
        steerToSoP.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartWalking()
    {
        steerToSoP.TargetPoint = GameObject.Find("StaffOfPain").transform.position;
        steerToSoP.enabled = true;
    }
}
