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

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        direction = new Vector2(1, 0);
        ChangeDirection();
    }

    void ChangeDirection()
    {
        direction = directions[directionIndex % 4];
        directionIndex += 1;
        timer = changeTime;
    }

    void FixedUpdate()
    {
        if (timer < 0)
        {
            ChangeDirection();
        }

        timer -= Time.deltaTime;
        Vector2 position = rbody.position;
        position = position + direction * Time.deltaTime * speed;
        rbody.MovePosition(position);
    }
}
