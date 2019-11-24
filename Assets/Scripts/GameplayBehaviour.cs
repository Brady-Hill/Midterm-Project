using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayBehaviour : MonoBehaviour
{
    public GameObject gameOverScreen, nextRoundScreen, gameplayCanvas;

    //Weapon Choices like Paper Rock and Scissors
    public enum Weapons
    {
        PAPER,
        ROCK,
        SCISSORS
    }

    //Variables to store the Player and AI Choice
    private List<Weapons> picks;
    Weapons userWeapon, compWeapon;

    //Strings for conditions, choices and for the UI to display
    private string playerPick, compPick, condition;
    private int playerWon = 0, compWon = 0;

    private string user = Main.Instance.newUser.GetName();
    private string pass = Main.Instance.newUser.GetPass();
    private int userWins = 0;
    private int userLosses = 0;

    private void Awake()
    {
        picks = new List<Weapons>();
        AudioManager.instance.Stop("Theme");
        AudioManager.instance.Play("Gameplay");
    }
    //Methods for each weapon choice
    public void paper() { picks.Add(Weapons.PAPER); playerPick = "Paper"; }
    public void rock() { picks.Add(Weapons.ROCK); playerPick = "Rock"; }
    public void scissors() { picks.Add(Weapons.SCISSORS); playerPick = "Scissors"; }

    private void Update()
    {
        if (picks.Count == 1)
        {
            gameplay();
        }
    }
    //Method for Computer Weapon Selection
    IEnumerator computerWeapon()
    {
        int temp = Random.Range(0, 3);
        switch (temp)
        {
            case 0:
                picks.Add(Weapons.PAPER); compPick = "Paper";
                break;
            case 1:
                picks.Add(Weapons.ROCK); compPick = "Rock";
                break;
            case 2:
                picks.Add(Weapons.SCISSORS); compPick = "Scissors";
                break;
        }
        yield return new WaitForSeconds(1.5f);
    }

    //Method to compare the User selection with the Computer selection and determine the game outcome
    private void compareWeapons()
    {
        userWeapon = picks[0]; compWeapon = picks[1];
        if (userWeapon == compWeapon)
        {
            condition = "Tie";
        }
        else if (userWeapon == Weapons.PAPER)
        {
            if (compWeapon == Weapons.SCISSORS)
            {
                condition = "Lose";
                compWon++;
            }
            else
            {
                condition = "Win";
                playerWon++;
            }
        }
        else if (userWeapon == Weapons.ROCK)
        {
            if (compWeapon == Weapons.PAPER)
            {
                condition = "Lose";
                compWon++;
            }
            else
            {
                condition = "Win";
                playerWon++;
            }
        }
        else if (userWeapon == Weapons.SCISSORS)
        {
            if (compWeapon == Weapons.ROCK)
            {
                condition = "Lose";
                compWon++;
            }
            else
            {
                condition = "Win";
                playerWon++;
            }
        }
    }

    //Update and Render Game Over UI Method
    private void updateCanvas()
    {
        AudioManager.instance.Play("Death");
        gameplayCanvas.SetActive(false);
        if (playerWon >= 2 || compWon >= 2)
        {
            Text newText = gameOverScreen.GetComponentInChildren<Text>();
            newText.text = "You Chose " + playerPick + ',' + '\n' + "Evil Chose " + compPick + ',' + '\n' + "You " + condition + " " + playerWon + " to " + compWon;
            gameOverScreen.SetActive(true);
            picks.Clear();
            if (playerWon >= 2)
            {
                userWins++;
            }
            else
            {
                userLosses++;
            }
            StartCoroutine(Main.Instance.web.updateRecord(user, pass, userWins, userLosses));
        }
        else
        {
            AudioManager.instance.Play("Death");
            Text newText = nextRoundScreen.GetComponentInChildren<Text>();
            newText.text = "You Chose " + playerPick + ',' + '\n' + "Evil Chose " + compPick + ',' + '\n' + "You " + condition;
            nextRoundScreen.SetActive(true);
            picks.Clear();
        }
    }
    public void nextRound()
    {
        AudioManager.instance.Play("Button");
        nextRoundScreen.SetActive(false);
        gameplayCanvas.SetActive(true);
    }
    //Gameplay Loop Method
    public void gameplay()
    {
        StartCoroutine(computerWeapon());
        compareWeapons();
        updateCanvas();
    }
}
