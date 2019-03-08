using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour {

    private Animator Door;
    //public Animator door3;
    public GameObject door;
    public GameObject door2;

    // Use this for initialization
    void Start () {
        Door = GameObject.Find("Door").GetComponent<Animator>();
        //door3 = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        Door.SetBool("Open", true);
        //door3.SetBool("Open", true);
        //door.SetActive(true);
        //door2.SetActive(true);
    }
    void OnTriggerExit2D()
    {
        Door.SetBool("Open", false);
        //door3.SetBool("Open", true);
        //door.SetActive(true);
        //door2.SetActive(true);
    }


}
