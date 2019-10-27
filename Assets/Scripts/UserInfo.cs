using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UserInfo : MonoBehaviour
{
    string userName, userPass;
    int wins, losses;

    public string GetName()
    { return userName; }
    public string GetPass()
    { return userPass; }
    public int GetWins()
    { return wins; }
    public int GetLosses()
    { return losses; }

    public void setUser(string name, string password)
    {
        userName = name;
        userPass = password;
    }
    public void setNewUser(string name, string password, int _wins = 0, int _losses = 0)
    {
        userName = name;
        userPass = password;
        wins = _wins;
        losses = _losses;
    }
    public void setRecord(string record)
    {
        string[] tmp = record.Split('|');
        wins = Int32.Parse(tmp[0]);
        losses = Int32.Parse(tmp[1]);

    }
}
