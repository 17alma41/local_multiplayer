using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player Settings")]
    public string playerName;

    [Header("Health Settings")]
    public int maxHealth = 3;
    public int currentHealth;

    [Header("UI")]
    public Image healthBar;

    [Header("")]
    [SerializeField] SpriteRenderer playerSprite;
    [SerializeField] SquashAndStretch damageAnimation;
    [SerializeField] ParticleSystem bloodParticles;
    [SerializeField] ParticleSystem deadParticles;

    [Header("Game Over")]
    [SerializeField] private GameOverManager gameOverManager;

    private float flashDuration = 0.1f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth;

        healthBar.fillAmount = currentHealth;
    }

    public void TakeDamage(int damage, Vector2 knockbackForce)
    {
        currentHealth -= damage;

        // Para que la salud unca llegue a menos de 0
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if(knockbackForce != Vector2.zero)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(knockbackForce, ForceMode2D.Impulse);
        }

        StartCoroutine(FeedbackFlash(playerSprite));
        damageAnimation.PlaySquashAndStretch();
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = (float)currentHealth / maxHealth;
    }

    IEnumerator FeedbackFlash(SpriteRenderer playerSprite)
    {
        float t = flashDuration;

        Color originalColor = playerSprite.color;

        while (t > 0)
        {
            playerSprite.color = new Color(1f, 1f, 1f, t / flashDuration);
            t -= Time.deltaTime;
            yield return null;
        }

        if (currentHealth > 0)
        {
            playerSprite.color = originalColor;
        }
       
    }

    private void Die()
    {
        StopAllCoroutines();
        playerSprite.color = Color.white; 
        deadParticles.Play();
        bloodParticles.Play();

        string winnerName = playerName == "Player 1" ? "Player 2" : "Player 1"; // Encontrar que jugador ha ganado

        gameOverManager.ShowWinner(winnerName);
    }
}
