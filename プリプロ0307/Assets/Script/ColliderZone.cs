using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderZone : MonoBehaviour {


    public GameObject GameOver;
    public GameObject Star;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Zone")
        {
            GameOver.SetActive(true);
            Destroy(Star.gameObject);
            Debug.Log("ハリが刺さった");
        }
    }
}
