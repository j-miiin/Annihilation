using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class Item : MonoBehaviour
{
    public Rigidbody2D item;
    public SpriteRenderer itemColor;
    public Rigidbody2D paddle;
    public Rigidbody2D ball;
    public Rigidbody2D meteor;
    private bool _isDrop = false;

    private string[] _colors = { "red", "yellow", "green", "blue", "cyan" };
    
    void Start()
    {
        item = GetComponent<Rigidbody2D>();
        itemColor = GetComponent<SpriteRenderer>();
        paddle = GetComponent<Rigidbody2D>();
        ball = GetComponent<Rigidbody2D>();
        _isDrop = true;
    }

    void Update()
    {
        if (_isDrop == true)
        {
            item.velocity = new Vector3(0f, -2, 0f);
        }
    }
    public void GetItem()
    {

    }
    public void RandomItem()
    {
        int x = Random.Range(0, 5); // 5대신 10 하면 20%에서 10%
        if (x == 0)
        {
            ItemGenerator(meteor.transform.position);
        }
        else { }
    }
    void ItemGenerator(Vector2 Meteor)
    {
        int c = Random.Range(0, _colors.Length);
        string currentName = "";
        switch (c)
        {
            case 0:
                itemColor.color = Color.red;
                break;
            case 1:
                itemColor.color = Color.yellow;
                break;
            case 2:
                itemColor.color = Color.green;
                break;
            case 3:
                itemColor.color = Color.blue;
                break;
            case 4:
                itemColor.color = Color.cyan;
                break;
        }
    }
}
