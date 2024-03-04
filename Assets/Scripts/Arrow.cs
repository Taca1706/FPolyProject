using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb;

    public int baseDamageAmount = 3;
    public int damageAmount = 3; // l??ng sát th??ng c?a viên ??n
    // Start is called before the first frame update

    public float bulletSpeed = 100f;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //damageAmount = baseDamageAmount;
    }

    // Update is called once per frame

   

    private void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController enemy = other.collider.GetComponent<EnemyController>();
        if(other.gameObject.CompareTag("Enemy"))
        {
            if(enemy != null)
            {
                enemy.TakeDamage(damageAmount);
            }
        }
        /*EnemyController boss = other.gameObject.GetComponent<EnemyController>(); // l?y script ?i?u khi?n k? ??ch
        if (boss != null)
        {
            boss.TakeDamage(damageAmount); // g?i ph??ng th?c tr? máu c?a k? ??ch
        }
        Debug.Log("Projectile collision with " + other.gameObject);
        */
        Destroy(gameObject); //hu? viên ??n sau khi va ch?m
    }


    void Update()
    {
        if (transform.position.magnitude > 10000.0f)
        {
            Destroy(gameObject);
        }
    }

    public void SetDamage(int damage)
    {
        damageAmount = damage;
    }
}
