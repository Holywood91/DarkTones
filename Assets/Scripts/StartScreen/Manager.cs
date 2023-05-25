using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public Animator fadeAnimator;
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void StartGame()
    {
        StartCoroutine(GoToIntroScene());
    }

    public void GoToStartScene()
    {
        StartCoroutine(LoadStartScene());
    }

    public void GotoLevel2()
    {
        StartCoroutine(LoadLevel2());
    }

    IEnumerator GoToIntroScene()
    {
        fadeAnimator.SetTrigger("FadeOutTrigger");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Intro");
    }

    IEnumerator LoadStartScene()
    {
        fadeAnimator.SetTrigger("FadeOutTrigger");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Start");
    }
    
    IEnumerator LoadLevel2()
    {
        fadeAnimator.SetTrigger("FadeOutTrigger");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Level2");
    }
}
