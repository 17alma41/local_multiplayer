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
    }

    public void ShowWinner(string winnerName)
    {
        gameOverPanel.SetActive(true);
        winnerText.text = $"{winnerName} win round";

        GameManager.controlsEnabled = false; 
    }

}
