using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public Web web;
    public static Main Instance;
    public UserInfo newUser;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        web = GetComponent<Web>();
        newUser = GetComponent<UserInfo>();
    }
}
