//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class Star2 : MonoBehaviour
//{
//    public float speed = 4f; //歩くスピード
//    private Rigidbody2D rb;
//    // private Animator anim;

//    public int gamemode = 0;
//    public int sk = 0;

//    public float jumpPower = 700; //ジャンプ力
//    public float jumpPowerDown = 700;
//    public LayerMask groundLayer; //Linecastで判定するLayer
//    public LayerMask BrickBlock; //Linecastで判定するLayer

//    public GameObject Block;

//    private bool isGrounded; //着地判定
//    private bool isGrounded3;
//    private bool isHead;
//    private bool isHead3;

//    private bool isGrounded2; //着地判定
//    private bool isHead2;
//    private bool isHead4;

//    void Start()
//    {
//        //各コンポーネントをキャッシュしておく
//        // anim = GetComponent<Animator>();
//        rb = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {

//        //Scene再読み込み
//        if(Input.GetKeyDown(KeyCode.R))
//        {
//            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
//        }
//        if (gamemode==0) //地面（地面）
//        {
//            isGrounded = Physics2D.Linecast(transform.position + transform.up * 0.1f, transform.position - transform.up * 0.5f, groundLayer); //地面判定
//            Debug.DrawLine(transform.position + transform.up * 0.1f, transform.position - transform.up * 0.5f); //地面判定デバック
//                                                                                                                // isGrounded3 = Physics2D.Linecast(transform.position + transform.up * 0.1f, transform.position - transform.up * 0.5f, BrickBlock); 


//            isHead = Physics2D.Linecast(transform.position + transform.up * 0.5f, transform.position - transform.up * 0.1f, BrickBlock);      //頭判定　ブロック壊す
//            Debug.DrawLine(transform.position + transform.up * 0.5f, transform.position - transform.up * 0.1f, Color.blue, 0.01f);
//           // isHead3 = Physics2D.Linecast(transform.position + transform.up * 0.5f, transform.position - transform.up * 0.1f, groundLayer);　　//頭　天井判定（↑を押して天井に当たったら足と頭の判定を逆にする）
//        }
//         if (gamemode==1)//地面（天井）
//        {
//            isGrounded2 = Physics2D.Linecast(transform.position + transform.up * 0.5f, transform.position - transform.up * 0.1f, groundLayer);      //地面判定
//            Debug.DrawLine(transform.position + transform.up * 0.5f, transform.position - transform.up * 0.1f);　　//地面判定デバック

//            isHead2 = Physics2D.Linecast(transform.position + transform.up * 0.1f, transform.position - transform.up * 0.5f, BrickBlock); //頭判定
//            Debug.DrawLine(transform.position + transform.up * 0.1f, transform.position - transform.up * 0.5f, Color.blue, 0.01f); //頭判定デバック
//            //isHead4 = Physics2D.Linecast(transform.position + transform.up * 0.2f, transform.position - transform.up * 0.6f, groundLayer);　　//頭　天井判定（↓を押して天井に当たったら足と頭の判定を逆にする）          
//        }

//        if (isHead)
//        {
//            Debug.Log("壊した!");
//            Destroy(Block.gameObject);
//        }
//        //if (isHead3)
//        //{
//        //    Debug.Log("反転");
//        //    sk = 1;
//        //}

//        if (isHead2)
//        {
//            Debug.Log("壊した!");
//            Destroy(Block.gameObject);
//        }
//        //if (isHead4)
//        //{
//        //    Debug.Log("反転");
//        //    sk = 0;
//        //}

//        //スペースキーを押し、
//        if (gamemode == 0)
//        {
//            if (Input.GetKeyDown("space"))
//            {
//                //着地していた時、
//                if (isGrounded || isGrounded3)
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
//                if (isGrounded2)
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
//                //if (isGrounded)
//                //{
//                //着地判定をfalse
//                //isGrounded = false;
//                //AddForceにて上方向へ力を加える
//                rb.AddForce(Vector2.left * jumpPower);
//                //}
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
//                //if (isGrounded)
//                //{
//                //着地判定をfalse
//                //isGrounded = false;
//                //AddForceにて上方向へ力を加える
//                rb.AddForce(Vector2.right * jumpPower);
//                //}
//            }
//            //上下への移動速度を取得
//            float velY = rb.velocity.y;
//            //移動速度が0.1より大きければ上昇
//            bool isJumping = velY > 0.1f ? true : false;
//            //移動速度が-0.1より小さければ下降
//            bool isFalling = velY < -0.1f ? true : false;
//        }

//        if (Input.GetKeyDown(KeyCode.UpArrow)) //重力を上へ
//        {
//            //rigidbody2D.gravityScale = -1;
//            Physics2D.gravity = new Vector2(0.0f, 9.81f);
//            gamemode = 1;
//        }
//        if (Input.GetKeyDown(KeyCode.DownArrow)) //重力を下へ
//        {
//            //rigidbody2D.gravityScale = 1;
//            Physics2D.gravity = new Vector2(0.0f, -9.81f);
//            gamemode = 0;
//        }
//        if (Input.GetKeyDown(KeyCode.RightArrow)) //重力を右へ
//        {
//            Physics2D.gravity = new Vector2(9.81f, 0f);
//            //rb.AddForce(Vector2.right * 9.81f);
//            gamemode = 2;
//            //rb.velocity = new Vector2(100f, rb.velocity.y);
//        }
//        if (Input.GetKeyDown(KeyCode.LeftArrow)) //重力を左へ
//        {
//            Physics2D.gravity = new Vector2(-9.81f, 0f);
//            gamemode = 3;

//        }
//    }

//    void FixedUpdate()
//    {
//        if (gamemode == 0 || gamemode == 1)
//        {
//            float x = Input.GetAxisRaw("Horizontal");
//            //左か右を入力したら
//            if (x != 0)
//            {
//                //入力方向へ移動
//                rb.velocity = new Vector2(x * speed, rb.velocity.y);
//                //localScale.xを-1にすると画像が反転する
//                Vector2 temp = transform.localScale;
//                temp.x = x;
//                transform.localScale = temp;
//            }
//            else
//            {
//                //横移動の速度を0にしてピタッと止まるようにする
//                rb.velocity = new Vector2(0, rb.velocity.y);
//            }
//        }
//    }
//}
