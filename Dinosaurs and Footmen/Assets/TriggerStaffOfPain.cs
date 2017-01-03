using UnityEngine;
using System.Collections;

public class TriggerStaffOfPain : MonoBehaviour {

    public GameObject SoPget;
    public GameObject SoPground;
    
    // Use this for initialization
    void Start () {
        SoPget.SetActive(false);
    }
    void OnTriggerEnter(Collider _collider)
    {
        if(_collider.gameObject.tag == "Player")
        {
            SoPget.SetActive(true);
            SoPground.SetActive(false);
        }
    }
}
