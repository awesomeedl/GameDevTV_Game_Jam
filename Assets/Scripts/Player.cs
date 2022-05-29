using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector2 velocity;
    float speed = 3f;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity.x = Input.GetAxisRaw("Horizontal");
        velocity.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        rb2d.velocity = velocity * speed;
    }
}
