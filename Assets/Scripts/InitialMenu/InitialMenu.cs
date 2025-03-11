using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitialMenu : MonoBehaviour
{
    public void PlayGame()
    {
        FindObjectOfType<SceneTransition>().LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //FindObjectOfType<SceneTransition>().LoadScene("MainScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
