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

    private string[] _colors = { "red", "yellow", "green", "blue", "cyan" };

    void Start()
    {
        itemColor = GetComponent<SpriteRenderer>();
        paddle = GetComponent<Rigidbody2D>();
        ball = GetComponent<Rigidbody2D>();
        // _isDrop = true;
    }
    public void ItemGenerator(Vector2 Meteor)
    {
        int x = Random.Range(0, 50); // 5대신 10 하면 20%에서 10%
        if (x == 0)
        {
            int c = Random.Range(0, _colors.Length);
            string currentName = "";
            switch (c)
            {
                case 0:
                    itemColor.color = Color.red;
                    currentName = "Item_paddle_small";
                    break;
                case 1:
                    itemColor.color = Color.yellow;
                    currentName = "Item_ball_fast";
                    break;
                case 2:
                    itemColor.color = Color.green;
                    currentName = "Item_paddle_big";
                    break;
                case 3:
                    itemColor.color = Color.blue;
                    currentName = "Item_ball_fireball";
                    break;
                case 4:
                    itemColor.color = Color.cyan;
                    currentName = "Item_paddle_shoot";
                    break;
            }
            GameObject Item = Instantiate(item, Meteor, Quaternion.identity);
            Item.name = currentName;
            Item.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -2f, 0f);
        }
    }
}
