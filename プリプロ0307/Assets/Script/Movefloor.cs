using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movefloor : MonoBehaviour {

    private Star star;
    private Vector3 initialPosition;
    //public GameObject Trigger0;
    //public GameObject Trigger1;
    //public GameObject Trigger2;
    //public GameObject Trigger3;

    private new Vector3 oldpos;

    private BoxCollider2D box0;
    private BoxCollider2D box1;
    private BoxCollider2D box2;
    private BoxCollider2D box3;

    //AllStar star;

    // Use this for initialization
    void Start () {
        //star = GameObject.Find("AllStar").GetComponent<AllStar>();
        initialPosition = transform.position;
        star = GameObject.Find("StarPlayer").GetComponent<Star>();

        BoxCollider2D[] boxCollider = GetComponents<BoxCollider2D>();//アタッチしているBoxColliderを配列にして取得する
        box0 = boxCollider[1]; //2番目のBox
        box1 = boxCollider[2]; //3番目のBox
        box2 = boxCollider[3]; //4番目のBox
        box3 = boxCollider[4]; //5番目のBox
    }
	
	// Update is called once per frame

    void Update()
    {
        //oldpos = transform.position;
        transform.position = new Vector3(Mathf.Sin(Time.time) * 1.0f + initialPosition.x, +initialPosition.y, initialPosition.z);

        if (star.gamemode == 0)
        {
           
            box0.enabled = true;
            box1.enabled = false;
            box2.enabled = false;
            box3.enabled = false;

        }
        if (star.gamemode == 1)
        {
          
            box0.enabled = false;
            box1.enabled = true;
            box2.enabled = false;
            box3.enabled = false;

        }
        if (star.gamemode == 2)
        {
          
            box0.enabled = false;
            box1.enabled = false;
            box2.enabled = true;
            box3.enabled = false;

        }
        if (star.gamemode == 3)
        {
          
            box0.enabled = false;
            box1.enabled = false;
            box2.enabled = false;
            box3.enabled = true;

        }

        //if (star.gamemode==0)
        //{
        //    Trigger0.SetActive(true);
        //    Trigger1.SetActive(false);
        //    Trigger2.SetActive(false);
        //    Trigger3.SetActive(false);
        //}
        //if (star.gamemode == 1)
        //{
        //    Trigger0.SetActive(false);
        //    Trigger1.SetActive(true);
        //    Trigger2.SetActive(false);
        //    Trigger3.SetActive(false);
        //}
        //if (star.gamemode == 2)
        //{
        //    Trigger0.SetActive(false);
        //    Trigger1.SetActive(false);
        //    Trigger2.SetActive(true);
        //    Trigger3.SetActive(false);
        //}
        //if (star.gamemode == 3)
        //{
        //    Trigger0.SetActive(false);
        //    Trigger1.SetActive(false);
        //    Trigger2.SetActive(false);
        //    Trigger3.SetActive(true);
        //}
    }

	void FixedUpdate () {
       

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player1");
        oldpos = transform.position;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player") //動く床に乗ったとき
        {
            Debug.Log("Player");
            other.transform.position += transform.position - oldpos;
            oldpos = transform.position;
        }
    }

}
