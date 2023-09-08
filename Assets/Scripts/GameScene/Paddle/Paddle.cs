using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Paddle : MonoBehaviour
{
    public Rigidbody2D rigidbody;

    const float C_RADIAN = 180f;
    private float rotationX;
    private float speed = 3.0f;
    private float[] shootAngles = { -60, -45, -30, -15, 15, 30, 45, 60 };

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
    private void OnCollisionEnter2D(Collision2D collision)      // 패들에 닿을때마다 무작위 각도 발사
    {
        if (collision.collider.CompareTag("Ball"))
        {
            Vector3 tmp = collision.transform.eulerAngles;
            int r = Random.Range(0, shootAngles.Length);
            tmp.z = shootAngles[r];
            collision.transform.eulerAngles = tmp;
        }
        // if (collision.tag == "Item")
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)      // 한번 발사된 각도로 무한 고정됨
    {
        if(collision.collider.CompareTag("Ball"))
        {
            if (isShoot == false)
            {
                Vector3 tmp = collision.transform.eulerAngles;
                int r = Random.Range(0, shootAngles.Length);
                tmp.z = shootAngles[r];
                collision.transform.eulerAngles = tmp;
                isShoot = true;
            }
            else
            {
                Vector3 tmp = collision.transform.eulerAngles;
                tmp.z = C_RADIAN - tmp.z;
                collision.transform.eulerAngles = tmp;
            }
        }
        // if (collision.tag == "Item")
    }
    */
}
