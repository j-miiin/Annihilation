using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UIElements;

public class Paddle : MonoBehaviour
{
    public GameObject item;
    public GameObject ball;
    public GameObject bullet;

    private Rigidbody2D _paddleRb;
    private SpriteRenderer _paddleSr;
    private BoxCollider2D _paddleBc;
    private Rigidbody2D _ballRb;
    private SpriteRenderer _ballSr;
    private CircleCollider2D _ballCc;

    private bool _isShoot = false;
    private float _rotationX;
    private float _paddlespeed = 5.0f;
    private Sprite[] _changePaddleAndBall;

    public float baseBallSpeed = 250;
    public float ballSpeed;

    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Space;

    void Start()
    {
        _changePaddleAndBall = new Sprite[]
        {
            Resources.Load<Sprite>("Image/PaddleImage/PaddleBig"),
            Resources.Load<Sprite>("Image/PaddleImage/PaddleNormal"),
            Resources.Load<Sprite>("Image/PaddleImage/PaddleSmall")
        };

        _paddleRb = gameObject.GetComponent<Rigidbody2D>();
        _paddleSr = gameObject.GetComponent<SpriteRenderer>();
        _paddleBc = gameObject.GetComponent<BoxCollider2D>();

        _ballRb = ball.GetComponent<Rigidbody2D>();
        _ballSr = ball.GetComponent<SpriteRenderer>();
        _ballCc = ball.GetComponent<CircleCollider2D>();

        StopCoroutine("GameInit");
        StartCoroutine("GameInit");
    }

    void Update()
    {
        _rotationX = 0f;
        if (Input.GetKey(Left)) { _rotationX -= 1f; }
        if (Input.GetKey(Right)) { _rotationX += 1f; }
        _paddleRb.velocity = new Vector3(_rotationX * _paddlespeed, 0, 0);

        if (_isShoot == false)
        {
            _ballRb.transform.position = _paddleRb.transform.position + new Vector3(0, 0.12f, 0);
        }
    }
    IEnumerator GameInit()
    {
        while (true)
        {
            if (!_isShoot && (Input.GetKey(Space)))
            {
                _isShoot = true;
                ballSpeed = baseBallSpeed;
                _ballRb.AddForce(new Vector2(0.1f, 0.9f).normalized * ballSpeed);      // 처음 발사 방향 일단 고정되어 있음
            }
            yield return new WaitForSeconds(0.01f);
        }
    }
    public void BallAddForce(Rigidbody2D BallRb)
    {
        Vector2 dir = BallRb.velocity.normalized;
        BallRb.velocity = Vector2.zero;
        BallRb.AddForce(dir * ballSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            GetItem(collision);
        }
    }
    public void GetItem(Collider2D collision)
    {
        switch (collision.gameObject.name)
        {
            case "Item_paddle_small":
                StopCoroutine("Item_paddle_small");
                StartCoroutine("Item_paddle_small", false);
                Debug.Log("Get Item_paddle_small");
                break;
            case "Item_ball_fast":         // 15초동안 공 1.2배 빨라짐
                StopCoroutine("Item_ball_fast");
                StartCoroutine("Item_ball_fast", false);
                Debug.Log("Get Item_ball_fast");
                break;
            case "Item_paddle_big":
                StopCoroutine("Item_paddle_big");
                StartCoroutine("Item_paddle_big", false);
                Debug.Log("Get Item_paddle_big");
                break;
            case "Item_ball_strongball":    // 10초동안 한번에 3겹씩 부수는 공 (모든 벽돌 한방)
                StopCoroutine("Item_ball_strongball");
                StartCoroutine("Item_ball_strongball", false);
                Debug.Log("Item_ball_strongball");
                break;
            case "Item_paddle_shoot":       // 4.5초동안 총알이 중앙에서 자동으로 1발씩 15번 발사 (모든 벽돌 한방)
                StopCoroutine("Item_paddle_shoot");
                StartCoroutine("Item_paddle_shoot", false);
                Debug.Log("Get Item_paddle_shoot");
                break;
            case "Item_add_life":
                StopCoroutine("Item_add_life");
                StartCoroutine("Item_add_life", false);
                Debug.Log("Get Item_add_life");
                break;
        }
    }
    IEnumerator Item_paddle_big(bool skip)
    {
        if (!skip)
        {
            if (_paddleSr.size.x < 0.8f) // 작은 상태일 때
            {
                _paddleSr.size = new Vector2(_paddleSr.size.x + 0.25f, 0.2f);
                _paddleBc.size = new Vector2(_paddleBc.size.x + 0.2f, 0.2f);
                _paddleSr.sprite = _changePaddleAndBall[1];
            }
            else if (_paddleSr.size.x < 1.2f && _paddleSr.size.x > 0.8f)  // 중간 크기 상태일 때
            {
                _paddleSr.size = new Vector2(_paddleSr.size.x + 0.25f, 0.2f);
                _paddleBc.size = new Vector2(_paddleBc.size.x + 0.2f, 0.2f);
                _paddleSr.sprite = _changePaddleAndBall[0];
            }
            else { }    // 이미 커진 상태일 때 아무것도 안함 (스코어 올릴순 있음)
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator Item_paddle_small(bool skip)
    {
        if (_paddleSr.size.x > 1.2f) // 큰 상태일 떄
        {
            _paddleSr.size = new Vector2(_paddleSr.size.x - 0.25f, 0.2f);
            _paddleBc.size = new Vector2(_paddleBc.size.x - 0.2f, 0.2f);
            _paddleSr.sprite = _changePaddleAndBall[1];
        }
        else if (_paddleSr.size.x < 1.2f && _paddleSr.size.x > 0.8f)  // 중간 크기 상태일 때
        {
            _paddleSr.size = new Vector2(_paddleSr.size.x - 0.25f, 0.2f);
            _paddleBc.size = new Vector2(_paddleBc.size.x - 0.2f, 0.2f);
            _paddleSr.sprite = _changePaddleAndBall[2];
        }
        else { }    // 이미 작은 상태일 때 아무것도 안함 (스코어 올릴순 있음)
        yield return new WaitForSeconds(1);
    }
    IEnumerator Item_ball_fast(bool skip)
    {
        if (!skip)
        {
            ballSpeed = 300;
            yield return new WaitForSeconds(15);
        }
        ballSpeed = baseBallSpeed;
    }
    IEnumerator Item_ball_strongball(bool skip)
    {
        if (!skip)
        {
            _ballSr.color = Color.blue;
            _ballCc.tag = "Strongball";
            yield return new WaitForSeconds(10);
        }
        _ballSr.color = Color.white;
        _ballCc.tag = "Ball";
    }
    IEnumerator Item_paddle_shoot(bool skip)
    {
        if (!skip)
        {
            for (int i = 0; i < 15; i++)
            {
                GameObject Bullet = Instantiate(bullet, _paddleRb.transform.position + new Vector3(0f, 0.1f, 0f), Quaternion.identity);
                Bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 6f, 0f);
                Destroy(Bullet, 5);
                yield return new WaitForSeconds(0.3f);
            }
        }
    }
    IEnumerator Item_add_life(bool skip)
    {
        if (!skip)
        { 
            yield return new WaitForSeconds(1);
        }
    }
}
