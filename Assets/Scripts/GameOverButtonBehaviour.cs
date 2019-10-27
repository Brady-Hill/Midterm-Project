using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverButtonBehaviour : MonoBehaviour
{
    public void goToTitle()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("TitleScreen");
    }
    public void goToGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("AIGameScene");

    }
}
