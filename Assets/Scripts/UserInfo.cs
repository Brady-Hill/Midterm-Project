using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    string userName, userPass, wins, losses;
    public void setUser(string name, string password)
    {
        userName = name;
        userPass = password;
    }
    public void setNewUser(string name, string password, int _wins = 0, int _losses = 0)
    {
        userName = name;
        userPass = password;
        wins = _wins.ToString();
        losses = _losses.ToString();
    }
    public void setRecord(string record)
    {
        string[] tmp = record.Split('|');
        wins = tmp[0]; losses = tmp[1];
    }
}
