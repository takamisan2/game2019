using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Star : MonoBehaviour
{
    public float speed = 4f; //歩くスピード
    public Rigidbody2D rb;
    // private Animator anim;

    public int gamemode = 0;
    

    public float jumpPower = 350; //ジャンプ力
    public float jumpPowerDown = 350;
    public LayerMask groundLayer; //Linecastで判定するLayer
    public LayerMask BrickBlock; //Linecastで判定するLayer
    public LayerMask GroundBlock;
    
    public GameObject Block;

    private bool isGrounded; //着地判定
    //private bool isGrounded3;
    //private bool isHead;
    //private bool isHead3;

    //private bool isGrounded2; //着地判定
    //private bool isHead2;
    //private bool isHead4;

    //float minAngle = 0.0f;
    //float maxAngle = 180.0f;

    //float minAngle2 = 0.0f;
    //float maxAngle2 = 90.0f;

    
    public int a = 1;

    //float speed2 = 120f;

    public int mode; //星の回転モード

    public GameObject Head1;         //頭
    public GameObject HeadColider;   //頭のブロックを壊す判定
    public GameObject RightHand;     //右手
    public GameObject LeftHand;      //左手
    public GameObject Right;         //長い右足
    public GameObject Left;          //長い左足
    public GameObject minRight;      //小さい右足
    public GameObject minLeft;       //小さい左足
    //public GameObject LongCollider;  //足が長いときの体の判定

    public GameObject ClearText;
    public GameObject ClearStar;

    public GameObject GameOverText;

    public bool flg;
    public bool groundflg;

    //public int num;

    //private Vector3 initialPosition;

    //public GameObject moveblock;

    private CapsuleCollider2D capsule1;
    private CapsuleCollider2D capsule2;

    void Start()
    {
        //各コンポーネントをキャッシュしておく
       // anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        mode = 4;

        Physics2D.gravity = new Vector2(0.0f, -9.81f);

        //initialPosition = transform.position;

        

        CapsuleCollider2D[] capsuleCollider = GetComponents<CapsuleCollider2D>();
        capsule1 = capsuleCollider[0]; //1番目
        capsule2 = capsuleCollider[1]; //2番目

        
    }
    private IEnumerator loop(int frame)
    {
        // ループ
        while (frame > 0)
        {
            // frameで指定したフレームだけループします
            yield return null;
            Debug.Log("loop");
            frame--;
            transform.Rotate(new Vector3(0, 0, 30f), Space.World);
            flg = false;
        }
    }
    private IEnumerator loop2(int frame)
    {
        // ループ
        while (frame > 0)
        {
            // frameで指定したフレームだけループします
            yield return null;
            Debug.Log("loop");
            frame--;
            transform.Rotate(new Vector3(0, 0, -30f), Space.World);
            flg = false;
        }
    }
    void Update()
    {

        if (Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("button0");
        }
        if (Input.GetKeyDown("joystick button 1"))
        {
            Debug.Log("button1");
        }
        if (Input.GetKeyDown("joystick button 2"))
        {
            Debug.Log("button2");
        }
        if (Input.GetKeyDown("joystick button 3"))
        {
            Debug.Log("button3");
        }
        if (Input.GetKeyDown("joystick button 4"))
        {
            Debug.Log("button4");
        }
        if (Input.GetKeyDown("joystick button 5"))
        {
            Debug.Log("button5");
        }
        if (Input.GetKeyDown("joystick button 6"))
        {
            Debug.Log("button6");
        }
        if (Input.GetKeyDown("joystick button 7"))
        {
            Debug.Log("button7");
        }
        if (Input.GetKeyDown("joystick button 8"))
        {
            Debug.Log("button8");
        }
        if (Input.GetKeyDown("joystick button 9"))
        {
            Debug.Log("button9");
        }

        

        //Scene再読み込み
        if (Input.GetKeyDown(KeyCode.R)|| Input.GetKeyDown("joystick button 6"))
        {
            Scene loadScene = SceneManager.GetActiveScene();
            // Sceneの読み直し
            SceneManager.LoadScene(loadScene.name);
        }

        if (Input.GetKeyDown(KeyCode.E)|| Input.GetKeyDown("joystick button 5"))　//モード切替右回転
        {
            mode += 1;
        }
        if(mode>5)
        {
            mode = 1;
        }
        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown("joystick button 4"))　//モード切替左回転
        {
            mode -= 1;
        }
        if (mode<1)
        {
            mode = 5;
        }

        if (mode == 1)
        {
            Head1.SetActive(true);
            HeadColider.SetActive(true);
            RightHand.SetActive(true);
            LeftHand.SetActive(false);
            Right.SetActive(true);
            Left.SetActive(true);
            //LongCollider.SetActive(true);
            capsule1.enabled = true;
            capsule2.enabled = true;
        }
        if (mode == 2)
        {
            Head1.SetActive(false);
            HeadColider.SetActive(false);
            RightHand.SetActive(true);
            LeftHand.SetActive(true);
            Right.SetActive(true);
            //Left.SetActive(true);
            capsule1.enabled = true;
            capsule2.enabled = true;
        }
        if (mode == 3)
        {
            Head1.SetActive(true);
            HeadColider.SetActive(true);
            RightHand.SetActive(false);
            LeftHand.SetActive(true);
            Right.SetActive(true);
            Left.SetActive(true);
            // LongCollider.SetActive(true);
            capsule1.enabled = true;
            capsule2.enabled = true;
        }
        if (mode == 4)
        {
            Head1.SetActive(true);
            HeadColider.SetActive(true);
            RightHand.SetActive(true);
            LeftHand.SetActive(true);
            Right.SetActive(false);
            Left.SetActive(false);
            minRight.SetActive(false);
            minLeft.SetActive(true);
            // LongCollider.SetActive(false);
            capsule1.enabled = true;
            capsule2.enabled = false;
        }
        if (mode == 5)
        {
            Head1.SetActive(true);
            HeadColider.SetActive(true);
            RightHand.SetActive(true);
            LeftHand.SetActive(true);
            Right.SetActive(false);
            Left.SetActive(false);
            minRight.SetActive(true);
            minLeft.SetActive(false);
            // LongCollider.SetActive(false);
            capsule1.enabled = true;
            capsule2.enabled = false;
        }

        //if(mode==2)
        //{
        //    if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Keypad4))
        //    {
        //        flg = false;
        //    }
        //}


        //if (Input.GetKeyDown(KeyCode.Keypad8)|| Input.GetKeyDown(KeyCode.Keypad2)|| Input.GetKeyDown(KeyCode.Keypad6)|| Input.GetKeyDown(KeyCode.Keypad4))
        //{
        //    flg = false;
        //}
        

      

        //スペースキーを押し、
        if (gamemode == 0)
        {
            if (Input.GetKeyDown("joystick button 1")|| Input.GetKeyDown("space"))
            {
                    //着地していた時、
                if (isGrounded)
                {
                    //着地判定をfalse
                    isGrounded = false;
                    //AddForceにて上方向へ力を加える
                    rb.AddForce(Vector2.up * jumpPower);
                    
                }
            }
            //上下への移動速度を取得
            float velY = rb.velocity.y;
            //移動速度が0.1より大きければ上昇
            bool isJumping = velY > 0.1f ? true : false;
            //移動速度が-0.1より小さければ下降
            bool isFalling = velY < -0.1f ? true : false;
        }

        if (gamemode == 1)
        {
            if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown("space"))
            {
                //着地していた時、
                if (isGrounded)
                {
                    //着地判定をfalse
                    isGrounded = false;
                   
                    //AddForceにて上方向へ力を加える
                    rb.AddForce(Vector2.down * jumpPowerDown);
                    
                }
            }
            //上下への移動速度を取得
            float velY = rb.velocity.y;
            //移動速度が0.1より大きければ上昇
            bool isJumping = velY > 0.1f ? true : false;
            //移動速度が-0.1より小さければ下降
            bool isFalling = velY < -0.1f ? true : false;
        }
        if (gamemode == 2)
        {
            if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown("space"))
            {
                //着地していた時、
                if (isGrounded)
                {
                    //着地判定をfalse
                    isGrounded = false;
                    //AddForceにて上方向へ力を加える
                    rb.AddForce(Vector2.left * jumpPower);
                }
            }
            //上下への移動速度を取得
            float velY = rb.velocity.y;
            //移動速度が0.1より大きければ上昇
            bool isJumping = velY > 0.1f ? true : false;
            //移動速度が-0.1より小さければ下降
            bool isFalling = velY < -0.1f ? true : false;
        }
        if (gamemode == 3)
        {
            if (Input.GetKeyDown("joystick button 1") || Input.GetKeyDown("space"))
            {
                //着地していた時、
                if (isGrounded)
                {
                    //着地判定をfalse
                    isGrounded = false;
                    //AddForceにて上方向へ力を加える
                    rb.AddForce(Vector2.right * jumpPower);
                }
            }
            //上下への移動速度を取得
            float velY = rb.velocity.y;
            //移動速度が0.1より大きければ上昇
            bool isJumping = velY > 0.1f ? true : false;
            //移動速度が-0.1より小さければ下降
            bool isFalling = velY < -0.1f ? true : false;
        }

    }
    
    void FixedUpdate()
    {
        if (flg == true)
        {
            Debug.Log("flg");
        }
        if (flg == false)
        {
            Debug.Log("notflg");
        }

        if (!isGrounded)
        {
            groundflg = false;
        }
        if (groundflg == true)
        {
            Debug.Log("groundflg");
        }
        if (groundflg == false)
        {
            Debug.Log("notgroundflg");
        }

        if (gamemode == 0|| gamemode == 1) //横移動
        {
            if (flg == true)
            {
                float x = Input.GetAxisRaw("Horizontal");
                //左か右を入力したら
                if (x != 0)
                {
                    //入力方向へ移動
                    rb.velocity = new Vector2(x * speed, rb.velocity.y);
                    ////localScale.xを-1にすると画像が反転する
                    //Vector2 temp = transform.localScale;
                    //temp.x = x;
                    //transform.localScale = temp;                    
                }
                else
                {
                    //横移動の速度を0にしてピタッと止まるようにする
                    rb.velocity = new Vector2(0, rb.velocity.y);
                }
            }
            
        }
        if (gamemode == 2 || gamemode == 3) //縦移動
        {
            if (flg == true)
            {
                float y = Input.GetAxisRaw("Vertical");
                //上か下を入力したら
                if (y != 0)
                {
                    //入力方向へ移動
                    rb.velocity = new Vector2(rb.velocity.x, y * speed);
                    ////localScale.xを-1にすると画像が反転する
                    //Vector2 temp = transform.localScale;
                    //temp.x = y;
                    //transform.localScale = temp;
                }
                else
                {
                    //横移動の速度を0にしてピタッと止まるようにする
                    rb.velocity = new Vector2(rb.velocity.x, 0);
                }
            }
            
        }

        //if (gamemode == 0) //地面（地面）
        //{

        isGrounded = Physics2D.Linecast(transform.position + transform.right * 0.26f + transform.up * -0.53f,
                transform.position + transform.right * -0.26f + transform.up * -0.53f, LayerMask.GetMask("Ground","Block"));    //地面判定 横棒
        Debug.DrawLine(transform.position + transform.right * 0.26f + transform.up * -0.53f,
            transform.position + transform.right * -0.26f + transform.up * -0.53f);

        if (isGrounded==true)
        {
            flg = true;
            groundflg = true;
        }

        // isGrounded = Physics2D.Linecast(transform.position + transform.up * -0.1f, transform.position - transform.up * 0.6f, groundLayer); //地面判定 縦
        // Debug.DrawLine(transform.position + transform.up * -0.1f, transform.position - transform.up * 0.6f); //地面判定デバック


        // isGrounded3 = Physics2D.Linecast(transform.position + transform.up * 0.1f, transform.position - transform.up * 0.5f, BrickBlock); 

        //isHead = Physics2D.Linecast(transform.position + transform.up * 0.5f, transform.position - transform.up * 0.1f, BrickBlock);      //頭判定　ブロック壊す
        //Debug.DrawLine(transform.position + transform.up * 0.5f, transform.position - transform.up * 0.1f, Color.blue, 0.01f);
        //isHead3 = Physics2D.Linecast(transform.position + transform.up * 0.5f, transform.position - transform.up * 0.1f, groundLayer);　　//頭　天井判定（↑を押して天井に当たったら足と頭の判定を逆にする）
        //}
        //if (sk == 1)//地面（天井）
        //{
        //    isGrounded2 = Physics2D.Linecast(transform.position + transform.up * 0.5f, transform.position - transform.up * 0.1f, groundLayer);      //地面判定
        //    Debug.DrawLine(transform.position + transform.up * 0.5f, transform.position - transform.up * 0.1f);　　//地面判定デバック

        //    isHead2 = Physics2D.Linecast(transform.position + transform.up * 0.1f, transform.position - transform.up * 0.5f, BrickBlock); //頭判定
        //    Debug.DrawLine(transform.position + transform.up * 0.1f, transform.position - transform.up * 0.5f, Color.blue, 0.01f); //頭判定デバック
        //    isHead4 = Physics2D.Linecast(transform.position + transform.up * 0.2f, transform.position - transform.up * 0.6f, groundLayer);　　//頭　天井判定（↓を押して天井に当たったら足と頭の判定を逆にする）          
        //}


        float x2 = Input.GetAxisRaw("DpadHorizon"); //十字キー横
        if (x2 > 0)
        {
            Debug.Log("Horizon");
        }
        if (x2 < 0)
        {
            Debug.Log("--Horizon");
        }

        float y2 = Input.GetAxisRaw("DpadVertical"); //十字キー縦
        if (y2 > 0)
        {
            Debug.Log("Vertical");
        }
        if (y2 < 0)
        {
            Debug.Log("--Vertical");
        }

        //if (x2 != 0 || y2 != 0) //十字キーが押されたら
        //{
        //    flg = false;
        //}
        //Time.timeScale = 0.1f;

       


        if (gamemode == 0 && flg == true && groundflg == true)//床にいるとき
        {
            if (Input.GetKeyDown(KeyCode.Keypad8)||y2>0&&x2==0) //重力を上へ
            {
                flg = false;
               
                Physics2D.gravity = new Vector2(0.0f, 9.81f);
                gamemode = 1;

                //// 回転
                // float angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
                // transform.eulerAngles = new Vector3(0, 0, angle);

                //transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 0, 1));

                //int a=0;
                //while (a <= 180)
                //{
                StartCoroutine(loop(6));
                //transform.Rotate(new Vector3(0, 0, 180f), Space.World);
                
                // a++;
                //}
            }
            
           
            //if (Input.GetKeyDown(KeyCode.Keypad2)||y2<0) //重力を下へ
            //{
            //    //rigidbody2D.gravityScale = 1;
            //    Physics2D.gravity = new Vector2(0.0f, -9.81f);
            //    gamemode = 0;

            //    //回転
            //    //float angle = Mathf.LerpAngle(maxAngle, minAngle, Time.time);
            //    //transform.eulerAngles = new Vector3(0, 0, angle);
            //    //transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 0, 1));
            //}
            if (Input.GetKeyDown(KeyCode.Keypad6)||x2>0&&y2==0) //重力を右へ
            {
                flg = false;
                Physics2D.gravity = new Vector2(9.81f, 0f);
                //rb.AddForce(Vector2.right * 9.81f);
                gamemode = 2;
                //rb.velocity = new Vector2(100f, rb.velocity.y);
                //float angle = Mathf.LerpAngle(minAngle2, maxAngle2, Time.time);
                //transform.eulerAngles = new Vector3(0, 0, angle);

                //transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 0, 1));


                StartCoroutine(loop(3));
                //transform.Rotate(new Vector3(0, 0, 90.0f), Space.World);
            }
            if (Input.GetKeyDown(KeyCode.Keypad4)||x2<0&&y2==0) //重力を左へ
            {
                flg = false;
                Physics2D.gravity = new Vector2(-9.81f, 0f);
                gamemode = 3;

                //float angle = Mathf.LerpAngle(minAngle, maxAngle, Time.time);
                //transform.eulerAngles = new Vector3(0, 0, angle);

                //transform.rotation = Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));

                StartCoroutine(loop2(3));
                //transform.Rotate(new Vector3(0, 0, -90.0f), Space.World);
            }
        }

        if (gamemode == 1 && flg==true && groundflg==true)//天井にいるとき
        {

            //if (Input.GetKeyDown(KeyCode.Keypad8) || y2 > 0) //重力を上へ
            //{
            //    Physics2D.gravity = new Vector2(0.0f, 9.81f);
            //    gamemode = 1;

            //    //transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 0, 1));
            //}
            if (Input.GetKeyDown(KeyCode.Keypad2) || y2 < 0 && x2 == 0) //重力を下へ
            {
                flg = false;
                Physics2D.gravity = new Vector2(0.0f, -9.81f);
                gamemode = 0;

                //transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 0, 1));


                StartCoroutine(loop(6));
                //transform.Rotate(new Vector3(0, 0, 180.0f), Space.World);

            }
            if (Input.GetKeyDown(KeyCode.Keypad6) || x2 > 0 && y2 == 0) //重力を右へ
            {
                flg = false;
                Physics2D.gravity = new Vector2(9.81f, 0f);
                gamemode = 2;

                //transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 0, 1));

                StartCoroutine(loop2(3));
                //transform.Rotate(new Vector3(0, 0, -90.0f), Space.World);
            }
            if (Input.GetKeyDown(KeyCode.Keypad4) || x2 < 0 && y2 == 0) //重力を左へ
            {
                flg = false;
                Physics2D.gravity = new Vector2(-9.81f, 0f);
                gamemode = 3;

                //transform.rotation = Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));

                StartCoroutine(loop(3));
                //transform.Rotate(new Vector3(0, 0, 90.0f), Space.World);
            }
        }

        if (gamemode == 2 && flg==true && groundflg == true)//右の壁にいるとき
        {
            if (Input.GetKeyDown(KeyCode.Keypad8) || y2 > 0 && x2 == 0) //重力を上へ
            {
                flg = false;
                Physics2D.gravity = new Vector2(0.0f, 9.81f);
                gamemode = 1;

                //transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 0, 1));

                StartCoroutine(loop(3));
                //transform.Rotate(new Vector3(0, 0, 90.0f), Space.World);
            }
            if (Input.GetKeyDown(KeyCode.Keypad2) || y2 < 0 && x2 == 0) //重力を下へ
            {
                flg = false;
                Physics2D.gravity = new Vector2(0.0f, -9.81f);
                gamemode = 0;

                //transform.rotation = Quaternion.AngleAxis(0, new Vector3(0, 0, 1));

                StartCoroutine(loop2(3));
                //transform.Rotate(new Vector3(0, 0, -90.0f), Space.World);
            }
            //if (Input.GetKeyDown(KeyCode.Keypad6) || x2 > 0) //重力を右へ
            //{
            //    Physics2D.gravity = new Vector2(9.81f, 0f);
            //    gamemode = 2;

            //    //transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 0, 1));
            //}
            if (Input.GetKeyDown(KeyCode.Keypad4) || x2 < 0 && y2 == 0) //重力を左へ
            {
                flg = false;
                Physics2D.gravity = new Vector2(-9.81f, 0f);
                gamemode = 3;

                // transform.rotation = Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));

                StartCoroutine(loop(6));
                //transform.Rotate(new Vector3(0, 0, 180.0f), Space.World);
            }
        }

        if (gamemode == 3 && flg==true && groundflg == true) //左の壁にいるとき    
        {
            if (Input.GetKeyDown(KeyCode.Keypad8) || y2 > 0 && x2 == 0) //重力を上へ
            {
                flg = false;
                Physics2D.gravity = new Vector2(0.0f, 9.81f);
                gamemode = 1;

                //transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 0, 1));

                StartCoroutine(loop2(3));
                //transform.Rotate(new Vector3(0, 0, -90.0f), Space.World);
            }
            if (Input.GetKeyDown(KeyCode.Keypad2) || y2 < 0 && x2 == 0) //重力を下へ
            {
                flg = false;
                Physics2D.gravity = new Vector2(0.0f, -9.81f);
                gamemode = 0;

                //transform.rotation = Quaternion.AngleAxis(180, new Vector3(0, 0, 1));

                StartCoroutine(loop(3));
                //transform.Rotate(new Vector3(0, 0, 90.0f), Space.World);
            }
            if (Input.GetKeyDown(KeyCode.Keypad6) || x2 > 0 && y2 == 0) //重力を右へ
            {
                flg = false;
                Physics2D.gravity = new Vector2(9.81f, 0f);
                gamemode = 2;

                //transform.rotation = Quaternion.AngleAxis(90, new Vector3(0, 0, 1));

                StartCoroutine(loop(6));
                //transform.Rotate(new Vector3(0, 0, 180.0f), Space.World);
            }

            //if (Input.GetKeyDown(KeyCode.Keypad4) || x2 < 0) //重力を左へ
            //{
            //    Physics2D.gravity = new Vector2(-9.81f, 0f);
            //    gamemode = 3;

            //    //transform.rotation = Quaternion.AngleAxis(-90, new Vector3(0, 0, 1));
            //}
        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        //ハリに当たったとき
        if (other.gameObject.tag == "Zone"&&mode==4) 
        {
            Destroy(gameObject);
            GameOverText.SetActive(true);
        }
        //ハリに当たったとき
        if (other.gameObject.tag == "Zone" && mode == 5) 
        {
            Destroy(gameObject);
            GameOverText.SetActive(true);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //ブラックホールに当たったとき
        if (other.gameObject.tag == "GameOver") 
        {
            Destroy(gameObject);
            GameOverText.SetActive(true);
        }
        //ゴールのスターに当たったとき
        if (other.gameObject.tag == "Clear") 
        {
            ClearText.SetActive(true);
            Destroy(ClearStar.gameObject);
            Time.timeScale = 0;
        }

    }

    void OnTriggerStay2D(Collider2D other)
    {
        //    if (other.gameObject.tag == "MoveBlock") //動く床に乗ったとき
        //    {
        //        //動く床の子になる
        //        //transform.parent = other.gameObject.transform; 
        //        //transform.position = new Vector3(Mathf.Sin(Time.time) * 1.0f + transform.position.x, + transform.position.y, transform.position.z);
        //        Debug.Log("parenting");
        //        transform.position = other.transform.position;
        //        //if (num == 1)
        //        //{
        //        //    moveblock.transform.parent = other.gameObject.transform;
        //        //}
        //    }
    }

    void OnCollisionExit2D()
    {
        ////どこの子にもならない
        //transform.parent = null;
        //moveblock.transform.parent = null;
        //Debug.Log("exit");
    }
}
