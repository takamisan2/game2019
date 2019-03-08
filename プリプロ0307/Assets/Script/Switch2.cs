using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch2 : MonoBehaviour {

    private Animator DoorAnimator;
    private BoxCollider2D door;

	// Use this for initialization
	void Start () {
        DoorAnimator = GameObject.Find("redDoorDemo_0").GetComponent<Animator>();
        door = GameObject.Find("redDoorDemo_0").GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay2D(Collider2D other)
    {
        door.enabled = false;
        DoorAnimator.SetBool("Open", true);
        //Door.SetActive(false);
        //Door.transform.Translate(new Vector3(0, 0.1f, 0));
    }
    void OnTriggerExit2D()
    {
        door.enabled = true;
        DoorAnimator.SetBool("Open", false);
        // Door.SetActive(true);
        //Door.transform.Translate(new Vector3(0, -0.1f, 0));
    }

}
