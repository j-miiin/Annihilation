using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rigidbody;

    private float rotationX;
    private float speed = 3f;
    
    public KeyCode Left;
    public KeyCode Right;

    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rotationX = 0f;
        if (Input.GetKey(Left)) { rotationX -= 1f; }
        if (Input.GetKey(Right)) { rotationX += 1f; }
        rigidbody.velocity = new Vector3(rotationX * speed, 0, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.tag == "Ball")
        // if (collision.tag == "Item")
    }
}
