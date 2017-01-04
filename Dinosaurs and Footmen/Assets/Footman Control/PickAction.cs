using UnityEngine;
using System.Collections;

public class PickAction : MonoBehaviour {

	private GameObject SoP;
	private StaffControl staff;	//used to access staff info
	
	
	// Use this for initialization
	void Start () {
		SoP = GameObject.FindWithTag("SoP");
		staff = (StaffControl) SoP.GetComponent(typeof(StaffControl));
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!staff.isPicked())	//if we can pick it
		{
			staff.attachTo(gameObject);
		}
	}
}
