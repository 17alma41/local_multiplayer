using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    [Header("Bump Settings")]
    [SerializeField] private Transform bumpController;
    [SerializeField] private float bumpRadio;
    [SerializeField] private int bumpDamage;


    [Header("")]
    [SerializeField] private float timeBetweenAttack = 1;
    private float timeToNextAttack;

    [Header("")]
    [SerializeField] private string enemyTag;
    [SerializeField] private KeyCode KeyCode;

    [Header("Animations")]
    [SerializeField] SquashAndStretch attackAnimation;

    [Header("Camera Shake")]
    [SerializeField] private ScreenShake screenShake;


    private void Update()
    {
        if (!GameManager.controlsEnabled)
            return;

        if (timeToNextAttack > 0) { 
            timeToNextAttack -= Time.deltaTime;   
        }

        if (Input.GetKeyDown(KeyCode) && timeToNextAttack <= 0)
        {
            Bump();
            attackAnimation.PlaySquashAndStretch();
            timeToNextAttack = timeBetweenAttack;
        }
    }


    private void Bump()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(bumpController.position, bumpRadio);

        foreach (Collider2D collision in objects)
        {
            if (collision.CompareTag(enemyTag))
            {
                // Calcular la dirección del knockback
                Vector2 knockbackDirection =(collision.transform.position - transform.position).normalized;
                float knockbackStrength = 5f;
                Vector2 knockbackForce = knockbackDirection * knockbackStrength;
            
                collision.transform.GetComponent<PlayerHealth>().TakeDamage(bumpDamage, knockbackForce);

                screenShake.TriggerShake(0.2f, 0.3f);
            }
        };
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(bumpController.position, bumpRadio);
    }
}
