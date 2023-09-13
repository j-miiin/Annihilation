using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;

    [SerializeField] private SpriteRenderer[] hearts;
    [SerializeField] private Color invincibleColor;
    [SerializeField] private int meteorDamage;
    [SerializeField] private float invincibleTime = 3f;

    private bool isInvincible = false;

    private SpriteRenderer playerSpriteRenderer;

    private Sprite[] _lifeSprite;

    private void Start()
    {
        _lifeSprite = new Sprite[]
        {
            Resources.Load<Sprite>("Image/BallImage/DefaultBall"),
            Resources.Load<Sprite>("Image/BallImage/CheeseBall")
        };

        PaddleType paddleType = GameManager.Instance.GetPaddleType();
        for (int i = 0; i < hearts.Length; i++) hearts[i].sprite = _lifeSprite[(int)paddleType];

        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        if (playerHealth <= 0)
        {
            GameManager.Instance.GameOver();
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                hearts[i].color = Color.white;
            }
            else
            {
                hearts[i].color = Color.black;
            }
        }
    }

    public void PaddleInvincible()
    {
        isInvincible = true;
        StartCoroutine(PaddleNotInvincible());

        if (playerSpriteRenderer != null)
        {
            playerSpriteRenderer.color = invincibleColor;
        }
    }

    private IEnumerator PaddleNotInvincible()
    {
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;

        if (playerSpriteRenderer != null)
        {
            playerSpriteRenderer.color = Color.white;
        }
    }

    public bool IsInvincible()
    {
        return isInvincible;
    }

    private void OnParticleCollision(GameObject other)
    {
        if (!IsInvincible())
        {
            TakeDamage(meteorDamage);
        }
    }

    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        UpdateHealth();
        PaddleInvincible();
    }
}
