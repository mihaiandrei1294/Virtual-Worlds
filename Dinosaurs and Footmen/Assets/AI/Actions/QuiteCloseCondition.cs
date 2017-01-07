using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class QuiteCloseCondition : RAINAction
{
	private GameObject skeleton;
	private SkelControl control;

	public override void Start (RAIN.Core.AI ai)
	{
		skeleton = GameObject.FindGameObjectWithTag ("skeleton");
		control = skeleton.GetComponent < SkelControl> ();
		base.Start (ai);
	}

	public override ActionResult Execute (RAIN.Core.AI ai)
	{
		if (control.target != null) {
			if (Vector3.Distance (control.target.transform.position, skeleton.transform.position) < 20) {
				return ActionResult.SUCCESS;
			}
		}
		return ActionResult.FAILURE;
	}

	public override void Stop (RAIN.Core.AI ai)
	{
		base.Stop (ai);
	}
}