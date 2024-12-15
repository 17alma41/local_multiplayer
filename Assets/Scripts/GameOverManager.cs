using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject gameOverPanel; 
    [SerializeField] private TextMeshProUGUI winnerText; 

    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
    }

    public void ShowWinner(string winnerName)
    {
        gameOverPanel.SetActive(true);
        winnerText.text = $"{winnerName} win";

        GameManager.controlsEnabled = false;
        //Time.timeScale = 0f; //Pausar el tiempo
    }

    /*
    public void RestartGame()
    {
        Time.timeScale = 1f; //Reactivar el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    */
}
