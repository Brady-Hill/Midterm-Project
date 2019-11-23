using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverScreen, nextRoundScreen;

    //Weapon Choices like Paper Rock and Scissors
    public enum Weapons
    {
        PAPER,
        ROCK,
        SCISSORS,
        EMPTY
    }

    //Variables to store the Player and AI Choice
    private Weapons userWeapon, compWeapon;

    //Strings for conditions, choices and for the UI to display
    private string playerPick, compPick, condition;
    private int playerWon = 0, compWon = 0;

    private string user = Main.Instance.newUser.GetName();
    private string pass = Main.Instance.newUser.GetPass();
    private int userWins = 0;
    private int userLosses = 0;


    //Methods for each weapon choice
    public void paper() { userWeapon = Weapons.PAPER; playerPick = "Paper"; }
    public void rock() { userWeapon = Weapons.ROCK; playerPick = "Rock"; }
    public void scissors() { userWeapon = Weapons.SCISSORS; playerPick = "Scissors"; }

    //Method for Computer Weapon Selection
    IEnumerator computerWeapon()
    {
        int temp = Random.Range(0, 3);
        switch (temp)
        {
            case 0:
                compWeapon = Weapons.PAPER; compPick = "Paper";
                break;
            case 1:
                compWeapon = Weapons.ROCK; compPick = "Rock";
                break;
            case 2:
                compWeapon = Weapons.SCISSORS; compPick = "Scissors";
                break;
        }
        yield return new WaitForSeconds(1.5f);
    }

    //Method to compare the User selection with the Computer selection and determine the game outcome
    private void compareWeapons()
    {
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
        else
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
        if (playerWon >= 2 || compWon >= 2)
        {
            Text newText = gameOverScreen.GetComponentInChildren<Text>();
            newText.text = "You Chose " + playerPick + ',' + '\n' + "Evil Chose " + compPick + ',' + '\n' + "You " + condition + " " + playerWon + " to " + compWon;
            gameOverScreen.SetActive(true);
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
            Text newText = nextRoundScreen.GetComponentInChildren<Text>();
            newText.text = "You Chose " + playerPick + ',' + '\n' + "Evil Chose " + compPick + ',' + '\n' + "You " + condition;
            nextRoundScreen.SetActive(true);
            userWeapon = compWeapon = Weapons.EMPTY;
        }
    }
    //Gameplay Loop Method
    public void gameplay()
    {
        StartCoroutine(computerWeapon());
        compareWeapons();
        updateCanvas();
    }
}
