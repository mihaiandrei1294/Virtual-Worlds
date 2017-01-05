using UnityEngine;
using System.Collections;

public class dieFootmanAction : MonoBehaviour {

	private FootmanControl parent; //main script that will have useful variables, used to handle animations

	private GameObject SoP;
	private StaffControl staff;	//used to access staff info
	
	// Use this for initialization
	void Start ()
	{
		parent = GetComponent<FootmanControl>();
		
		SoP = GameObject.FindWithTag("SoP");
		staff = (StaffControl) SoP.GetComponent(typeof(StaffControl));
	}
	
	// Update is called once per frame
	void Update ()
	{
		parent.animHandler().DieAnim();
		
		//if has the SoP, drop it
		if(parent.hasSoP())
		{
			parent.setHasSoP(false);
			staff.drop();
		}
		
//}
	}
}
