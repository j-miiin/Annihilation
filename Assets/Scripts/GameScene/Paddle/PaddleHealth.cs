using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;

    [SerializeField] private Image[] hearts;
    [SerializeField] private Color invincibleColor;
    [SerializeField] private int meteorDamage;
    [SerializeField] private float invincibleTime = 3f;

    private bool isInvincible = false;

    private SpriteRenderer playerSpriteRenderer;

    private void Start()
    {
        playerSpriteRenderer = GetComponent<SpriteRenderer>();
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        if (playerHealth <= 0)
        {
            // 스테이지 실패
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
                hearts[i].color = Color.red;
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
            playerSpriteRenderer.color = Color.black;
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
