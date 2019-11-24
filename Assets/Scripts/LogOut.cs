using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogOut : MonoBehaviour
{
    public GameObject canvas;
    public void ClickLogOut()
    {
        AudioManager.instance.Play("Button");
        canvas.SetActive(true);
    }
}
