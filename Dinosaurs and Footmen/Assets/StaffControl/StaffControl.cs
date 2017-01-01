using UnityEngine;
using System.Collections;

public class StaffControl : MonoBehaviour {

	public Vector3[] startPositions;	//array of possible starting positions of the staff of pain
	
	private Vector3 defaultPosition = new Vector3(271, 16, 326);	//just a default position in case no position has been set
	
	// Use this for initialization
	void Start () {
		if(startPositions.Length == 0)
		{
			this.transform.position = defaultPosition;
		}
		else
		{
			this.transform.position = startPositions[Random.Range(0, startPositions.Length)];
		}
		
		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
