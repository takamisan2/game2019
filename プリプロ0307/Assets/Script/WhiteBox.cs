using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteBox : MonoBehaviour {

    public GameObject box;
    public GameObject box2;
    public GameObject box3;

    // Use this for initialization
    void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        box.SetActive(true);
        box2.SetActive(true);
        box3.SetActive(true);
       
    }
}
