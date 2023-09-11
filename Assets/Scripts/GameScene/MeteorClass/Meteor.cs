using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public string Name { get; }
    public int Hardness { get; set; }
    public int Score { get; set; }

    private SpriteRenderer spriteRenderer;
    private ParticleSystem particle;
    private BoxCollider2D boxCollider;

    private Sprite[] ChangeMeteors;

    GameObject item;
    public Meteor(string name, int hardness, int score)
    {
        Name = name;
        Hardness = hardness;
        Score = score;
        
    }

	private void Awake()
    {
		ChangeMeteors = new Sprite[]
		{
			Resources.Load<Sprite>("Image/MeteorImage/EasyMeteorBrick"),
			Resources.Load<Sprite>("Image/MeteorImage/NormalMeteorBrick"),
			Resources.Load<Sprite>("Image/MeteorImage/HardMeteorBrick")
		};

		spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        particle = GetComponentInChildren<ParticleSystem>();

		spriteRenderer.sprite = ChangeMeteors[Hardness - 1];
	}

	private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Hardness--;
            if (Hardness <= 0)
            {
                StartCoroutine(DestroyMeteor());
                ItemManager.instance.ItemGenerator(boxCollider.transform.position);
            }
            else
            {
				spriteRenderer.sprite = ChangeMeteors[Hardness - 1];
			}
		}
    }

    private IEnumerator DestroyMeteor()
    {
        particle.Play();

        GameManager.I.UpdateScore(Score);

		spriteRenderer.enabled = false;
        boxCollider.enabled = false;
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
