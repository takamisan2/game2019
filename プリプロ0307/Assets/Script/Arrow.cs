using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    private Star star;

    private Vector3 initialPosition;

    // Use this for initialization
    void Start () {
        star = GameObject.Find("StarPlayer").GetComponent<Star>();

        initialPosition = transform.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.position = new Vector3(initialPosition.x, Mathf.Sin(Time.time) * 1.0f + initialPosition.y, initialPosition.z);

        if (star.gamemode == 0 && star.flg == true && star.groundflg == true)//床にいるとき
        {
            if (Input.GetKeyDown(KeyCode.Keypad8)) //重力を上へ
            {
               
                transform.Rotate(new Vector3(0, 0, 180.0f), Space.World);
          
            }

            if (Input.GetKeyDown(KeyCode.Keypad6)) //重力を右へ
            {              
                transform.Rotate(new Vector3(0, 0, 90.0f), Space.World);
            }
            if (Input.GetKeyDown(KeyCode.Keypad4)) //重力を左へ
            {
              
                transform.Rotate(new Vector3(0, 0, -90.0f), Space.World);
            }
        }
        if (star.gamemode == 1 && star.flg == true && star.groundflg == true)//天井にいるとき
        {           
            if (Input.GetKeyDown(KeyCode.Keypad2)) //重力を下へ
            {
                transform.Rotate(new Vector3(0, 0, 180.0f), Space.World);
            }
            if (Input.GetKeyDown(KeyCode.Keypad6)) //重力を右へ
            {             
                transform.Rotate(new Vector3(0, 0, -90.0f), Space.World);
            }
            if (Input.GetKeyDown(KeyCode.Keypad4)) //重力を左へ
            {       
                transform.Rotate(new Vector3(0, 0, 90.0f), Space.World);
            }
        }

        if (star.gamemode == 2 && star.flg == true && star.groundflg == true)//右の壁にいるとき
        {
            if (Input.GetKeyDown(KeyCode.Keypad8)) //重力を上へ
            {
           
                transform.Rotate(new Vector3(0, 0, 90.0f), Space.World);
            }
            if (Input.GetKeyDown(KeyCode.Keypad2)) //重力を下へ
            {
           
                transform.Rotate(new Vector3(0, 0, -90.0f), Space.World);
            }
      
            if (Input.GetKeyDown(KeyCode.Keypad4)) //重力を左へ
            {
               
                transform.Rotate(new Vector3(0, 0, 180.0f), Space.World);
            }
        }

        if (star.gamemode == 3 && star.flg == true && star.groundflg == true) //左の壁にいるとき    
        {
            if (Input.GetKeyDown(KeyCode.Keypad8)) //重力を上へ
            {
              
                transform.Rotate(new Vector3(0, 0, -90.0f), Space.World);
            }
            if (Input.GetKeyDown(KeyCode.Keypad2)) //重力を下へ
            {
              
                transform.Rotate(new Vector3(0, 0, 90.0f), Space.World);
            }
            if (Input.GetKeyDown(KeyCode.Keypad6)) //重力を右へ
            {             
                transform.Rotate(new Vector3(0, 0, 180.0f), Space.World);
            }
            
        }
    }
}
