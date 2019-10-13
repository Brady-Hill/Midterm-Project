using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponChoiceButtonBehaviour : MonoBehaviour
{
    public Button[] buttons;
    public void paperChoice()
    {
        FindObjectOfType<GameplayBehaviour>().paper();
        FindObjectOfType<GameplayBehaviour>().gameplay();
        clearScreen();
    }
    public void rockChoice()
    {
        FindObjectOfType<GameplayBehaviour>().rock();
        FindObjectOfType<GameplayBehaviour>().gameplay();
        clearScreen();
    }
    public void scissorChoice()
    {
        FindObjectOfType<GameplayBehaviour>().scissors();
        FindObjectOfType<GameplayBehaviour>().gameplay();
        clearScreen();
    }
    private void clearScreen()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Image>().color = new Color(0,0,0,0);
        }
    }
}
