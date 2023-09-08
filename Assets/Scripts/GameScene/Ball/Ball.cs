using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    const float C_RADIAN = 180f;
    public Rigidbody2D rigidbody;
    private float speed = 5.0f;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Vector3 pos = rigidbody.position;
        Vector3 movePos = pos + transform.up * speed * Time.deltaTime;
        rigidbody.MovePosition(movePos);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("TopWall"))
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z = C_RADIAN - tmp.z;
            transform.eulerAngles = tmp;
        }
        else if (collision.collider.CompareTag("Wall"))
        {
            Vector3 tmp = transform.eulerAngles;
            tmp.z = (C_RADIAN * 2) - tmp.z;
            transform.eulerAngles = tmp;
        }
    }
}
