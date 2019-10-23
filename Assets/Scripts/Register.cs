using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public InputField RegUser;
    public InputField RegPass;
    public Button RegButton;

    // Start is called before the first frame update
    void Start()
    {
        RegButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.web.Register(RegUser.text, RegPass.text));
        });
    }
}
