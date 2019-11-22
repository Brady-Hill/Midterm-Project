using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginUIInfo : MonoBehaviour
{
    public Text loginUI;
    // Start is called before the first frame update
    void Start()
    {
        loginUI.text = "Logged in as " + Main.Instance.newUser.GetName();
    }
}
