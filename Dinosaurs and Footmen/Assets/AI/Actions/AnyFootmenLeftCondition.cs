using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class AnyFootmenLeftCondition : RAINAction
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
		if (control.footmenList.Count > 0) {
			return ActionResult.SUCCESS;
		}
		return ActionResult.FAILURE;
	}

	public override void Stop (RAIN.Core.AI ai)
	{
		base.Stop (ai);
	}
}