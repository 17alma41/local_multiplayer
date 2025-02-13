using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    [SerializeField] int totalRounds = 3;
    [SerializeField] int currentRounds;

    [SerializeField] bool isRoundActive = false;

    void Start()
    {
        StartRound();
    }

    void StartRound()
    {
        if (currentRounds < totalRounds)
        {
            isRoundActive = true;
            print("Nueva ronda");
        }
        else
        {
            print("Termino");
            StartCoroutine(LoadSceneAfterDelay("SampleScene", 3f)); 
        }
    }

    void EndRound()
    {
        if (isRoundActive)
        {
            isRoundActive = false;
            print("Ronda " + currentRounds + " termino");

            currentRounds++;

            Invoke("StartRound", 2);
        }
    }

    public void OnPlayerDeath()
    {
        // TO-DO: Hay que poner el false el gameOverManager para que cargue la siguiente escena y ponga
        // en false el panel de GameOver

        EndRound();
    }

    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}