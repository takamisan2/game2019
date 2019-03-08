//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using TMPro;
//using UnityEngine.Playables;

    
// public class AllStar : MonoBehaviour
//{
//    public float speed = 4f; //歩くスピード
//    private Rigidbody2D rb;
//    // private Animator anim;

//    public int gamemode;
//    //bool sk;

//    public float jumpPower = 350; //ジャンプ力
//    public float jumpPowerDown = 350;
//    public LayerMask groundLayer; //Linecastで判定するLayer
//    public LayerMask BrickBlock; //Linecastで判定するLayer

//    public GameObject Block;

//    private bool isGrounded; //着地判定
 
//    public int a = 1;

//    public GameObject ClearText;
//    public GameObject ClearStar;

//    public bool flg;
//    public bool groundflg;

//    void Start()
//    {
//        //各コンポーネントをキャッシュしておく
//        // anim = GetComponent<Animator>();
//        rb = GetComponent<Rigidbody2D>();

//        gamemode = 0;

//        // sk = false;
//        Physics2D.gravity = new Vector2(0.0f, -9.81f);

        
//    }

//    void Update()
//    {

//        //Scene再読み込み
//        if (Input.GetKeyDown(KeyCode.R))
//        {
//            SceneManager.LoadScene(0);
//        }

//        if (isGrounded)
//        {
//            flg = true;
//            groundflg = true;
//        }
//        if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Keypad4)) //重力を上へ
//        {
//            flg = false;
//        }
//        if (flg == true)
//        {
//            Debug.Log("flg");
//        }
//        if (flg == false)
//        {
//            Debug.Log("noflg");
//        }

//        if (isGrounded == false)
//        {
//            groundflg = false;
//        }
//        if (groundflg == true)
//        {
//            Debug.Log("GGflg");
//        }
//        if (groundflg == false)
//        {
//            Debug.Log("noGGflg");
//        }

//        //スペースキーを押し、
//        if (gamemode == 0)
//        {
//            if (Input.GetKeyDown("space"))
//            {
//                //着地していた時、
//                if (isGrounded)
//                {
//                    //着地判定をfalse
//                    isGrounded = false;
//                    //AddForceにて上方向へ力を加える
//                    rb.AddForce(Vector2.up * jumpPower);

//                }
//            }
//            //上下への移動速度を取得
//            float velY = rb.velocity.y;
//            //移動速度が0.1より大きければ上昇
//            bool isJumping = velY > 0.1f ? true : false;
//            //移動速度が-0.1より小さければ下降
//            bool isFalling = velY < -0.1f ? true : false;
//        }

//        if (gamemode == 1)
//        {
//            if (Input.GetKeyDown("space"))
//            {
//                //着地していた時、
//                if (isGrounded)
//                {
//                    //着地判定をfalse
//                    isGrounded = false;

//                    //AddForceにて上方向へ力を加える
//                    rb.AddForce(Vector2.down * jumpPowerDown);

//                }
//            }
//            //上下への移動速度を取得
//            float velY = rb.velocity.y;
//            //移動速度が0.1より大きければ上昇
//            bool isJumping = velY > 0.1f ? true : false;
//            //移動速度が-0.1より小さければ下降
//            bool isFalling = velY < -0.1f ? true : false;
//        }
//        if (gamemode == 2)
//        {
//            if (Input.GetKeyDown("space"))
//            {
//                //着地していた時、
//                if (isGrounded)
//                {
//                    //着地判定をfalse
//                    isGrounded = false;
//                    //AddForceにて上方向へ力を加える
//                    rb.AddForce(Vector2.left * jumpPower);
//                }
//            }
//            //上下への移動速度を取得
//            float velY = rb.velocity.y;
//            //移動速度が0.1より大きければ上昇
//            bool isJumping = velY > 0.1f ? true : false;
//            //移動速度が-0.1より小さければ下降
//            bool isFalling = velY < -0.1f ? true : false;
//        }
//        if (gamemode == 3)
//        {
//            if (Input.GetKeyDown("space"))
//            {
//                //着地していた時、
//                if (isGrounded)
//                {
//                    //着地判定をfalse
//                    isGrounded = false;
//                    //AddForceにて上方向へ力を加える
//                    rb.AddForce(Vector2.right * jumpPower);
//                }
//            }
//            //上下への移動速度を取得
//            float velY = rb.velocity.y;
//            //移動速度が0.1より大きければ上昇
//            bool isJumping = velY > 0.1f ? true : false;
//            //移動速度が-0.1より小さければ下降
//            bool isFalling = velY < -0.1f ? true : false;
//        }

//        // //回転
//        // float angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
//        //transform.eulerAngles = new Vector3(0, 0, angle);


        
//    }

//    void FixedUpdate()
//    {


//        if (gamemode == 0 || gamemode == 1)
//        {
//            if (flg == true)
//            {
//                float x = Input.GetAxisRaw("Horizontal");
//                //左か右を入力したら
//                if (x != 0)
//                {
//                    //入力方向へ移動
//                    rb.velocity = new Vector2(x * speed, rb.velocity.y);
//                    //localScale.xを-1にすると画像が反転する
//                    Vector2 temp = transform.localScale;
//                    temp.x = x;
//                    transform.localScale = temp;
//                }
//                else
//                {
//                    //横移動の速度を0にしてピタッと止まるようにする
//                    rb.velocity = new Vector2(0, rb.velocity.y);
//                }
//            }

//        }
//        if (gamemode == 2 || gamemode == 3)
//        {
//            if (flg == true)
//            {
//                float y = Input.GetAxisRaw("Vertical");
//                //左か右を入力したら
//                if (y != 0)
//                {
//                    //入力方向へ移動
//                    rb.velocity = new Vector2(rb.velocity.x, y * speed);
//                    //localScale.xを-1にすると画像が反転する
//                    Vector2 temp = transform.localScale;
//                    temp.x = y;
//                    transform.localScale = temp;
//                }
//                else
//                {
//                    //横移動の速度を0にしてピタッと止まるようにする
//                    rb.velocity = new Vector2(rb.velocity.x, 0);
//                }
//            }

//        }

//        //if (gamemode == 0) //地面（地面）
//        //{

//        isGrounded = Physics2D.Linecast(transform.position + transform.right * 0.3f + transform.up * -0.35f,
//                transform.position + transform.right * -0.3f + transform.up * -0.35f, groundLayer);    //地面判定 横
//        Debug.DrawLine(transform.position + transform.right * 0.3f + transform.up * -0.35f,
//            transform.position + transform.right * -0.3f + transform.up * -0.35f);


//        // isGrounded = Physics2D.Linecast(transform.position + transform.up * -0.1f, transform.position - transform.up * 0.6f, groundLayer); //地面判定 縦
//        // Debug.DrawLine(transform.position + transform.up * -0.1f, transform.position - transform.up * 0.6f); //地面判定デバック


//        // isGrounded3 = Physics2D.Linecast(transform.position + transform.up * 0.1f, transform.position - transform.up * 0.5f, BrickBlock); 

//        //isHead = Physics2D.Linecast(transform.position + transform.up * 0.5f, transform.position - transform.up * 0.1f, BrickBlock);      //頭判定　ブロック壊す
//        //Debug.DrawLine(transform.position + transform.up * 0.5f, transform.position - transform.up * 0.1f, Color.blue, 0.01f);
//        //isHead3 = Physics2D.Linecast(transform.position + transform.up * 0.5f, transform.position - transform.up * 0.1f, groundLayer);　　//頭　天井判定（↑を押して天井に当たったら足と頭の判定を逆にする）
//        //}
//        //if (sk == 1)//地面（天井）
//        //{
//        //    isGrounded2 = Physics2D.Linecast(transform.position + transform.up * 0.5f, transform.position - transform.up * 0.1f, groundLayer);      //地面判定
//        //    Debug.DrawLine(transform.position + transform.up * 0.5f, transform.position - transform.up * 0.1f);　　//地面判定デバック

//        //    isHead2 = Physics2D.Linecast(transform.position + transform.up * 0.1f, transform.position - transform.up * 0.5f, BrickBlock); //頭判定
//        //    Debug.DrawLine(transform.position + transform.up * 0.1f, transform.position - transform.up * 0.5f, Color.blue, 0.01f); //頭判定デバック
//        //    isHead4 = Physics2D.Linecast(transform.position + transform.up * 0.2f, transform.position - transform.up * 0.6f, groundLayer);　　//頭　天井判定（↓を押して天井に当たったら足と頭の判定を逆にする）          
//        //}


//        if (gamemode == 0 && flg == true && groundflg == true)//床にいるとき
//        {
//            if (Input.GetKeyDown(KeyCode.Keypad8)) //重力を上へ
//            {
//                //rigidbody2D.gravityScale = -1;
//                Physics2D.gravity = new Vector2(0.0f, 9.81f);
//                gamemode = 1;

//                //// 回転
//                // float angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
//                // transform.eulerAngles = new Vector3(0, 0, angle);

//                //transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 0, 1));

//                transform.Rotate(new Vector3(0, 0, 180.0f), Space.World);
//                //sk = false;               
//            }

//            if (Input.GetKeyDown(KeyCode.Keypad2)) //重力を下へ
//            {
//                //rigidbody2D.gravityScale = 1;
//                Physics2D.gravity = new Vector2(0.0f, -9.81f);
//                gamemode = 0;

//                //回転
//                //float angle = Mathf.LerpAngle(maxAngle, minAngle, Time.time);
//                //transform.eulerAngles = new Vector3(0, 0, angle);
//                //transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 0, 1));
//            }
//            if (Input.GetKeyDown(KeyCode.Keypad6)) //重力を右へ
//            {
//                Physics2D.gravity = new Vector2(9.81f, 0f);
//                //rb.AddForce(Vector2.right * 9.81f);
//                gamemode = 2;
//                //rb.velocity = new Vector2(100f, rb.velocity.y);
//                //float angle = Mathf.LerpAngle(minAngle2, maxAngle2, Time.time);
//                //transform.eulerAngles = new Vector3(0, 0, angle);

//                //transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 0, 1));

//                transform.Rotate(new Vector3(0, 0, 90.0f), Space.World);
//            }
//            if (Input.GetKeyDown(KeyCode.Keypad4)) //重力を左へ
//            {
//                Physics2D.gravity = new Vector2(-9.81f, 0f);
//                gamemode = 3;

//                //float angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
//                //transform.eulerAngles = new Vector3(0, 0, angle);

//                //transform.rotation = Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));

//                transform.Rotate(new Vector3(0, 0, -90.0f), Space.World);
//            }
//        }

//        if (gamemode == 1 && flg == true && groundflg == true)//天井にいるとき
//        {
//            if (Input.GetKeyDown(KeyCode.Keypad8)) //重力を上へ
//            {
//                Physics2D.gravity = new Vector2(0.0f, 9.81f);
//                gamemode = 1;

//                //transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 0, 1));
//            }
//            if (Input.GetKeyDown(KeyCode.Keypad2)) //重力を下へ
//            {
//                Physics2D.gravity = new Vector2(0.0f, -9.81f);
//                gamemode = 0;

//                //transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 0, 1));

//                transform.Rotate(new Vector3(0, 0, 180.0f), Space.World);
//            }
//            if (Input.GetKeyDown(KeyCode.Keypad6)) //重力を右へ
//            {
//                Physics2D.gravity = new Vector2(9.81f, 0f);
//                gamemode = 2;

//                //transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 0, 1));

//                transform.Rotate(new Vector3(0, 0, -90.0f), Space.World);
//            }
//            if (Input.GetKeyDown(KeyCode.Keypad4)) //重力を左へ
//            {
//                Physics2D.gravity = new Vector2(-9.81f, 0f);
//                gamemode = 3;

//                //transform.rotation = Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));

//                transform.Rotate(new Vector3(0, 0, 90.0f), Space.World);
//            }
//        }

//        if (gamemode == 2 && flg == true && groundflg == true)//右の壁にいるとき
//        {
//            if (Input.GetKeyDown(KeyCode.Keypad8)) //重力を上へ
//            {
//                Physics2D.gravity = new Vector2(0.0f, 9.81f);
//                gamemode = 1;

//                //transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 0, 1));

//                transform.Rotate(new Vector3(0, 0, 90.0f), Space.World);
//            }
//            if (Input.GetKeyDown(KeyCode.Keypad2)) //重力を下へ
//            {
//                Physics2D.gravity = new Vector2(0.0f, -9.81f);
//                gamemode = 0;

//                //transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 0, 1));

//                transform.Rotate(new Vector3(0, 0, -90.0f), Space.World);
//            }
//            if (Input.GetKeyDown(KeyCode.Keypad6)) //重力を右へ
//            {
//                Physics2D.gravity = new Vector2(9.81f, 0f);
//                gamemode = 2;

//                //transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 0, 1));
//            }
//            if (Input.GetKeyDown(KeyCode.Keypad4)) //重力を左へ
//            {
//                Physics2D.gravity = new Vector2(-9.81f, 0f);
//                gamemode = 3;

//                // transform.rotation = Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));

//                transform.Rotate(new Vector3(0, 0, 180.0f), Space.World);
//            }
//        }

//        if (gamemode == 3 && flg == true && groundflg == true) //左の壁にいるとき    
//        {
//            if (Input.GetKeyDown(KeyCode.Keypad8)) //重力を上へ
//            {
//                Physics2D.gravity = new Vector2(0.0f, 9.81f);
//                gamemode = 1;

//                //transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 0, 1));

//                transform.Rotate(new Vector3(0, 0, -90.0f), Space.World);
//            }
//            if (Input.GetKeyDown(KeyCode.Keypad2)) //重力を下へ
//            {
//                Physics2D.gravity = new Vector2(0.0f, -9.81f);
//                gamemode = 0;

//                //transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 0, 1));

//                transform.Rotate(new Vector3(0, 0, 90.0f), Space.World);
//            }
//            if (Input.GetKeyDown(KeyCode.Keypad6)) //重力を右へ
//            {
//                Physics2D.gravity = new Vector2(9.81f, 0f);
//                gamemode = 2;

//                //transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 0, 1));

//                transform.Rotate(new Vector3(0, 0, 180.0f), Space.World);
//            }
//            if (Input.GetKeyDown(KeyCode.Keypad4)) //重力を左へ
//            {
//                Physics2D.gravity = new Vector2(-9.81f, 0f);
//                gamemode = 3;

//                //transform.rotation = Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));
//            }
//        }

//    }

//    void OnCollisionEnter2D(Collision2D other)
//    {
       
        
//    }
//    void OnTriggerEnter2D(Collider2D other)
//    {
//        if (other.gameObject.tag == "GameOver")
//        {
//            Destroy(gameObject);
//        }
//        if (other.gameObject.tag == "Clear")
//        {
//            ClearText.SetActive(true);
//            Destroy(ClearStar.gameObject);
//            Time.timeScale = 0;
//        }
        
//    }
//    void OnTriggerStay2D(Collider2D other)
//    {
//        if (other.gameObject.tag == "MoveBlock")
//        {
//            transform.parent = other.gameObject.transform;
//            Debug.Log("parenting");
//        }

//    }
//    void OnCollisionExit2D()
//    {
//        transform.parent = null;
//        Debug.Log("exit");
//    }
//}
