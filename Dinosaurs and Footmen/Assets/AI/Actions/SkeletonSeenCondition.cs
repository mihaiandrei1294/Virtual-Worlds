using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class SkeletonSeenCondition : RAINAction
{
	private GameObject footman;
	private FootmanControl control;

	public override void Start (RAIN.Core.AI ai)
	{
		footman = ai.Body;
		control = footman.GetComponent<FootmanControl> ();
		base.Start (ai);
	}

	public override ActionResult Execute (RAIN.Core.AI ai)
	{
		if (control.SkeletonSeen)
			return ActionResult.SUCCESS;
		if (Vector3.Distance (footman.transform.position, control.Skeleton.transform.position) <= control.RangeView) {
			control.SkeletonSeen = true;
			return ActionResult.SUCCESS;
		}
		return ActionResult.FAILURE;
	}

	public override void Stop (RAIN.Core.AI ai)
	{
		base.Stop (ai);
	}
}