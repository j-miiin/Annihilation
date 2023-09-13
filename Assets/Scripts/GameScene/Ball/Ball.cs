using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class Ball : MonoBehaviour
{
    const float C_RADIAN = 180f;
    GameObject paddle;
    
    private float _speed = 4.0f;
    private Rigidbody2D _ballRb;
    private float _ballMag;

    private Sprite[] _ballSprite;
    
    void Start()
    {
        _ballSprite = new Sprite[]
        {
            Resources.Load<Sprite>("Image/BallImage/DefaultBall"),
            Resources.Load<Sprite>("Image/BallImage/CheeseBall")
        };

        PaddleType paddleType = GameManager.Instance.GetPaddleType();
        gameObject.GetComponent<SpriteRenderer>().sprite = _ballSprite[(int)paddleType];

        _ballRb = ball.GetComponent<Rigidbody2D>();
        paddle = GameObject.Find("Paddle");
    }

    void FixedUpdate()
    {
        _ballMag = _ballRb.velocity.magnitude;
        if (paddle.GetComponent<Paddle>().ballSpeed == 250)
        {
            if (_ballMag < 4.7f || _ballMag > 5.1f)
            {
                paddle.GetComponent<Paddle>().BallAddForce(_ballRb);
            }
        }
        else
        {
            if (_ballMag < 5.7f || _ballMag > 6)
            {
                paddle.GetComponent<Paddle>().BallAddForce(_ballRb);
            }
        }
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector3 contactPoint = collision.contacts[0].point;
        if (collision.collider.CompareTag("TopWall"))
        {
            _ballRb.velocity = Vector2.zero;
            _ballRb.AddForce((_ballRb.transform.position - contactPoint).normalized * paddle.GetComponent<Paddle>().ballSpeed);
        }
        else if (collision.collider.CompareTag("Wall"))
        {

        }
        else if (collision.collider.CompareTag("Paddle"))
        {
            _ballRb.velocity = Vector2.zero;
            _ballRb.AddForce((_ballRb.transform.position - collision.transform.position).normalized * paddle.GetComponent<Paddle>().ballSpeed);
        }
        else if (collision.collider.CompareTag("Meteor"))
        {
            _ballRb.velocity = Vector2.zero;
            _ballRb.AddForce((_ballRb.transform.position - collision.transform.position).normalized * paddle.GetComponent<Paddle>().ballSpeed);
        }
        else if (collision.collider.CompareTag("Bottom"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
