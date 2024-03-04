using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class gravitychange : MonoBehaviour
{
    public Vector2 newgravity;
    private Rigidbody2D rb;
    private bool isgrachange = false;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {

            if (rb != null)
            {
                rb.gravityScale = -2;
                rb.AddForce(newgravity.normalized * rb.mass * Physics2D.gravity.magnitude, ForceMode2D.Force);
                isgrachange = true;
            }
            
        }
        

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("nonWall"))
        {

            if (rb != null)
            {
                rb.gravityScale = 1;
                rb.AddForce(newgravity.normalized * rb.mass * Physics2D.gravity.magnitude, ForceMode2D.Force);
                isgrachange = false;
            }
        
        }
        
    }

    private void FixedUpdate()
    {
        

        if (isgrachange == true)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                rb.gravityScale = 1;
            }
        }

    }

   


}

