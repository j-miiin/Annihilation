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
    private TrailRenderer _trailRenderer;

    private bool _isShoot = false;
    private float _rotationX;
    private float _paddlespeed = 5.0f;
    private Sprite[] _changePaddleAndBall;
    private PlayerHealth _playerHealth;

    public float baseBallSpeed = 250;
    public float ballSpeed;

    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Space;

    private PaddleType paddleType;

    void Start()
    {
        _changePaddleAndBall = new Sprite[]
        {
            Resources.Load<Sprite>("Image/PaddleImage/PaddleBig"),
            Resources.Load<Sprite>("Image/PaddleImage/PaddleNormal"),
            Resources.Load<Sprite>("Image/PaddleImage/PaddleSmall"),
            Resources.Load<Sprite>("Image/PaddleImage/CheeseBig"),
            Resources.Load<Sprite>("Image/PaddleImage/CheeseNormal"),
            Resources.Load<Sprite>("Image/PaddleImage/CheeseSmall")

        };

        _paddleRb = gameObject.GetComponent<Rigidbody2D>();
        _paddleSr = gameObject.GetComponent<SpriteRenderer>();
        _paddleBc = gameObject.GetComponent<BoxCollider2D>();

        _ballRb = ball.GetComponent<Rigidbody2D>();
        _ballSr = ball.GetComponent<SpriteRenderer>();
        _ballCc = ball.GetComponent<CircleCollider2D>();
        _trailRenderer = ball.GetComponent<TrailRenderer>();
        _playerHealth = GetComponent<PlayerHealth>();

        paddleType = GameManager.Instance.GetPaddleType();

        _paddleSr.sprite = _changePaddleAndBall[(int)paddleType * 3 + 1];

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
                _ballRb.AddForce(new Vector2(0.1f, 0.9f).normalized * ballSpeed);      // ó�� �߻� ���� �ϴ� �����Ǿ� ����
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
            NewSoundManager.instance.PlayPlayerItemPickupSound();
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
            case "Item_ball_fast":         // 15�ʵ��� �� 1.2�� ������
                StopCoroutine("Item_ball_fast");
                StartCoroutine("Item_ball_fast", false);
                Debug.Log("Get Item_ball_fast");
                break;
            case "Item_paddle_big":
                StopCoroutine("Item_paddle_big");
                StartCoroutine("Item_paddle_big", false);
                Debug.Log("Get Item_paddle_big");
                break;
            case "Item_ball_strongball":    // 10�ʵ��� �ѹ��� 3�㾿 �μ��� �� (���?���� �ѹ�)
                StopCoroutine("Item_ball_strongball");
                StartCoroutine("Item_ball_strongball", false);
                Debug.Log("Item_ball_strongball");
                break;
            case "Item_paddle_shoot":       // 4.5�ʵ��� �Ѿ��� �߾ӿ��� �ڵ����� 1�߾� 15�� �߻� (���?���� �ѹ�)
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
            if (_paddleSr.size.x < 0.8f) // ���� ������ ��
            {
                _paddleSr.size = new Vector2(_paddleSr.size.x + 0.25f, 0.2f);
                _paddleBc.size = new Vector2(_paddleBc.size.x + 0.2f, 0.2f);
                _paddleSr.sprite = _changePaddleAndBall[(int)paddleType * 3 + 1];   // Normal�� ����
                Debug.Log(_paddleSr.sprite.name);
            }
            else if (_paddleSr.size.x < 1.2f && _paddleSr.size.x > 0.8f)  // �߰� ũ�� ������ ��
            {
                _paddleSr.size = new Vector2(_paddleSr.size.x + 0.25f, 0.2f);
                _paddleBc.size = new Vector2(_paddleBc.size.x + 0.2f, 0.2f);
                _paddleSr.sprite = _changePaddleAndBall[(int)paddleType * 3]; // Big���� ����
                Debug.Log(_paddleSr.sprite.name);
            }
            else { }    // �̹� Ŀ�� ������ �� �ƹ��͵� ���� (���ھ� �ø��� ����)
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator Item_paddle_small(bool skip)
    {
        if (_paddleSr.size.x > 1.2f) // ū ������ ��
        {
            _paddleSr.size = new Vector2(_paddleSr.size.x - 0.25f, 0.2f);
            _paddleBc.size = new Vector2(_paddleBc.size.x - 0.2f, 0.2f);
            _paddleSr.sprite = _changePaddleAndBall[(int)paddleType * 3 + 1]; // Normal�� ����
            Debug.Log(_paddleSr.sprite.name);
        }
        else if (_paddleSr.size.x < 1.2f && _paddleSr.size.x > 0.8f)  // �߰� ũ�� ������ ��
        {
            _paddleSr.size = new Vector2(_paddleSr.size.x - 0.25f, 0.2f);
            _paddleBc.size = new Vector2(_paddleBc.size.x - 0.2f, 0.2f);
            _paddleSr.sprite = _changePaddleAndBall[(int)paddleType * 3 + 2];     // Small�� ����
            Debug.Log(_paddleSr.sprite.name);
        }
        else { }    // �̹� ���� ������ �� �ƹ��͵� ���� (���ھ� �ø��� ����)
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

            if (_trailRenderer != null)
            {
                _trailRenderer.startColor = Color.blue;
                _trailRenderer.endColor = Color.white;
            }

            yield return new WaitForSeconds(10);
        }

        _ballSr.color = Color.white;
        _ballCc.tag = "Ball";

        if (_trailRenderer != null)
        {
            _trailRenderer.startColor = Color.red;
            _trailRenderer.endColor = Color.white;
        }
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
            if (_playerHealth.playerHealth <= 4)
            {
                _playerHealth.playerHealth += 1;
                _playerHealth.UpdateHealth();
            }
            yield return new WaitForSeconds(0);
        }
        
    }
}
