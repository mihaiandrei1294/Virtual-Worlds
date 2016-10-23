using UnityEngine;
using System.Collections;
using UnitySteer.Behaviors;

public class playerControl : MonoBehaviour 
{
	public Animator anim;
	int attack01;
	int attack02;
	int attack03;
	int battleWalkBackward;
	int battleWalkForward;
	int battleWalkLeft;
	int battleWalkRight;
	int defend;
	int die;
	int getHit;
	int idle02;
	int jump;
	int walk;
	int taunt;
	int run;
	int idle;

	public SteerForPoint steerForPoint; 


		// Use this for initialization
		void Start () {
		steerForPoint = GetComponent<SteerForPoint>();
		steerForPoint.TargetPoint = generateRandomTargetPoint();
		steerForPoint.enabled = true;


		}

		// Update is called once per frame
		void Update () {

		if (Vector3.Distance (steerForPoint.TargetPoint, transform.position) < 0.5f) {
			//Idle ();
			steerForPoint.TargetPoint = generateRandomTargetPoint();
		} else {
			Walk ();
		}


		}

	// Generates a random point for in some boundaries, for the random roaming
	private Vector3 generateRandomTargetPoint(){
		float x = Random.Range (-50.0f, 50.0f);
		float y = 2.76f; // constant because footmen don't fly
		float z = Random.Range(-50.0f, 50.0f);

		return new Vector3 (x, y, z);
	}

	void Awake () 
	{
		anim = GetComponent<Animator>();
		attack01 = Animator.StringToHash("attack_01");
		attack02 = Animator.StringToHash("attack_02");
		attack03 = Animator.StringToHash("attack_03");
		battleWalkBackward = Animator.StringToHash("walkBattleBackward");
		battleWalkForward = Animator.StringToHash("walkBattleForward");
		battleWalkLeft = Animator.StringToHash("walkBattleLeft");
		battleWalkRight = Animator.StringToHash("walkBattleRight");
		defend = Animator.StringToHash("defend");
		die = Animator.StringToHash("die");
		getHit = Animator.StringToHash("getHit");
		idle02 = Animator.StringToHash("idle_02");
		jump = Animator.StringToHash("jump");
		walk = Animator.StringToHash("walk");
		taunt = Animator.StringToHash("taunt");
		run = Animator.StringToHash("run");
		idle = Animator.StringToHash ("idle");
	}
	
	public void Idle ()
	{
		anim.SetTrigger(idle);
	}


	public void Attack01 ()
	{
		anim.SetTrigger(attack01);
	}

	public void Attack02 ()
	{
		anim.SetTrigger(attack02);
	}

	public void Attack03 ()
	{
		anim.SetTrigger(attack03);
	}

	public void BattleWalkBackward ()
	{
		anim.SetTrigger(battleWalkBackward);
	}

	public void BattleWalkForward ()
	{
		anim.SetTrigger(battleWalkForward);
	}

	public void BattleWalkLeft ()
	{
		anim.SetTrigger(battleWalkLeft);
	}

	public void BattleWalkRight ()
	{
		anim.SetTrigger(battleWalkRight);
	}

	public void Defend ()
	{
		anim.SetTrigger(defend);
	}

	public void Die ()
	{
		anim.SetTrigger(die);
	}

	public void GetHit ()
	{
		anim.SetTrigger(getHit);
	}

	public void Idle02 ()
	{
		anim.SetTrigger(idle02);
	}

	public void Jump ()
	{
		anim.SetTrigger(jump);
	}

	public void Walk ()
	{
		anim.SetTrigger(walk);
	}

	public void Taunt ()
	{
		anim.SetTrigger(taunt);
	}

	public void Run ()
	{
		anim.SetTrigger(run);
	}
	
}
