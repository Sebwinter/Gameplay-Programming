using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;
    private Rigidbody rb;
    private float moveInputX;
    private float moveInputZ;
    public float jumpForce;


    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public float dashSpeed;
    private float dashTime;
    public float startDashTime;
    private int direction;

   
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
        dashTime = startDashTime;
    }

    void FixedUpdate()
    {
        moveInputZ = Input.GetAxisRaw("Vertical");
        moveInputX = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector3(moveInputX * speed, 0, rb.velocity.z);
        rb.velocity = new Vector3(0, rb.velocity.x, moveInputZ * speed);
    }
    

    void Update()
    {
        
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = Vector3.left * speed;
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = Vector3.right * speed;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            rb.velocity = Vector3.up * speed;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = Vector3.down * speed;
        }




        //if (Input.GetKey(KeyCode.UpArrow) && isJumping == true)
        //{
        //    if (jumpTimeCounter > 0)
        //    {
        //        rb.velocity = Vector2.up * jumpForce;
        //        jumpTimeCounter -= Time.deltaTime;

        //    }
        //    else
        //    {
        //        isJumping = false;

        //    }

        //    if (Input.GetKeyUp(KeyCode.UpArrow))
        //    {
        //        isJumping = false;

        //    }

        //}

        //if (direction == 0)
        //{
        //    if(Input.GetKey(KeyCode.LeftArrow) && Input.GetKeyUp(KeyCode.Space))
        //    {
        //        direction = 1;

        //    }
        //    else if(Input.GetKey(KeyCode.RightArrow) && Input.GetKeyUp(KeyCode.Space))
        //    {
        //        direction = 2;

        //    }

        //}
        //else
        //{
        //    if (dashTime <= 0)
        //    {
        //        direction = 0;
        //        dashTime = startDashTime;
        //        rb.velocity = Vector3.zero;
        //    }
        //    else
        //    {
        //        dashTime -= Time.deltaTime;

        //        if(direction == 1)
        //        {
        //            rb.velocity = Vector3.left * dashSpeed;

        //        }
        //        else if(direction == 2)
        //        {
        //            rb.velocity = Vector3.right * dashSpeed;
        //        }

        //    }

        //}
       

    }

}
