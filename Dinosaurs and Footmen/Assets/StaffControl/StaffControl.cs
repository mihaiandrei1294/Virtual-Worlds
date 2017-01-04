using UnityEngine;
using System.Collections;

public class StaffControl : MonoBehaviour {

	public Vector3[] startPositions;	//array of possible starting positions of the staff of pain
	
	private Vector3 defaultPosition = new Vector3(250, 0, 149); //just a default position in case no position has been set
    public bool m_isPicked = false;
    private string player = "";
	
	public GameObject holder;	//reference of the object that holds the staff (null by default)
	
	//components
	private CapsuleCollider m_collider;
	
	private Vector3 m_offset = new Vector3(0,1.3f,0.5f);
	
	// Use this for initialization
	void Start () {
		
		m_collider = GetComponent<CapsuleCollider>();
		
		if(startPositions.Length == 0)
		{
			//this.transform.position = defaultPosition;
		}
		else
        {
            //this.transform.position = startPositions[Random.Range(0, startPositions.Length)];
            this.transform.position = defaultPosition;
        }

		
		holder = null;

    }
	
	// Update is called once per frame
	void Update () {
	    if(holder != null)
		{
			this.transform.position = holder.transform.position + m_offset;
			
			float rotY = holder.transform.eulerAngles.y;
			//Debug.Log(holder.transform.eulerAngles.ToString());
			this.transform.eulerAngles = new Vector3(-90, 360-rotY, 0);
		}
	}
	
	//attach the staff to an object
	public void attachTo(GameObject fromObject)	
	{
		m_isPicked = true;
		holder = fromObject;
		m_collider.enabled = false;
	}
	
	//drop the staff on the ground
	public void drop()	
	{
		m_isPicked = false;
		holder = null;
		m_collider.enabled = true;
	}

	
	public bool isPicked()
	{
		return m_isPicked;
	}
	

}
