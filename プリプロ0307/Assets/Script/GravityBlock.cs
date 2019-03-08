using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBlock : MonoBehaviour {

    public LayerMask groundLayer;

    private bool isGrounded;
    private bool isGrounded2;
    private bool isGrounded3;
    private bool isGrounded4;

    private bool flg;


    private Star star;
    private Rigidbody2D rb;

  
    // Use this for initialization
    void Start()
    {
        //rb.isKinematic = false;
        star = GameObject.Find("StarPlayer").GetComponent<Star>();
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
       
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        rb.isKinematic = false;
        if (star.gamemode == 0)
        {
            isGrounded2 = false;
            isGrounded3 = false;
            isGrounded4 = false;

            isGrounded = Physics2D.Linecast(transform.position + transform.up * 0f, transform.position - transform.up * 0.5f, groundLayer);//下
            Debug.DrawLine(transform.position + transform.up * 0f, transform.position - transform.up * 0.5f);
            //rb.isKinematic = false;

        }
        if (star.gamemode == 1)
        {
            isGrounded = false;
            isGrounded3 = false;
            isGrounded4 = false;

            isGrounded2 = Physics2D.Linecast(transform.position + transform.up * 0.5f, transform.position - transform.up * 0f, groundLayer);//上
            Debug.DrawLine(transform.position + transform.up * 0.5f, transform.position - transform.up * 0f);
            //rb.isKinematic = false;
        }
        if (star.gamemode == 2)
        {
            isGrounded = false;
            isGrounded4 = false;
            isGrounded2 = false;

            isGrounded3 = Physics2D.Linecast(transform.position + transform.right * 0.5f, transform.position - transform.right * 0f, groundLayer);//右
            Debug.DrawLine(transform.position + transform.right * 0.5f, transform.position - transform.right * 0f);
            //rb.isKinematic = false;
        }
        if (star.gamemode == 3)
        {
            isGrounded = false;
            isGrounded3 = false;
            isGrounded2 = false;

            isGrounded4 = Physics2D.Linecast(transform.position + transform.right * 0f, transform.position - transform.right * 0.5f, groundLayer);//左
            Debug.DrawLine(transform.position + transform.right * 0f, transform.position - transform.right * 0.5f);
            //rb.isKinematic = false;
        }





        if (isGrounded || isGrounded2 || isGrounded3 || isGrounded4)
        {
            Debug.Log("地面");
            rb.velocity = Vector2.zero;
            rb.isKinematic = true;
        }


    }
}

