using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    public GameObject item;

    private string[] _colors = { "red", "yellow", "green", "blue", "cyan", "white" };
    private string[] _itemName = { "Item_paddle_small", "Item_paddle_big", "Item_ball_fast", "Item_ball_strongball", "Item_paddle_shoot", "Item_add_life" };
    private Sprite[] _itemImage;
    private void Awake()
    {
        instance = this;
    }
    public void ItemGenerator(Vector2 Meteor)
    {
        _itemImage = new Sprite[]
        {
            Resources.Load<Sprite>("Image/ItemImage/Item_Smallpaddle"),
            Resources.Load<Sprite>("Image/ItemImage/Item_Bigpaddle"),
            Resources.Load<Sprite>("Image/ItemImage/Item_Fastball"),
            Resources.Load<Sprite>("Image/ItemImage/Item_Strongball"),
            Resources.Load<Sprite>("Image/ItemImage/Item_Shootpaddle"),
            Resources.Load<Sprite>("Image/ItemImage/Item_Life")
        };

        int x = Random.Range(0, 100); // 5대신 10 하면 20%에서 10%
        if (x < 20)
        {
            int c = Random.Range(0, _colors.Length);
            string currentName = "";
            switch (c)
            {
                case 0:
                    currentName = _itemName[c];
                    item.GetComponent<SpriteRenderer>().sprite = _itemImage[c];
                    break;
                case 1:
                    currentName = _itemName[c];
                    item.GetComponent<SpriteRenderer>().sprite = _itemImage[c];
                    break;
                case 2:
                    currentName = _itemName[c];
                    item.GetComponent<SpriteRenderer>().sprite = _itemImage[c];
                    break;
                case 3:
                    currentName = _itemName[c];
                    item.GetComponent<SpriteRenderer>().sprite = _itemImage[c];
                    break;
                case 4:
                    currentName = _itemName[c];
                    item.GetComponent<SpriteRenderer>().sprite = _itemImage[c];
                    break;
                case 5:
                    currentName = _itemName[c];
                    item.GetComponent<SpriteRenderer>().sprite = _itemImage[c];
                    break;
            }
            GameObject Item = Instantiate(item, Meteor, Quaternion.identity);
            Item.name = currentName;
            Item.GetComponent<Rigidbody2D>().velocity = new Vector3(0f, -2f, 0f);
            Destroy(Item, 7);
        }
    }
}
