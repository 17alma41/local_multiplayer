using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundManager : MonoBehaviour
{
    [SerializeField] private int totalRounds = 3;
    public static int currentRounds = 0;
    private bool isRoundActive = false;
    private Dictionary<string, int> playerWins = new Dictionary<string, int>();

    void Start()
    {
        LoadPlayerWins();
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
            StartCoroutine(LoadSceneAfterDelay("FinalScene", 1.5f));
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
                string nextScene = "Round" + (currentRounds + 1);
                print("Cargando siguiente ronda: " + nextScene);
                StartCoroutine(RestartRoundWithDelay(1.5f, nextScene)); // Reiniciar la escena después de 1.5s
            }
            else
            {
                print("Se alcanzó el total de rondas, cargando FinalScene...");
                StartCoroutine(LoadSceneAfterDelay("FinalScene", 1.5f));
            }
        }
    }

    public void OnPlayerDeath(string winnerName)
    {
        // Suma las victorias de cada jugador
        if (playerWins.ContainsKey(winnerName))
        {
            playerWins[winnerName]++;
        }
        else
        {
            playerWins[winnerName] = 1;
        }

        PlayerPrefs.SetInt(winnerName, playerWins[winnerName]);

        List<string> players = new List<string>(playerWins.Keys);
        PlayerPrefs.SetString("PlayersList", string.Join(",", players));

        PlayerPrefs.Save();

        StartCoroutine(EndRoundWithDelay(winnerName));
    }

    IEnumerator EndRoundWithDelay(string winnerName)
    {
        yield return new WaitForSeconds(1.5f);
        EndRound();
    }

    IEnumerator RestartRoundWithDelay(float delay, string sceneName)
    {
        yield return new WaitForSeconds(delay);
        // Invocar evento de nueva ronda y el resto de gente actua en consecuencia despues del delay
        SceneManager.LoadScene(sceneName); // Reiniciar escena
    }

    IEnumerator LoadSceneAfterDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);


        if (sceneName == "FinalScene")
        {
            string finalWinner = GetWinner();
            PlayerPrefs.SetString("Winner", finalWinner); // Guardar el ganador con más victorias
            PlayerPrefs.Save(); // Guardar cambios

            currentRounds = 0;
        }

        SceneManager.LoadScene(sceneName);
    }

    // Cuentan todas las victorias realizada a lo largo del juego
    public string GetWinner()
    {
        string winner = "No Winner";
        int maxWins = 0;

        foreach (string playerName in PlayerPrefs.GetString("PlayersList", "").Split(','))
        {
            int wins = PlayerPrefs.GetInt(playerName, 0);

            if (wins > maxWins)
            {
                maxWins = wins;
                winner = playerName;
            }
        }

        return winner;
    }

    void LoadPlayerWins()
    {
        playerWins.Clear(); 

        // Buscar todos los jugadores que han ganado rondas
        foreach (string playerName in PlayerPrefs.GetString("PlayersList", "").Split(','))
        {
            if (!string.IsNullOrEmpty(playerName))
            {
                playerWins[playerName] = PlayerPrefs.GetInt(playerName, 0);
            }
        }
    }
}
