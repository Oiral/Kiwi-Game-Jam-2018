﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public Image fadeImage;

    public void LoadMainScene(){

        StartCoroutine( FadeToScene(1));

    }

    public void Quit(){
        Debug.Log("Application Trying to Quit!");
        Application.Quit();
    }

    public void DefeatBoss(){
        StartCoroutine(FadeToScene(2));
    }

    public void LoadMainMenu(){
        StartCoroutine(FadeToScene(0));
    }

    IEnumerator FadeToScene(int sceneNumber){

        //Spawn fade the white out
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneNumber);

    }

    IEnumerator FadeIn(){
        fadeImage.gameObject.SetActive(true);
        Color col = fadeImage.color;
        col.a = 0;

        for (int i = 0; i < 10; i++)
        {
            col.a += 0.1f;
            fadeImage.color = col;
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Awake()
    {
        StartCoroutine(FadeOutStart());
    }

    IEnumerator FadeOutStart()
    {
        fadeImage.gameObject.SetActive(true);
        Color col = fadeImage.color;
        col.a = 1;
        for (int i = 0; i < 10; i++)
        {
            col.a -= 0.1f;
            fadeImage.color = col;
            yield return new WaitForSeconds(0.1f);
        }
        fadeImage.gameObject.SetActive(false);
    }
}
