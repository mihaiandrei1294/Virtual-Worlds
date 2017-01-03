using UnityEngine;
using System.Collections;

public class StaffControl : MonoBehaviour {

	public Vector3[] startPositions;	//array of possible starting positions of the staff of pain
	
	private Vector3 defaultPosition = new Vector3(250, 0, 149); //just a default position in case no position has been set
    private int grabbed = 0;
    private string player = "";
	
	// Use this for initialization
	void Start () {
		if(startPositions.Length == 0)
		{
			this.transform.position = defaultPosition;
		}
		else
        {
            //this.transform.position = startPositions[Random.Range(0, startPositions.Length)];
            this.transform.position = defaultPosition;
        }



    }
	
	// Update is called once per frame
	void Update () {
	    /*if (grabbed == 1 && player != "")
        {
            this.transform.position = GameObject.Find(player).transform.position;
        }*/
	}
	/*
    void OnTriggerEnter(Collider _collider)
    {
        Debug.Log("TRIGGER before");
        if (_collider.gameObject.tag == "footman" && grabbed == 0) {
            Debug.Log("TRIGGER");
            var sopObj = GameObject.Find("StaffOfPain");
            grabbed = 1;
            if (_collider.gameObject.name == "Yellow_Footman_1")
            {
                player = "Yellow_Footman_1";
                this.setSOPtoTrue();
            }
            if (_collider.gameObject.name == "Yellow_Footman_2")
            {
                player = "Yellow_Footman_2";
                this.setSOPtoTrue();
            }
            if (_collider.gameObject.name == "Yellow_Footman_3")
            {
                player = "Yellow_Footman_3";
                this.setSOPtoTrue();
            }
            if (_collider.gameObject.name == "Yellow_Footman_4")
            {
                player = "Yellow_Footman_4";
                this.setSOPtoTrue();
            }
            if (_collider.gameObject.name == "Red_Footman")
            {
                player = "Red_Footman";
                this.setSOPtoTrue();
            }
        }
        
    }

    void PlayerDead(string name)
    {
        this.GetComponent<CapsuleCollider>().enabled = true;
        grabbed = 0;
        player = "";
        this.setSOPtoFalse();
    }

    void setSOPtoTrue()
    {
        if (GameObject.Find("Yellow_Footman_1").GetComponent<Animator>().GetBool("Killed") == false)
        {
            GameObject.Find("Yellow_Footman_1").GetComponent<Animator>().SetBool("SoP", true);
        }
        if (GameObject.Find("Yellow_Footman_2").GetComponent<Animator>().GetBool("Killed") == false)
        {
            GameObject.Find("Yellow_Footman_2").GetComponent<Animator>().SetBool("SoP", true);
        }
        if (GameObject.Find("Yellow_Footman_3").GetComponent<Animator>().GetBool("Killed") == false)
        {
            GameObject.Find("Yellow_Footman_3").GetComponent<Animator>().SetBool("SoP", true);
        }
        if (GameObject.Find("Yellow_Footman_4").GetComponent<Animator>().GetBool("Killed") == false)
        {
            GameObject.Find("Yellow_Footman_4").GetComponent<Animator>().SetBool("SoP", true);
        }
        if (GameObject.Find("Red_Footman").GetComponent<Animator>().GetBool("Killed") == false)
        {
            GameObject.Find("Red_Footman").GetComponent<Animator>().SetBool("SoP", true);
        }
    }

    void setSOPtoFalse()
    {
        if (GameObject.Find("Yellow_Footman_1").GetComponent<Animator>().GetBool("Killed") == false)
        {
            GameObject.Find("Yellow_Footman_1").GetComponent<Animator>().SetBool("SoP", false);
        }
        if (GameObject.Find("Yellow_Footman_2").GetComponent<Animator>().GetBool("Killed") == false)
        {
            GameObject.Find("Yellow_Footman_2").GetComponent<Animator>().SetBool("SoP", false);
        }
        if (GameObject.Find("Yellow_Footman_3").GetComponent<Animator>().GetBool("Killed") == false)
        {
            GameObject.Find("Yellow_Footman_3").GetComponent<Animator>().SetBool("SoP", false);
        }
        if (GameObject.Find("Yellow_Footman_4").GetComponent<Animator>().GetBool("Killed") == false)
        {
            GameObject.Find("Yellow_Footman_4").GetComponent<Animator>().SetBool("SoP", false);
        }
        if (GameObject.Find("Red_Footman").GetComponent<Animator>().GetBool("Killed") == false)
        {
            GameObject.Find("Red_Footman").GetComponent<Animator>().SetBool("SoP", false);
        }
    }
	*/
}
