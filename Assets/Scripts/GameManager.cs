using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool controlsEnabled = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            controlsEnabled = true;
            SceneManager.LoadScene(0);
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
