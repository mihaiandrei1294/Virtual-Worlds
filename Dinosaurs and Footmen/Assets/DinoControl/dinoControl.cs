using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class dinoControl : MonoBehaviour
{

    public playerControl control;
    public SteerForPoint cSteering;
    public Animator animator;
	public SteerToFollow csFollow;
	public Biped biped;
    // Use this for initialization
    void Start()
    {
        cSteering = GetComponent<SteerForPoint>();
        animator = GetComponent<Animator>();
		csFollow = GetComponent<SteerToFollow> ();
		biped = GetComponent<Biped> ();
		biped.enabled = true;
        //the steering is enabled
        cSteering.enabled = true;
		csFollow.enabled = false;
		cSteering.TargetPoint = new Vector3 (210, 0, 72);

		Walk ();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 robotCurrPos;
        Vector3 robotTargetPos = new Vector3();
        cSteering.enabled = true;
        robotCurrPos = transform.position;

        robotTargetPos = cSteering.TargetPoint;

        if (Vector3.Distance(robotCurrPos, robotTargetPos) < 1.0)
        {
            //Debug.Log("STOP, disable steering. Transition to idle");
            cSteering.enabled = false;
			csFollow.enabled = true;
            //cSteering.TargetPoint = generateRandomTargetPoint(new Vector2(160.0f, 280.0f), new Vector2(180.0f, 200.0f));
			biped.MaxSpeed = 5.5f;
			Run();
        }
        else
        {
            //Debug.Log("current position: " + robotCurrPos + "  target:  " + robotTargetPos + "\n");
        }
    }
    // Generates a random point for in some boundaries, for the random roaming
    private Vector3 generateRandomTargetPoint(Vector2 rangeX, Vector2 rangeZ)
    {
        float x = Random.Range(rangeX.x, rangeX.y);
        float y = 0; // constant because footmen don't fly
        float z = Random.Range(rangeZ.x, rangeZ.y);

        return new Vector3(x, y, z);
    }

	// Copied this from the pre-existing player constrol since it seems to be more clean and easier to use animation transitions
	// Just call the respective function and the animation will change

	int idle;
	int run;
	int walk;

	void Awake ()
	{
		//anim = GetComponent<Animator>();
		idle = Animator.StringToHash ("idle");
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
	}

	public void Walk ()
	{
		animator.SetTrigger(walk);
	}
}
