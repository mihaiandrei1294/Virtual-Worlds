using UnityEngine;
using System.Collections;

/*
This is the Attack Action of the Skeleton. This action has to be actived
ONLY when the skeleton is in range of a footman. This action performs an attack.
*/

public class attackAction : MonoBehaviour
{


	private bool hasHit = false;
	
	
	private SkelControl parent;
	//main script that will have useful variables, used to handle animations
	
	
	
	// Use this for initialization
	void Start ()
	{
		parent = GetComponent<SkelControl> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		AnimatorStateInfo currState = parent.AnimHandler.anim ().GetCurrentAnimatorStateInfo (0);
		
		float animDuration = currState.normalizedTime % 1;
		
		
		if (!currState.IsName ("Base.Attack")) {
			parent.AnimHandler.AttackAnim ();
			hasHit = false;
		}
		
		//Debug.Log(animDuration);
		
		
		if (!hasHit && animDuration > 0.35f && animDuration < 0.55f && !parent.AnimHandler.anim ().IsInTransition (0)) {
			hasHit = true;

			GameObject footman = parent.Target;
			//Debug.Log("ON VA TUER "+ footman.name);
			FootmanControl footControl = (FootmanControl)footman.GetComponent<FootmanControl> ();
			footControl.ActionHandler.Die ();
			
			//remove it from the list
			parent.FootmenList.Remove (footman);
			parent.Target = null;

			
		} else if (hasHit && animDuration > 0.55f) {
			hasHit = false;
		}
	}
}
