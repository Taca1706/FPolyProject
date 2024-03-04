using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    //public float speed = 10.0f;

    public int maxHealth = 20;
    public float timeInvincible = 2.0f;

    public int health { get { return currentHealth; } }
    int currentHealth;

    bool isInvincible;
    float invincibleTimer;

    //Rigidbody2D rigidbody2d;
    //float horizontal;
    //float vertical;

    public EnemyHealthBar bossHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth / 2;
        bossHealthBar.SetMaxHealth(maxHealth/2);
        //BossHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        //BossHealthBar.instance.updateBossHealthText(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        //horizontal = 0f;
        //vertical = 0f;

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    /*void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        //position.x = position.x + 0;
        //position.y = position.y + 0;

        rigidbody2d.MovePosition(position);
    }*/

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        //BossHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // tr? máu t? l??ng sát th??ng nh?n vào

        if (currentHealth <= 0)
        {
            Die();
        }
        Debug.Log(currentHealth + "/" + maxHealth);
        bossHealthBar.SetHealth(currentHealth);
        //BossHealthBar.instance.SetValue(currentHealth / (float)maxHealth);
        //BossHealthBar.instance.updateBossHealthText(currentHealth);
    }

    private void Die()
    {
        Destroy(gameObject); // hu? k? ??ch sau khi ch?t
        Destroy(bossHealthBar.gameObject);
    }
}
