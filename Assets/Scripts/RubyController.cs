using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;

    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    void FixedUpdate() {

        Vector2 speed = new Vector2(horizontal, vertical) * 1f * Time.deltaTime;

        Vector2 position = rigidbody2d.position + speed;
        rigidbody2d.MovePosition(position);
    }
}
