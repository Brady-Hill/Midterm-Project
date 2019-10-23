using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public InputField LoginUser;
    public InputField LoginPass;
    public Button LoginButton;

    // Start is called before the first frame update
    void Start()
    {
        LoginButton.onClick.AddListener(() =>
        {
           StartCoroutine(Main.Instance.web.Login(LoginUser.text, LoginPass.text));

        });
    }
}
