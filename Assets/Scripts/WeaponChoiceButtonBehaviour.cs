using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WeaponChoiceButtonBehaviour : MonoBehaviour
{
    public GameObject gameCanvas, nextRoundCanvas;
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
        gameCanvas.SetActive(false);
    }
    public void resetScreen()
    {
        nextRoundCanvas.SetActive(false);
        gameCanvas.SetActive(true);
    }
}
