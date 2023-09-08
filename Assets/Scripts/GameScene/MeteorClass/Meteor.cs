using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public string Name { get; }
    public int Hardness { get; set; }
    public SpriteRenderer spriteRenderer;

    public Meteor(string name, int hardness)
    {
        Name = name;
        Hardness = hardness;
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Hardness--;
            if (Hardness <= 0)
            {
                DestroyMeteor();
            }
        }
    }

    private void DestroyMeteor()
    {
        gameObject.SetActive(false);
    }
}
