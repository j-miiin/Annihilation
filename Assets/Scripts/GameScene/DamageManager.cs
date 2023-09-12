using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    [SerializeField] private int meteorDamage;

    [SerializeField] private PaddleHealth _paddleHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Paddle"))
        {
            Damage();
        }
    }

    void Damage()
    {
        _paddleHealth.playerHealth = _paddleHealth.playerHealth - meteorDamage;
        _paddleHealth.UpdateHealth();
        gameObject.SetActive(false);
    }
}
