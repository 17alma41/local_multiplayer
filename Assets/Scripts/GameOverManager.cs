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

    private void Start()
    {
        gameOverPanel.SetActive(false);
        GameManager.controlsEnabled = true;

        if (SceneManager.GetActiveScene().name == "FinalScene")
        {
            gameOverPanel.SetActive(true);
            FinalShowWinner();
        }
    }

    public void ShowWinner(string winnerName)
    {
        gameOverPanel.SetActive(true);
        winnerText.text = $"{winnerName} win round";

        GameManager.controlsEnabled = false;
    }

    public void FinalShowWinner()
    {
        string finalWinner = PlayerPrefs.GetString("Winner", "No Winner"); 
        winnerText.text = $"Congratulations! \n {finalWinner}";
    }
}
