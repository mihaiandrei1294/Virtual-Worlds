using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class KillSkeletonAction : RAINAction
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
		control.Skeleton.GetComponent<SkelControl> ().IsDead = true;
		return ActionResult.SUCCESS;
	}

	public override void Stop (RAIN.Core.AI ai)
	{
		base.Stop (ai);
	}
}