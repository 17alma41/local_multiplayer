using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    [Header("Shake Settings")]
    public float shakeDuration = 0.2f; // Duraci�n del shake
    public float shakeMagnitude = 0.2f; // Magnitud del shake
    public float dampingSpeed = 1.0f; // Velocidad de reducci�n

    private Vector3 initialPosition; // Posici�n inicial de la c�mara
    private float shakeTimeRemaining;

    private void Start()
    {
        initialPosition = transform.localPosition;
    }

    private void Update()
    {
        if (shakeTimeRemaining > 0)
        {
            // Desplazamiento aleatorio
            Vector3 randomOffset = Random.insideUnitSphere * shakeMagnitude;
            transform.localPosition = initialPosition + new Vector3(randomOffset.x, randomOffset.y, 0);

            // Reduce el tiempo restante del shake
            shakeTimeRemaining -= Time.deltaTime * dampingSpeed;
        }
        else
        {
            // Vuelve a la posici�n inicial
            transform.localPosition = initialPosition;
            shakeTimeRemaining = 0;
        }
    }

    public void TriggerShake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
        shakeTimeRemaining = shakeDuration;
    }
}
