using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private int totalRounds = 3;
    private int currentRounds = 0;
    private bool isRoundActive = false;

    void Start()
    {
        currentRounds = 0;
        StartRound();
    }

    void StartRound()
    {
        if (currentRounds < totalRounds)
        {
            isRoundActive = true;
            print("Nueva ronda: " + (currentRounds + 1));
        }
        else
        {
            print("Juego terminado, cargando pantalla final...");
            StartCoroutine(LoadSceneAfterDelay("Round2", 3f));
        }
    }

    void EndRound()
    {
        if (isRoundActive)
        {
            isRoundActive = false;
            print("Ronda " + (currentRounds + 1) + " terminada");

            currentRounds++;

            if (currentRounds < totalRounds)
            {
                StartCoroutine(RestartRoundWithDelay(3f)); // Reiniciar la escena después de 3s
            }
            else
            {
                StartCoroutine(LoadSceneAfterDelay("Round2", 3f));
            }
        }
    }

    public void OnPlayerDeath(string winnerName)
    {
        StartCoroutine(EndRoundWithDelay(winnerName));
    }

    IEnumerator EndRoundWithDelay(string winnerName)
    {
        yield return new WaitForSeconds(3f);
        EndRound();
    }

    IEnumerator RestartRoundWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Invocar evento de nueva ronda y el resto de gente actua en consecuencia despues del delay
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reiniciar escena
    }

    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
