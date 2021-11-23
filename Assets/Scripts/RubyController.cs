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

    public GameObject projectilePrefab;

    Animator animator;
    Vector2 lookDirection = new Vector2(1,0);

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        invincibleTimer = timeInvincible;
        animator = GetComponent<Animator>();
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
        Vector2 move = new Vector2(horizontal, vertical);
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Look Y", lookDirection.y);
        animator.SetFloat("Speed", move.magnitude);

        if (Input.GetKeyDown(KeyCode.C)) {
            Launch();
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
                Debug.Log(isInvincible + "/" + health);
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

    void Launch() {
        GameObject projectileObject = Instantiate(projectilePrefab, rigidbody2d.position + lookDirection*0.8f, Quaternion.identity);
        Projectile projectile = projectileObject.GetComponent<Projectile>();
        projectile.Launch(lookDirection, 300);
        animator.SetTrigger("Launch");
    }

}
