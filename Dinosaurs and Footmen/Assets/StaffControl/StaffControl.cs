using UnityEngine;
using System.Collections;

public class StaffControl : MonoBehaviour
{

	public Vector3[] startPositions;
	//array of possible starting positions of the staff of pain
	
	private Vector3 defaultPosition = new Vector3 (250, 0, 149);
	//just a default position in case no position has been set
    
	public bool m_isPicked = false;
	private Vector3 m_offset = new Vector3 (0, 1.3f, 0.5f);
	
	
	public GameObject holder;
	//reference of the object that holds the staff (null by default)
	
	private GameObject skeleton;
	private SkelControl skelControl;
	//used to access staff info
	
	
	//components
	private CapsuleCollider m_collider;
	
	
	
	// Use this for initialization
	void Start ()
	{
		
		m_collider = GetComponent<CapsuleCollider> ();
		skeleton = GameObject.FindWithTag ("skeleton");
		skelControl = (SkelControl)skeleton.GetComponent (typeof(SkelControl));
		
		
		if (startPositions.Length == 0) {
			this.transform.position = defaultPosition;
		} else {
			this.transform.position = startPositions[Random.Range(0, startPositions.Length)];

		}

		
		holder = null;

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (holder != null) {
			this.transform.position = holder.transform.position + m_offset;
			
			float rotY = holder.transform.eulerAngles.y;
			//Debug.Log(holder.transform.eulerAngles.ToString());
			this.transform.eulerAngles = new Vector3 (-90, 360 - rotY, 0);
		} else {
			if (transform.position.y < 0)
				this.transform.position = new Vector3 (transform.position.x, 5f, transform.position.z);	//to avoid falling under the ground
		}
	}
	
	//attach the staff to an object
	public void attachTo (GameObject fromObject)
	{
		m_isPicked = true;
		holder = fromObject;
		m_collider.enabled = false;
		
		//Enrage the skeleton to the holder
		skelControl.Target = holder;
	}
	
	//drop the staff on the ground
	public void drop ()
	{
		m_isPicked = false;
		holder = null;
		m_collider.enabled = true;
		
		
	}

	
	public bool isPicked ()
	{
		return m_isPicked;
	}


	private Vector3 generateRandomPoint (int x1, int x2, int z1, int z2)
	{
		float x = Random.Range (x1, x2);
		float y = 0f;
		float z = Random.Range (z1, z2);

		return new Vector3 (x, y, z);
	}

}
