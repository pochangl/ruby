using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1;
    Rigidbody2D rbody;
    Vector2 direction;
    int directionIndex = 0;

    Vector2[] directions = { new Vector2(1, 0), new Vector2(0, 1), new Vector2(-1, 0), new Vector2(0, -1) };

    public float changeTime = 3.0f;

    float timer;

    Animator animator;

    bool broken = true;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        direction = new Vector2(1, 0);
        animator = GetComponent<Animator>();
        ChangeDirection();
    }

    void ChangeDirection()
    {
        direction = directions[directionIndex % 4];
        directionIndex += 1;
        timer = changeTime;
    }

    void Update()
    {
        animator.SetFloat("Move X", direction.x);
        animator.SetFloat("Move Y", direction.y);
    }

    void FixedUpdate()
    {
        if (broken)
        {
            return;
        }
        if (timer < 0)
        {
            ChangeDirection();
        }

        timer -= Time.deltaTime;
        Vector2 position = rbody.position;
        position = position + direction * Time.deltaTime * speed;
        rbody.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();
        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    public void Fix()
    {
        broken = false;
    }
}
