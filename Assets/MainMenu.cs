﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
        Debug.Log(SceneManager.sceneCount);
    }

    public void QuitApplication()
    {
        Application.Quit();
    }

}
