using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class Ball : MonoBehaviour
{
    const float C_RADIAN = 180f;
    public GameObject ball;
    public GameObject paddle;

    private float _speed = 4.0f;
    // private float[] _xAngles = { -3, -2, -1, 1, 2 , 3};
    // private float[] _yAngles = { 1, 2, 3 };
    private bool _isShoot = false;
    private int[] _shootAngles = { -60, -50, -40, -30, 30, 40, 50, 60 };
    private Rigidbody2D _ballRb;
    private SpriteRenderer _ballSr;
    private CircleCollider2D _ballCc;
    private Rigidbody2D _paddleRb;

    public KeyCode Space;

    void Start()
    {
        _ballRb = ball.GetComponent<Rigidbody2D>();
        _ballSr = ball.GetComponent<SpriteRenderer>();
        _ballCc = ball.GetComponent<CircleCollider2D>();
        _paddleRb = paddle.GetComponent<Rigidbody2D>();

        Launch();
    }
    private void Launch()
    {
        // float x = Random.Range(0, 2) == 0 ? -1 : 1;
        // float y = Random.Range(0, 2) == 0 ? -1 : 1;

        float x = Random.Range(0.5f, 1f);
        float y = Random.Range(0.5f, 1f);

        _ballRb.velocity = new Vector2(x * _speed, y * _speed);
    }
    void FixedUpdate()
    {
        if (_isShoot == true)
        {
            // Vector3 pos = ball.position;
            // Vector3 movePos = pos + transform.up * _speed * Time.deltaTime;
            // ball.MovePosition(movePos);
        }
        else
        {
            _ballRb.transform.position = _paddleRb.transform.position + new Vector3(0, 0.1f, 0);
            if (Input.GetKey(Space))
                _isShoot = true;
        }
        /*
        Vector3 tmp = transform.eulerAngles;
        if (tmp.z == 90)
        {
            tmp.z = 120;
        }
        */
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 tmp = transform.eulerAngles;
        // collision.collider.transform.position
        if (collision.collider.CompareTag("TopWall"))
        {
            // tmp.z = C_RADIAN - tmp.z;
            // transform.eulerAngles = tmp;
        }
        else if (collision.collider.CompareTag("Wall"))
        {
            // tmp.z = (C_RADIAN * 2) - tmp.z;
            // transform.eulerAngles = tmp;
        }
        else if (collision.collider.CompareTag("Paddle"))
        {
            /*
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
            else
            {
                int r = Random.Range(0, _shootAngles.Length);
                tmp.z = _shootAngles[r];
                transform.eulerAngles = tmp;
            }
            */
        } 
        else if (collision.collider.CompareTag("Meteor"))
        {
            // tmp.z = (C_RADIAN * 2) - tmp.z;
            // transform.eulerAngles = tmp;
        }
        else if (collision.collider.CompareTag("Bottom"))
        {
            GameManager.I.GameOver();
        }
    }
    /*
    public int MakeAngle(float x)
    {
        if (x < -0.4f)
            return 7;
        else if (x >= -0.4f && x < -0.27f)
            return 6;
        else if (x >= -0.27f && x < -0.13f)
            return 5;
        else if (x >= -0.13f && x < 0f)
            return 4;
        else if (x >= 0f && x < 0.13f)
            return 3;
        else if (x >= 0.13f && x < 0.27f)
            return 2;
        else if (x >= 0.27f && x < 0.4f)
            return 1;
        else // (x > 0.3f)
            return 0;
    }
    */
}
