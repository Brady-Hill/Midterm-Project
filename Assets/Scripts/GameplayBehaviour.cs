using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverScreen;

    //Weapon Choices like Paper Rock and Scissors
    private enum Weapons
    {
        PAPER,
        ROCK,
        SCISSORS
    }

    //Win Conditions such as Win Lose or in the event that the player and the computer pick the same choice... Draw
    private enum Conditions
    {
        WIN,
        LOSE,
        DRAW
    }

    //Variables to store the Player and AI Choice
    private Weapons userWeapon, compWeapon;

    //Variable to Store the Game Outcome
    private Conditions gameConditions;

    //Strings for the UI to display after each game
    private string playerPick, compPick, condition;

    //Methods for each weapon choice
    public void paper() { userWeapon = Weapons.PAPER; playerPick = "Paper"; }
    public void rock() { userWeapon = Weapons.ROCK; playerPick = "Rock"; }
    public void scissors() { userWeapon = Weapons.SCISSORS; playerPick = "Scissors"; }

    //Method for Computer Weapon Selection
    private void computerWeapon()
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
    }

    //Method to compare the User selection with the Computer selection and determine the game outcome
    private void compareWeapons()
    {
        if (userWeapon == compWeapon)
        {
            gameConditions = Conditions.DRAW;
            condition = "Tie";
        }
        else if (userWeapon == Weapons.PAPER)
        {
            if (compWeapon == Weapons.SCISSORS)
            {
                gameConditions = Conditions.LOSE;
                condition = "Lose";
            }
            else
            {
                gameConditions = Conditions.WIN;
                condition = "Win";
            }
        }
        else if (userWeapon == Weapons.ROCK)
        {
            if (compWeapon == Weapons.PAPER)
            {
                gameConditions = Conditions.LOSE;
                condition = "Lose";
            }
            else
            {
                gameConditions = Conditions.WIN;
                condition = "Win";
            }
        }
        else
        {
            if (compWeapon == Weapons.ROCK)
            {
                gameConditions = Conditions.LOSE;
                condition = "Lose";
            }
            else
            {
                gameConditions = Conditions.WIN;
                condition = "Win";
            }
        }
    }

    //Update and Render Game Over UI Method
    private void updateCanvas()
    {
        Text newText = gameOverScreen.GetComponentInChildren<Text>();
        newText.text = "You Chose " + playerPick + ',' + '\n' + "Evil Chose " + compPick + ',' + '\n' + "You " + condition;
        gameOverScreen.SetActive(true);
    }

    //Gameplay Loop Method
    public void gameplay()
    {
        computerWeapon();
        compareWeapons();
        updateCanvas();
    }
}
