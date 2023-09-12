using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Item : MonoBehaviour
{
    public GameObject item;
    public Rigidbody2D paddleRb;
    public SpriteRenderer paddleSr;
    public BoxCollider2D paddleBc;
    public Rigidbody2D ball;

    private Sprite[] _changePaddle;

    void Start()
    {
        paddleRb = GetComponent<Rigidbody2D>();
        paddleSr = GetComponent<SpriteRenderer>();
        paddleBc = GetComponent<BoxCollider2D>();
        ball = GetComponent<Rigidbody2D>();

        _changePaddle = new Sprite[]
        {
            Resources.Load<Sprite>("Image/PaddleImage/paddleBig"),
            Resources.Load<Sprite>("Image/PaddleImage/paddleNormal"),
            Resources.Load<Sprite>("Image/PaddleImage/paddleSmall")
        };
    }
}
