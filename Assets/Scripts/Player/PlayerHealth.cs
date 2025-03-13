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

    [SerializeField] private SpriteRenderer playerSprite;
    [SerializeField] private SquashAndStretch damageAnimation;
    [SerializeField] private ParticleSystem bloodParticles;
    [SerializeField] private ParticleSystem deadParticles;

    [Header("Game Over")]
    [SerializeField] private GameOverManager gameOverManager;

    [Header("Sounds")]
    public AudioClip dieSound; 
    public AudioClip damageSound;
    private AudioSource audioSource;

    private Vector3 initialPosition; 
    private float flashDuration = 0.1f;
    private Rigidbody2D rb;

    RoundManager roundManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        audioSource = GetComponent<AudioSource>();

        initialPosition = transform.position;
        ResetPlayer();

        GameObject gameManager = GameObject.Find("GameManager");
        if (gameManager != null)
        {
            roundManager = gameManager.GetComponent<RoundManager>();
        }

        if (gameOverManager == null)
        {
            gameOverManager = FindObjectOfType<GameOverManager>();
        }
    }

    private void ResetPlayer()
    {
        currentHealth = maxHealth; 
        healthBar.fillAmount = 1f; 

        transform.position = initialPosition; 
        rb.velocity = Vector2.zero; 

    }

    public void TakeDamage(int damage, Vector2 knockbackForce)
    {
        audioSource.PlayOneShot(damageSound);
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (knockbackForce != Vector2.zero)
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
        audioSource.PlayOneShot(dieSound);
        playerSprite.color = Color.white;
        deadParticles.Play();
        bloodParticles.Play();

        string winnerName = playerName == "Player 1" ? "Player 2" : "Player 1";

        gameOverManager.ShowWinner(winnerName);
        StartCoroutine(DelayedRoundChange(winnerName));
    }

    IEnumerator DelayedRoundChange(string winnerName)
    {
        yield return new WaitForSeconds(3f);
        roundManager.OnPlayerDeath(winnerName);
    }

}
