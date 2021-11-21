using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 3.0f;
    public int maxHealth = 5;
    public float timeInvincible = 2.0f;
    float invincibleTimer;
    bool isInvincible = false;

    int currentHealth;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    public int health { get { return currentHealth; } }

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        invincibleTimer = timeInvincible;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
                invincibleTimer = timeInvincible;
            }
        }

    }

    void FixedUpdate()
    {
        Vector2 speed2d = new Vector2(horizontal, vertical) * speed * Time.deltaTime;

        Vector2 position = rigidbody2d.position + speed2d;
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (!isInvincible)
            {
                print(isInvincible + "/" + health);
                currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
                isInvincible = true;
                Debug.Log(currentHealth + "/" + maxHealth);
            }
        }
        else
        {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
            Debug.Log(currentHealth + "/" + maxHealth);
        }

    }
}
