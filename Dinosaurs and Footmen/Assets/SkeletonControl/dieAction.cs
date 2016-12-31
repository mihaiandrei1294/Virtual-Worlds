using UnityEngine;
using System.Collections;

public class dieAction : MonoBehaviour {

	private tempSkelControl parent; //main script that will have useful variables, used to handle animations


	// Use this for initialization
	void Start ()
	{
		parent = GetComponent<tempSkelControl>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
			parent.DieAnim();
	
	}
}
