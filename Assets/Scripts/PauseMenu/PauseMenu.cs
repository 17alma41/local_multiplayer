using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel; // Asigna el Panel en Unity
    private bool isPaused = false;

    void Start()
    {
        pausePanel.SetActive(false); // Asegurar que el panel esté oculto al inicio
    }

    void Update()
    {
        
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausa el juego
            pausePanel.SetActive(true);
        }
        else
        {
            ResumeGame();
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Reanuda el juego
        pausePanel.SetActive(false);
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f; // Asegurar que el tiempo sea normal al salir
        SceneManager.LoadScene(0);
    }
}
