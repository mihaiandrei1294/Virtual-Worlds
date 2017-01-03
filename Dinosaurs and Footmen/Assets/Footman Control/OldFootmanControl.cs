using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class OldFootmanControl : MonoBehaviour {


/*
    //
    public Animator control;
    public Biped biped;
    
    public SteerForAlignment steerForAlignement;
    public SteerForCohesion steerForCohesion;
    public SteerForNeighborGroup steerForNGroup;
    public SteerForSphericalObstacles steerForObstacles;
    

    // scripts
    private StartFM startFM;
    private PickAction pickSoP;
    private WalkBackAction walkBackFM;

    //
    private Vector3 actualPosition;
    private Vector3 sopPosition;


    // Use this for initialization
    void Start () {
        biped = GetComponent<Biped>();
        biped.enabled = true;
        biped.MaxSpeed = 2.5f;


        
        //footmen group initialization
        steerForCohesion = GetComponent<SteerForCohesion>();
        steerForCohesion.enabled = false;

        steerForObstacles = GetComponent<SteerForSphericalObstacles>();
        steerForObstacles.enabled = true;

        steerForAlignement = GetComponent<SteerForAlignment>();
        steerForAlignement.enabled = false;

        steerForNGroup = GetComponent<SteerForNeighborGroup>();
        steerForNGroup.enabled = true;
        

        walkBackFM = GetComponent<WalkBackAction>();
        startFM = GetComponent<StartFM>();
        
        //controller initialization
        control = GetComponent<Animator>();
        control.SetBool("SoP", false);
        control.SetBool("SkeletonSeen", false);
        control.SetBool("BigTreeReached", false);
        control.SetBool("Killed", false);
    }
	
	// Update is called once per frame
	void Update ()
    {

        /*
        Debug.Log("SOP:");
        Debug.Log(control.GetBool("SoP"));
        Debug.Log("SkeletonSeen:");
        Debug.Log(control.GetBool("SkeletonSeen"));
        Debug.Log("BigTreeReached:");
        Debug.Log(control.GetBool("BigTreeReached"));
        Debug.Log("BigTreeReached:");
        Debug.Log(control.GetBool("BigTreeReached"));
        
        actualPosition = this.transform.position;

        if (control.GetBool("SoP") == false && 
            control.GetBool("Killed") == false) {
            startFM.StartWalking();
        }



        if (control.GetBool("SoP") == true &&
            control.GetBool("BigTreeReached") == false &&
            control.GetBool("Killed") == false)
        {
            walkBackFM.Walking();
        }

        //Skeleton seen seen

        if (Input.anyKeyDown)
        {
            Debug.Log("H pressed");
            setSkeletonSeen();
        }

        

    }


    void setSkeletonSeen()
    {
        if (GameObject.Find("Yellow_Footman_1").GetComponent<Animator>().GetBool("Killed") == false)
        {
            GameObject.Find("Yellow_Footman_1").GetComponent<Animator>().SetBool("SkeletonSeen", true);
        }
        if (GameObject.Find("Yellow_Footman_2").GetComponent<Animator>().GetBool("Killed") == false)
        {
            GameObject.Find("Yellow_Footman_2").GetComponent<Animator>().SetBool("SkeletonSeen", true);
        }
        if (GameObject.Find("Yellow_Footman_3").GetComponent<Animator>().GetBool("Killed") == false)
        {
            GameObject.Find("Yellow_Footman_3").GetComponent<Animator>().SetBool("SkeletonSeen", true);
        }
        if (GameObject.Find("Yellow_Footman_4").GetComponent<Animator>().GetBool("Killed") == false)
        {
            GameObject.Find("Yellow_Footman_4").GetComponent<Animator>().SetBool("SkeletonSeen", true);
        }
        if (GameObject.Find("Red_Footman").GetComponent<Animator>().GetBool("Killed") == false)
        {
            GameObject.Find("Red_Footman").GetComponent<Animator>().SetBool("SkeletonSeen", true);
        }
    }
	*/
}
