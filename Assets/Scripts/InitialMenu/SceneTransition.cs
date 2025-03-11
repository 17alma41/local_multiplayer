using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] public CanvasGroup fadeCanvasGroup;
    public float fadeDuration = 1f;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void LoadScene(int sceneNumber)
    {
        StartCoroutine(FadeOut(sceneNumber));
    }

    IEnumerator FadeIn()
    {
        float time = fadeDuration;
        while (time > 0)
        {
            time -= Time.deltaTime;
            fadeCanvasGroup.alpha = time / fadeDuration;
            yield return null;
        }
        fadeCanvasGroup.alpha = 0;
    }

    IEnumerator FadeOut(int sceneNumber)
    {
        float time = 0;
        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            fadeCanvasGroup.alpha = time / fadeDuration;
            yield return null;
        }
        fadeCanvasGroup.alpha = 1;
        SceneManager.LoadScene(sceneNumber);
    }
}
