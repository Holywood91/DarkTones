using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    public GameObject skipSuggestion;
    
    public Animator fadeAnimator;
    // Start is called before the first frame update
    void Start()
    {
        skipSuggestion.SetActive(false);
        StartCoroutine(WaitToRead());
    }

    private void Update()
    {
        if (Input.GetKeyUp("escape"))
        {
            StartCoroutine(GoToLevel1());
        }
    }

    IEnumerator WaitToRead()
    {
        yield return new WaitForSeconds(5);
        skipSuggestion.SetActive(true);
    }

    IEnumerator GoToLevel1()
    {
        fadeAnimator.SetTrigger("FadeOutTrigger");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Level1");
    }
}
