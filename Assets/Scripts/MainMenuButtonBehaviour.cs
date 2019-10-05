using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonBehaviour : MonoBehaviour
{
    public void goToGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("AIGameScene");
    }
}
