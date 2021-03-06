using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class SkeletonAliveCondition : RAINAction
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
		if (!control.Skeleton.GetComponent<SkelControl> ().IsDead)
			return ActionResult.SUCCESS;
		return ActionResult.FAILURE;
	}

	public override void Stop (RAIN.Core.AI ai)
	{
		base.Stop (ai);
	}
}