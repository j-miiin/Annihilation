using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    public GameObject item;

    private string[] _colors = { "red", "yellow", "green", "blue", "cyan" };
    private string[] _itemName = { "Item_paddle_small", "Item_paddle_big", "Item_ball_fast", "Item_ball_fireball", "Item_paddle_shoot" };
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ItemGenerator(Vector2 Meteor)
    {
        int x = Random.Range(0, 3); // 5대신 10 하면 20%에서 10%
        if (x == 0)
        {
            int c = Random.Range(0, _colors.Length);
            string currentName = "";
            switch (c)
            {
                case 0:
                    currentName = _itemName[c];
                    item.GetComponent<SpriteRenderer>().color = Color.red;
                    break;
                case 1:
                    currentName = _itemName[c];
                    item.GetComponent<SpriteRenderer>().color = Color.green;
                    break;
                case 2:
                    currentName = _itemName[c];
                    item.GetComponent<SpriteRenderer>().color = Color.yellow;
                    break;
                case 3:
                    currentName = _itemName[c];
                    item.GetComponent<SpriteRenderer>().color = Color.blue;
                    break;
                case 4:
                    currentName = _itemName[c];
                    item.GetComponent<SpriteRenderer>().color = Color.cyan;
                    break;
            }
            GameObject Item = Instantiate(item, Meteor, Quaternion.identity);
            Item.name = currentName;
            Item.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -2f, 0f);
            Destroy(Item, 7);
        }
    }
}
