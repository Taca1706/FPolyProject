using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Rigidbody2D rigidbody2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    float movePrefix = 6;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rigidbody2d.AddForce(Vector2.up * movePrefix, ForceMode2D.Impulse);
        } 
        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.flipX = true;
            rigidbody2d.AddForce(Vector2.left * movePrefix * 0.5f, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = false;
            rigidbody2d.AddForce(Vector2.right * movePrefix * 0.5f, ForceMode2D.Impulse);
        }
    }
}
