using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class skeletonControl : MonoBehaviour
{

    public SteerForPoint cSteering;
    public Animator animator;
	public SteerForPursuit csPursuit;
	public Biped biped;
    // Use this for initialization
    void Start()
    {
        cSteering = GetComponent<SteerForPoint>();
        animator = GetComponent<Animator>();
		csPursuit = GetComponent<SteerForPursuit> ();
		biped = GetComponent<Biped> ();

		biped.enabled = true;
        cSteering.enabled = true;

		csPursuit.enabled = false;
		cSteering.TargetPoint = new Vector3 (215, 0, 107); //x changed from 230 to 215

		Walk ();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 skeletonCurrPos;
        Vector3 skeletonTargetPos = new Vector3();
        //cSteering.enabled = true;
        skeletonCurrPos = transform.position;

        skeletonTargetPos = cSteering.TargetPoint;

        //if close to target and not pursuing yet
        if (csPursuit.enabled == false && Vector3.Distance(skeletonCurrPos, skeletonTargetPos) < 1.0)
        {
            //Debug.Log("STOP, disable steering. Transition to idle");

            cSteering.enabled = false;
			csPursuit.enabled = true;
			biped.MaxSpeed = 8.0f;
			Run();
        }
        else
        {
            //Debug.Log("current position: " + skeletonCurrPos + "  target:  " + skeletonTargetPos + "\n");
        }
    }
   

	// Copied this from the pre-existing player constrol since it seems to be more clean and easier to use animation transitions
	// Just call the respective function and the animation will change

	int idle;
	int run;
	int walk;

	void Awake ()
	{
		//anim = GetComponent<Animator>();
		idle = Animator.StringToHash ("stand");
		run = Animator.StringToHash ("run");
		walk = Animator.StringToHash ("walk");
	}

	public void Idle ()
	{
		animator.SetTrigger(idle);
	}

	public void Run ()
	{
		animator.SetTrigger(run);
		animator.SetBool(walk, false);
	}

	public void Walk ()
	{
		animator.SetTrigger(walk);
	}
}
