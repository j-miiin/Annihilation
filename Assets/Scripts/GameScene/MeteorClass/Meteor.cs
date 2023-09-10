using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public string Name { get; }
    public int Hardness { get; set; }

    private SpriteRenderer spriteRenderer;

    private Color[] hardnessColors;

    private ParticleSystem particle;

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
        spriteRenderer.color = hardnessColors[Hardness - 1];

        particle = GetComponentInChildren<ParticleSystem>();
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
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
