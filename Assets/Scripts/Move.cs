using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using UnityEngine.UIElements;

public class Move : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rb;
    private Animator anim;

    float moveH;
    float moveV;
    private bool isFacingRight = true;

    private bool isclimb = false;

    public float jumpForce = 20f;
    private bool isJumping = true;
    private bool isendjump = false;


    public Vector2 newgravity;
    private bool isgrachange = false;

    float jumptime = 2f;
   
    public float damage = 5f;
    public float maxHP = 10f;
    public float dashForce = 10f;
    public float dashSpd = 80f;

    //public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("v_Ground"))
        {

            if (rb != null)
            {
                isclimb = true;
            }
        }

        if (collision.gameObject.CompareTag("Ground"))
        {

            if (rb != null)
            {
                isclimb = false;
            }
        }

        

        if (collision.gameObject.CompareTag("Wall"))
        {

            if (rb != null)
            {
                rb.gravityScale = -2;
                rb.AddForce(newgravity.normalized * rb.mass * Physics2D.gravity.magnitude, ForceMode2D.Force);
                isgrachange = true;
            }

        }

        if (collision.gameObject.CompareTag("nonWall"))
        {

            if (rb != null)
            {
                rb.gravityScale = 1;
                rb.AddForce(newgravity.normalized * rb.mass * Physics2D.gravity.magnitude, ForceMode2D.Force);
                isgrachange = false;
            }

        }

        /*  if (collision.gameObject.CompareTag("Ground"))
        {
            isendjump = true;
            
        }*/

      

    }

    /*private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            isendjump = false;
        }
    }*/

   



    // Update is called once per frame
    void Update()
    {


        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(moveH*speed, rb.velocity.y);

        flip();

        anim.SetFloat("Speed", Mathf.Abs(moveH));



        if (Input.GetKeyDown(KeyCode.Space) && isJumping==true)
        {
            anim.SetTrigger("Jump");
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

            jumptime -= Time.deltaTime;










            //isendjump = false;
          //  isJumping = false;
            
 
        }
            if(jumptime < 0)
            {
                            isendjump = true;
             }
        /*if(!isJumping)
        {
            
            
        }
        if( isendjump == true)
         {

            anim.SetBool("fall", true);

         }
        
            
        */


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            anim.SetTrigger("Attack");
            
        }

        if(isgrachange == true)
        {
            anim.SetTrigger("climb");
        }


       if(isendjump == true && !isclimb)
        {
            anim.SetBool("fall", true);
        }

    }
    private void FixedUpdate()
    {


        if (isclimb == false)
        {
            rb.velocity = new Vector2(moveH * speed, rb.velocity.y);
        }
        if (isclimb == true)
        {

            //rb.velocity = new Vector2(up_down * 10, rb.velocity.x);
            rb.velocity = new Vector2(moveV * 20, rb.velocity.x);
            if (Input.GetKeyDown(KeyCode.C))
            {
                isclimb = false;
            }
        }

        if (isgrachange == true)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                rb.gravityScale = 1;
            }
        }
    }



    private void flip()
    {
        if (isFacingRight && moveH < 0 || !isFacingRight && moveH > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 sizeOfPlayer = transform.localScale;
            sizeOfPlayer.x *=  -1;
            transform.localScale = sizeOfPlayer;
        }
    }


}
    
