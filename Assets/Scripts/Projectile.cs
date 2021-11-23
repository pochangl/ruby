using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    Rigidbody2D rbody;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 direction, float force) {
        if (rbody == null) {
            rbody = GetComponent<Rigidbody2D>();
        }
        rbody.AddForce(direction * force);
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Projectile Collision with " + other.gameObject);
        Destroy(gameObject);
    }
}
