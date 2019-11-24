using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LocalGameplayBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject gameplayCanvas, gameOverScreen, nextRoundScreen;

    private List<GameplayBehaviour.Weapons> picks;
    GameplayBehaviour.Weapons pick1, pick2;
    string condition, user1pick, user2pick;
    int user1wins = 0, user2wins = 0;
    private void Awake()
    {
        picks = new List<GameplayBehaviour.Weapons>();
        AudioManager.instance.Stop("Theme");
        AudioManager.instance.Play("Gameplay");
    }
    public void Update()
    {
        if (picks.Count == 2)
        {
            gameplay();
        }
    }
    public void paperChoice()
    {
        picks.Add(GameplayBehaviour.Weapons.PAPER);
    }
    public void rockChoice()
    {
        picks.Add(GameplayBehaviour.Weapons.ROCK);
    }
    public void scissorsChoice()
    {
        picks.Add(GameplayBehaviour.Weapons.SCISSORS);
    }
    private void comparePicks()
    {
        pick1 = picks[0];pick2 = picks[1];
        if(pick1 == pick2)
        {
            condition = "Tie";
        }
        else if(pick1 == GameplayBehaviour.Weapons.PAPER)
        {
            if (pick2 == GameplayBehaviour.Weapons.SCISSORS)
            { condition = "Lose"; user2wins++; }
            else
            { condition = "Win"; user1wins++; }
        }
        else if(pick1 == GameplayBehaviour.Weapons.ROCK)
        {
            if (pick2 == GameplayBehaviour.Weapons.PAPER)
            { condition = "Lose"; user2wins++; }
            else
            { condition = "Win"; user1wins++; }
        }
        else
        {
            if (pick2 == GameplayBehaviour.Weapons.ROCK)
            { condition = "Lose"; user2wins++; }
            else
            { condition = "Win"; user1wins++; }
        }
    }
    private string user1Choice()
    {
        switch(pick1)
        {
            case GameplayBehaviour.Weapons.PAPER:
                {
                    user1pick = "Paper";
                    break;
                }
            case GameplayBehaviour.Weapons.ROCK:
                {
                    user1pick = "Rock";
                    break;
                }
            case GameplayBehaviour.Weapons.SCISSORS:
                {
                    user1pick = "Scissors";
                    break;
                }
        }
        return user1pick;
    }
    private string user2Choice()
    {
        switch (pick2)
        {
            case GameplayBehaviour.Weapons.PAPER:
                {
                    user2pick = "Paper";
                    break;
                }
            case GameplayBehaviour.Weapons.ROCK:
                {
                    user2pick = "Rock";
                    break;
                }
            case GameplayBehaviour.Weapons.SCISSORS:
                {
                    user2pick = "Scissors";
                    break;
                }
        }
        return user2pick;
    }
    private string winner()
    {
        switch (condition)
        {
            case "Win":
                {
                    condition = "Player 1 Wins";
                    break;
                }
            case "Lose":
                {
                    condition = "Player 2 Wins";
                    break;
                }
            case "Tie":
                {
                    condition = "It's a Tie";
                    break;
                }
        }
        return condition;
    }
    private void updateCanvas()
    {
        AudioManager.instance.Play("Death");
        gameplayCanvas.SetActive(false);
        if (user1wins >= 2 || user2wins >= 2)
        {
            Text newText = gameOverScreen.GetComponentInChildren<Text>();
            if (user1wins >= 2)
            { newText.text = "Player 1 Chose " + user1Choice() + ',' + '\n' + "Player 2 Chose " + user2Choice() + ',' + '\n' + "Player 1 wins " + user1wins + " to " + user2wins; }
            else
            { newText.text = "Player 1 Chose " + user1Choice() + ',' + '\n' + "Player 2 Chose " + user2Choice() + ',' + '\n' + "Player 2 wins " + user2wins + " to " + user1wins; }
            gameOverScreen.SetActive(true);
            picks.Clear();
        }
        else
        {
            AudioManager.instance.Play("Death");
            Text newText = nextRoundScreen.GetComponentInChildren<Text>();
            newText.text = "Player 1 Chose " + user1Choice() + ',' + '\n' + "Player 2 Chose " + user2Choice() + ',' + '\n' + winner();
            nextRoundScreen.SetActive(true);
            picks.Clear();
        }
    }
    public void gameplay()
    {
        comparePicks();
        updateCanvas();
    }
    public void nextRound()
    {
        AudioManager.instance.Play("Button");
        nextRoundScreen.SetActive(false);
        gameplayCanvas.SetActive(true);
    }
}
