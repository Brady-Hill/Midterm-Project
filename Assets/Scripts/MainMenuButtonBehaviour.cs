using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonBehaviour : MonoBehaviour
{
    public void goToGame()
    {
        AudioManager.instance.Play("Button");
        UnityEngine.SceneManagement.SceneManager.LoadScene("AIGameScene");
    }
    public void goToLocalGame()
    {
        AudioManager.instance.Play("Button");
        UnityEngine.SceneManagement.SceneManager.LoadScene("LocalGameScene");
    }
}
