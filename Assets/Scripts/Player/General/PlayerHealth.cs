using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 3;
    public int currentHealth;

    [Header("")]
    [SerializeField] SpriteRenderer playerSprite;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        Color randomColor =new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        playerSprite.color = randomColor;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        playerSprite.color = Color.red; 
    }
}
