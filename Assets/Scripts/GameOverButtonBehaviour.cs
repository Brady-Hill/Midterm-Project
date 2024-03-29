﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverButtonBehaviour : MonoBehaviour
{
    public void goToTitle()
    {
        AudioManager.instance.Stop("Gameplay");
        AudioManager.instance.Play("Theme");
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScreen");
    }
    public void goToGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("AIGameScene");
    }
    public void goToLocalGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LocalGameScene");
    }
}
