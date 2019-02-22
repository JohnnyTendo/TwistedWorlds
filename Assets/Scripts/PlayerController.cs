using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float jumpSpeed;
    public float moveSpeed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
        }
        if (Input.GetKeyDown("a"))
        {
            rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
        }
        if (Input.GetKeyDown("d"))
        {
            rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }
    }
}
