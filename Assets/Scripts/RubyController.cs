using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    public float speed = 3.0f;
    public int maxHealth = 5;
    int currentHealth;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    void FixedUpdate() {

        Vector2 speed2d = new Vector2(horizontal, vertical) * speed * Time.deltaTime;

        Vector2 position = rigidbody2d.position + speed2d;
        rigidbody2d.MovePosition(position);
    }
    void ChangeHealth(int amount) {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
