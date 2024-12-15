using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health Settings")]
    public int maxHealth = 3;
    public int currentHealth;

    [Header("UI")]
    public Image healthBar;

    [Header("")]
    [SerializeField] SpriteRenderer playerSprite;
    [SerializeField] SquashAndStretch damageAnimation;
    [SerializeField] ParticleSystem deadParticles;

    private float flashDuration = 0.1f;

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Y))
        {
            damageAnimation.PlaySquashAndStretch();
        }
        */
    }

    private void Start()
    {
        currentHealth = maxHealth;

        healthBar.fillAmount = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // The health never gives -0 
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        StartCoroutine(FeedbackFlash(playerSprite));
        damageAnimation.PlaySquashAndStretch();
        UpdateHealthBar();

        //Color randomColor =new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        //playerSprite.color = randomColor;

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
    }
}
