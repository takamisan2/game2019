using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class OctBlock : MonoBehaviour {

    private Star star;
    
    private bool flg;

 
    public GameObject Target;
    public Vector3 offset;
  

    private BoxCollider2D box0;
    private BoxCollider2D box1;
    private BoxCollider2D box2;
    private BoxCollider2D box3;

 

    // Use this for initialization
    void Start () {

        star = GameObject.Find("StarPlayer").GetComponent<Star>();
        //rb = GetComponent<Rigidbody2D>();
        //PosCon = GetComponent<PositionConstraint>();
        BoxCollider2D[] boxCollider = GetComponents<BoxCollider2D>();//アタッチしているBoxColliderを配列にして取得する
        box0 = boxCollider[1]; //2番目のBox
        box1 = boxCollider[2]; //3番目のBox
        box2 = boxCollider[3]; //4番目のBox
        box3 = boxCollider[4]; //5番目のBox
    }
	
    void Update()
    {
      

        //playerの頭があるとき
        if (star.mode == 3 || star.mode == 1)
        {
           
            flg = false;
           
        }



        if (flg == true)
        {

            Vector3 pos = Target.transform.localPosition;

            transform.localPosition = pos + offset;
        }
        if (flg == false)
        {
            Debug.Log("くっついてない");
          
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

            //star.num = 0;
        }
        if (star.gamemode == 0)
        {
            offset = new Vector3(0, 1.0f, 0);
            box0.enabled = true;
            box1.enabled = false;
            box2.enabled = false;
            box3.enabled = false;
         
        }
        if (star.gamemode == 1)
        {
           offset = new Vector3(0, -1.0f, 0);
            box0.enabled = false;
            box1.enabled = true;
            box2.enabled = false;
            box3.enabled = false;
        
        }
        if (star.gamemode == 2)
        {
           offset = new Vector3(-1.0f, 0, 0);
            box0.enabled = false;
            box1.enabled = false;
            box2.enabled = true;
            box3.enabled = false;
          
        }
        if (star.gamemode == 3)
        {
          offset = new Vector3(1.0f, 0, 0);
            box0.enabled = false;
            box1.enabled = false;
            box2.enabled = false;
            box3.enabled = true;          
        }
    }

	// Update is called once per frame
	void FixedUpdate () {

         
      
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && star.mode == 2)
        {
            Debug.Log("吸盤");
            //transform.parent = other.gameObject.transform;
            flg = true;
            //star.num = 1;
        }
    }
   
}
