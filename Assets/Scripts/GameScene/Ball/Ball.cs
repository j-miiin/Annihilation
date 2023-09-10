using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Ball : MonoBehaviour
{
    const float C_RADIAN = 180f;
    public Rigidbody2D ball;
    public Rigidbody2D paddle;

    private float _speed = 5.0f;
    private float[] _shootAngles = { -60, -45, -30, -15, 15, 30, 45, 60 };
    private bool _isShoot = false;

    public KeyCode Space;

    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (_isShoot == true)
        {
            Vector3 pos = paddle.position;
            Vector3 movePos = pos + transform.up * _speed * Time.deltaTime;
            paddle.MovePosition(movePos);
        }
        else
        {
            paddle.transform.position = paddle.transform.position + new Vector3(0, 0.13f, 0);
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
            if (_isShoot == true)
            {
                ContactPoint2D contact = collision.contacts[0];
                Vector2 pos = contact.point;                    
                Vector2 paddlePos = paddle.transform.position;  
                Vector2 shootPos = pos - paddlePos;             
                int r = MakeAngle(shootPos.x);
                tmp.z = _shootAngles[r];
                transform.eulerAngles = tmp;
            }
            else  // 첫 발사 랜덤
            {
                int r = Random.Range(0, _shootAngles.Length);
                tmp.z = _shootAngles[r];
                transform.eulerAngles = tmp;
            }
        }
        else if (collision.collider.CompareTag("Meteor"))    // 미완성
        {
            tmp.z = (C_RADIAN * 2) - tmp.z;
            transform.eulerAngles = tmp;
            // 벽돌 부숴지는 코드
        }
    }
    public int MakeAngle(float x)
    {
        if (x < -0.3f)
            return 7;
        else if (x >= -0.3f && x < -0.2f)
            return 6;
        else if (x >= -0.2f && x < -0.1f)
            return 5;
        else if (x >= -0.1f && x < 0f)
            return 4;
        else if (x >= 0f && x < 0.1f)
            return 3;
        else if (x >= 0.1f && x < 0.2f)
            return 2;
        else if (x >= 0.2f && x < 0.3f)
            return 1;
        else // (x > 0.3f)
            return 0;
    }
}
