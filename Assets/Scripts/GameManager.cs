using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool controlsEnabled = true;
    private PauseMenu pauseMenu;

    private void Start()
    {
        pauseMenu = FindObjectOfType<PauseMenu>();
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    controlsEnabled = true;
        //    SceneManager.LoadScene(0);
        //}

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenu.TogglePause();
        }
    }

    public void PlayAgain()
    {
        FindObjectOfType<SceneTransition>().LoadScene(1);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
