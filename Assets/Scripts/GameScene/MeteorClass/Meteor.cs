using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public string Name { get; }
    public int Hardness { get; set; }

    private SpriteRenderer spriteRenderer;
    private ParticleSystem particle;
    private BoxCollider2D boxCollider;

    private Color[] hardnessColors;



    public Meteor(string name, int hardness)
    {
        Name = name;
        Hardness = hardness;

        hardnessColors = new Color[]
        {
            Color.white,
            Color.gray,
            Color.black
        };
    }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        particle = GetComponentInChildren<ParticleSystem>();

        spriteRenderer.color = hardnessColors[Hardness - 1];
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Hardness--;
            if (Hardness <= 0)
            {
                StartCoroutine(DestroyMeteor());
            }
            else
            {
                spriteRenderer.color = hardnessColors[Hardness - 1];
            }
        }
    }

    private IEnumerator DestroyMeteor()
    {
        particle.Play();

        spriteRenderer.enabled = false;
        boxCollider.enabled = false;
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
