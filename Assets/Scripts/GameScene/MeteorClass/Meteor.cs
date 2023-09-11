using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    Item i = new Item();
    public string Name { get; }
    public int Hardness { get; set; }

    private GameObject MeteorRenderer;
    private ParticleSystem particle;
    private BoxCollider2D boxCollider;

    private GameObject[] ChangeBricks;



    public Meteor(string name, int hardness)
    {
        Name = name;
        Hardness = hardness;

        //ChangeBricks = new GameObject[]
        //{
        //    Resources.Load<GameObject>("Meteors.EMeteor"),
        //    Resources.Load<GameObject>("Meteors.NMeteor"),
        //    Resources.Load<GameObject>("Meteors.HMeteor")
        //};
    }

	private void Awake()
    {
		MeteorRenderer = GetComponent<GameObject>();
        boxCollider = GetComponent<BoxCollider2D>();
        particle = GetComponentInChildren<ParticleSystem>();

		//MeteorRenderer.prefabs = ChangeBricks[Hardness - 1];
	}

	private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Hardness--;
            if (Hardness <= 0)
            {
                StartCoroutine(DestroyMeteor());
                i.RandomItem();
            }
            else
            {
				//MeteorRenderer.color = ChangeBricks[Hardness - 1];
			}
		}
    }

    private IEnumerator DestroyMeteor()
    {
        particle.Play();

		//MeteorRenderer.enabled = false;
        boxCollider.enabled = false;
        yield return new WaitForSeconds(particle.main.startLifetime.constantMax);
        Destroy(gameObject);
    }
}
