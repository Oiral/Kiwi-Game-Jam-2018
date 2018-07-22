using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour {

    public Image fadeImage;
    public AudioClip buttonPressSound;


    public void LoadMainScene(){

        StartCoroutine( FadeToScene(2));

    }

    public void Quit(){
        Debug.Log("Application Trying to Quit!");
        Application.Quit();
    }

    public void DefeatBoss(){
        StartCoroutine(FadeToScene(3));
    }

    public void LoadMainMenu(){
        StartCoroutine(FadeToScene(1));
    }

    IEnumerator FadeToScene(int sceneNumber){

        //Spawn fade the white out
        StartCoroutine(FadeIn());
        yield return new WaitForSeconds(2);
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
            yield return new WaitForSeconds(0.05f);
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
            yield return new WaitForSeconds(0.05f);
        }
        fadeImage.gameObject.SetActive(false);
    }

    public void PlayClick(){
        GetComponent<AudioSource>().PlayOneShot(buttonPressSound);
    }
}
