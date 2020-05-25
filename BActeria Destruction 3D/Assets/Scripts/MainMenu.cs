﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public Animator transition;
    public float transitionsTime = 1f;

    public void PlayGame()
    {
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));


    }


    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    IEnumerator LoadLevel (int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionsTime);

        SceneManager.LoadScene(levelIndex);
    }



}
