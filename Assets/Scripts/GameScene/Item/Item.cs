using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Item : MonoBehaviour
{
    public GameObject item;
    public SpriteRenderer itemColor;
    public Rigidbody2D paddle;
    public Rigidbody2D ball;
    // private bool _isDrop = false;

    void Start()
    {
        itemColor = GetComponent<SpriteRenderer>();
        paddle = GetComponent<Rigidbody2D>();
        ball = GetComponent<Rigidbody2D>();
        // _isDrop = true;
    }
    void Update()
    {
        
    }
    public void GetItem()
    {
        switch (item.name)
        {
            case "Item_paddle_small":
                paddle.transform.localScale -= new Vector3(0.3f, 0.0f, 0.0f);
                Debug.Log("Get Item_paddle_small");
                break;
            case "Item_ball_fast":
                Vector2 dir = ball.velocity.normalized;
                ball.AddForce(dir * 5.0f);
                Debug.Log("Get Item_ball_fast");
                break;
            case "Item_paddle_big":
                paddle.transform.localScale += new Vector3(0.3f, 0.0f, 0.0f);
                Debug.Log("Get Item_paddle_big");
                break;
            case "Item_ball_fireball":
                Debug.Log("Get Item_ball_fireball");
                break;
            case "Item_paddle_shoot":
                Debug.Log("Get Item_paddle_shoot");
                break;
        }
    }
}
