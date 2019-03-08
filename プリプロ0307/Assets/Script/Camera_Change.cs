using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Change : MonoBehaviour
{
    //public GameObject V_Camera;
    public Camera Main_Cam;
    public GameObject Player;

    //public Vector3 CenterCamPos;    //Enter押したときのカメラのPosを指定
    public int First_Cam_Size;
    public int Change_Cam_Size;            //Enter押したときのCameraのSizeを指定

    //private float time;
    //private const float LEAP_TIME = 2f;
    //public Vector3 startPosition;
    //public Vector3 endPosition;

    //Vector3 PlayerPosition;

    // Use this for initialization
    void Start()
    {
        //V_Camera = GameObject.Find("CM vcam1").gameObject;
        Player = GameObject.Find("StarPlayer").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Return)|| Input.GetKey("joystick button 3"))
        {
            //V_Camera.transform.position = new Vector3(0, 0, -10);

            //Main_Cam.transform.position = CenterCamPos;

            //float t = Mathf.Min(time / LEAP_TIME, 1f);
            //float leapt = (t * t) * (3f - (2f * t));
            //transform.position = Vector3.Lerp(startPosition, endPosition, leapt);
            //time += Time.deltaTime;

            Main_Cam.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 10);

            Main_Cam.orthographicSize = Change_Cam_Size;
        }
        else
        {
            Main_Cam.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z - 10);

            //float t = Mathf.Min(time / LEAP_TIME, 1f);
            //float leapt = (t * t) * (3f - (2f * t));
            //transform.position = Vector3.Lerp(endPosition, startPosition, leapt);
            //time += Time.deltaTime;

            Main_Cam.orthographicSize = First_Cam_Size;      //カメラのサイズをStarの周りに拡大表示
        }
    }
}