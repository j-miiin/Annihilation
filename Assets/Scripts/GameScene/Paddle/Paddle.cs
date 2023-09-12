using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UIElements;

public class Paddle : MonoBehaviour
{
    public GameObject item;
    public GameObject paddle;
    public GameObject ball;
    public GameObject bullet;
    

    private Rigidbody2D _paddleRb;
    private SpriteRenderer _paddleSr;
    private BoxCollider2D _paddleBc;
    private Rigidbody2D _ballRb;
    private SpriteRenderer _ballSr;
    private CircleCollider2D _ballCc;

    private GameObject[] _meteor;
    private BoxCollider2D[] _meteorBc;

    private float _rotationX;
    private float _paddlespeed = 5.0f;
    private Sprite[] _changePaddle;

    public KeyCode Left;
    public KeyCode Right;

    void Start()
    {
        _changePaddle = new Sprite[]
        {
            Resources.Load<Sprite>("Image/PaddleImage/paddleBig"),
            Resources.Load<Sprite>("Image/PaddleImage/paddleNormal"),
            Resources.Load<Sprite>("Image/PaddleImage/paddleSmall"),
            Resources.Load<Sprite>("Image/PaddleImage/shootingPaddleBig"),
            Resources.Load<Sprite>("Image/PaddleImage/shootingPaddleNormal"),
            Resources.Load<Sprite>("Image/PaddleImage/shootingPaddleSmall")
        };

        _paddleRb = paddle.GetComponent<Rigidbody2D>();
        _paddleSr = paddle.GetComponent<SpriteRenderer>();
        _paddleBc = paddle.GetComponent<BoxCollider2D>();

        _ballRb = ball.GetComponent<Rigidbody2D>();
        _ballSr = ball.GetComponent<SpriteRenderer>();
        _ballCc = ball.GetComponent<CircleCollider2D>();

        _meteor = GameObject.FindGameObjectsWithTag("Meteor");
        for (int i = 0; i < _meteor.Length; i++)
        {
            _meteorBc[i] = _meteor[i].GetComponent<BoxCollider2D>();
        }
    }

    void Update()
    {
        _rotationX = 0f;
        if (Input.GetKey(Left)) { _rotationX -= 1f; }
        if (Input.GetKey(Right)) { _rotationX += 1f; }
        _paddleRb.velocity = new Vector3(_rotationX * _paddlespeed, 0, 0);
    }
 
    private void OnTriggerEnter2D(Collider2D collision)      // 패들에 닿을때마다 무작위 각도 발사
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
            case "Item_ball_fast":      // 공 물리 수정하고 만드는게 나을듯
                // Vector2 dir = ball.velocity.normalized;
                // ball.AddForce(dir * 5.0f);
                Debug.Log("Get Item_ball_fast");
                break;
            case "Item_paddle_big":
                StopCoroutine("Item_paddle_big");
                StartCoroutine("Item_paddle_big", false);
                Debug.Log("Get Item_paddle_big");
                break;
            case "Item_ball_fireball":      // 4초동안 파이어볼 상태
                StopCoroutine("Item_ball_fireball");
                StartCoroutine("Item_ball_fireball", false);
                Debug.Log("Get Item_ball_fireball");
                break;
            case "Item_paddle_shoot":       // 패들 주황부분이 하늘색으로 바뀌고 4.5초동안 총알이 중앙에서 자동으로 1발씩 15번 발사
                StopCoroutine("Item_paddle_shoot");
                StartCoroutine("Item_paddle_shoot", false);
                Debug.Log("Get Item_paddle_shoot");
                break;
        }
    }
    IEnumerator Item_paddle_big(bool skip)
    {
        if (!skip)
        {
            if (_paddleSr.size.x < 0.8f) // 작은 상태일 때
            {
                if (_paddleBc.CompareTag("ShootingPaddle"))
                {
                    _paddleSr.size = new Vector2(_paddleSr.size.x + 0.25f, 0.2f);
                    _paddleBc.size = new Vector2(_paddleBc.size.x + 0.28f, 0.2f);
                    _paddleSr.sprite = _changePaddle[4];
                }
                else
                {
                    _paddleSr.size = new Vector2(_paddleSr.size.x + 0.25f, 0.2f);
                    _paddleBc.size = new Vector2(_paddleBc.size.x + 0.28f, 0.2f);
                    _paddleSr.sprite = _changePaddle[1];
                }
            }
            else if (_paddleSr.size.x < 1.2f && _paddleSr.size.x > 0.8f)  // 중간 크기 상태일 때
            {
                if (_paddleBc.CompareTag("ShootingPaddle"))
                {
                    _paddleSr.size = new Vector2(_paddleSr.size.x + 0.25f, 0.2f);
                    _paddleBc.size = new Vector2(_paddleBc.size.x + 0.28f, 0.2f);
                    _paddleSr.sprite = _changePaddle[3];
                }
                else
                {
                    _paddleSr.size = new Vector2(_paddleSr.size.x + 0.25f, 0.2f);
                    _paddleBc.size = new Vector2(_paddleBc.size.x + 0.28f, 0.2f);
                    _paddleSr.sprite = _changePaddle[0];
                }
            }
            else { }    // 이미 커진 상태일 때 아무것도 안함 (스코어 올릴순 있음)
            yield return new WaitForSeconds(1);
        }
    }
    IEnumerator Item_paddle_small(bool skip)
    {
        if (_paddleSr.size.x > 1.2f) // 큰 상태일 떄
        {
            if (_paddleBc.CompareTag("ShootingPaddle"))
            {
                _paddleSr.size = new Vector2(_paddleSr.size.x - 0.25f, 0.2f);
                _paddleBc.size = new Vector2(_paddleBc.size.x - 0.22f, 0.2f);
                _paddleSr.sprite = _changePaddle[4];
            }
            else
            {
                _paddleSr.size = new Vector2(_paddleSr.size.x - 0.25f, 0.2f);
                _paddleBc.size = new Vector2(_paddleBc.size.x - 0.22f, 0.2f);
                _paddleSr.sprite = _changePaddle[1];
            }
        }
        else if (_paddleSr.size.x < 1.2f && _paddleSr.size.x > 0.8f)  // 중간 크기 상태일 때
        {
            if (_paddleBc.CompareTag("ShootingPaddle"))
            {
                _paddleSr.size = new Vector2(_paddleSr.size.x - 0.25f, 0.2f);
                _paddleBc.size = new Vector2(_paddleBc.size.x - 0.22f, 0.2f);
                _paddleSr.sprite = _changePaddle[5];
            }
            else
            {
                _paddleSr.size = new Vector2(_paddleSr.size.x - 0.25f, 0.2f);
                _paddleBc.size = new Vector2(_paddleBc.size.x - 0.22f, 0.2f);
                _paddleSr.sprite = _changePaddle[2];
            }
        }
        else { }    // 이미 작은 상태일 때 아무것도 안함 (스코어 올릴순 있음)
        yield return new WaitForSeconds(1);
    }
    IEnumerator Item_ball_fireball(bool skip)
    {
        if (!skip)
        {
            _ballSr.color = Color.red;
            for (int i = 0; i < _meteorBc.Length; i++)
            {
                _meteorBc[i].tag = "WeakMeteor";
                _meteorBc[i].isTrigger = true;
            }
            yield return new WaitForSeconds(4);
        }
        _ballSr.color = Color.white;
        for (int i = 0; i < _meteorBc.Length; i++)
        {
            _meteorBc[i].tag = "Meteor";
            _meteorBc[i].isTrigger = false;
        }
    }
    IEnumerator Item_paddle_shoot(bool skip)
    {
        if (!skip)
        {
            if (_paddleSr.size.x > 1.2f)
            {
                _paddleSr.sprite = _changePaddle[3];
                _paddleBc.tag = "ShootingPaddle";
            }
            else if (_paddleSr.size.x < 1.2f && _paddleSr.size.x > 0.8f)
            {
                _paddleSr.sprite = _changePaddle[4];
                _paddleBc.tag = "ShootingPaddle";
            }
            else // (_paddleSr.size.x < 0.8f)
            {
                _paddleSr.sprite = _changePaddle[5];
                _paddleBc.tag = "ShootingPaddle";
            }
            for (int i = 0; i < 15; i++)
            {
                GameObject Bullet = Instantiate(bullet, _paddleRb.transform.position + new Vector3(0f, 0.1f, 0f), Quaternion.identity);
                Bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, 6f, 0f);
                Destroy(Bullet, 5);
                yield return new WaitForSeconds(0.3f);
            }
            // yield return new WaitForSeconds(4);
        }
        if (_paddleSr.size.x > 1.2f)
        {
            _paddleSr.sprite = _changePaddle[0];
            _paddleBc.tag = "Paddle";
        }
        else if (_paddleSr.size.x < 1.2f && _paddleSr.size.x > 0.8f)
        {
            _paddleSr.sprite = _changePaddle[1];
            _paddleBc.tag = "Paddle";
        }
        else // (_paddleSr.size.x < 0.8f)
        {
            _paddleSr.sprite = _changePaddle[2];
            _paddleBc.tag = "Paddle";
        }
    }
    /*
     * private void OnCollisionEnter2D(Collision2D collision)      // 한번 발사된 각도로 무한 고정됨
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
