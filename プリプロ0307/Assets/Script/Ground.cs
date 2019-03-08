using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    private Star star;

	// Use this for initialization
	void Start () {
        star = GameObject.Find("StarPlayer").GetComponent<Star>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Block")
        {
            star.flg = true;
            //aaaaaaaaaaaaaaaaaaaaaa
        }
    }
}
