using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class WalkAction : RAINAction
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
		control.m_actionHandler.Walk ();
		return ActionResult.SUCCESS;
	}

	public override void Stop (RAIN.Core.AI ai)
	{
		base.Stop (ai);
	}
}