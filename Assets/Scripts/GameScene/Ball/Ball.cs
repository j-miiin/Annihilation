using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    const float C_RADIAN = 180f;
    public Rigidbody2D rigidbody;
    public Rigidbody2D paddle;

    private float _speed = 5.0f;
    private float[] _shootAngles = { -60, -50, -40, -30, -20, -10, 10, 20, 30, 40, 50, 60 };
    private bool _isShoot = false;

    public KeyCode Space;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        
    }
    void FixedUpdate()
    {
        if (_isShoot == true)
        {
            Vector3 pos = rigidbody.position;
            Vector3 movePos = pos + transform.up * _speed * Time.deltaTime;
            rigidbody.MovePosition(movePos);
        }
        else
        {
            rigidbody.transform.position = paddle.transform.position + new Vector3(0, 0.13f, 0);
            if (Input.GetKey(Space))
                _isShoot = true;
        }

        Vector3 tmp = transform.eulerAngles;
        if (tmp.z == 90)
        {
            tmp.z = 120;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 tmp = transform.eulerAngles;
        // collision.collider.transform.position
        if (collision.collider.CompareTag("TopWall"))
        {
            tmp.z = C_RADIAN - tmp.z;
            transform.eulerAngles = tmp;
        }
        else if (collision.collider.CompareTag("Wall"))
        {
            tmp.z = (C_RADIAN * 2) - tmp.z;
            transform.eulerAngles = tmp;
        }
        else if (collision.collider.CompareTag("Paddle"))
        {
            int r = Random.Range(0, _shootAngles.Length);
            tmp.z = _shootAngles[r];
            transform.eulerAngles = tmp;
        }
        else if (collision.collider.CompareTag("Brick"))    // 미완성
        {
            tmp.z = (C_RADIAN * 2) - tmp.z;
            transform.eulerAngles = tmp;
            // 벽돌 부숴지는 코드
        }
    }
}
