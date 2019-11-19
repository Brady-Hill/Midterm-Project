using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleButtonBehaviour : MonoBehaviour
{
    public GameObject canvas;
    public void ClickPlay()
    {
        string file = "lgncred.txt";
        if (File.Exists(file))
        {
            List<string> login = new List<string>();
            string line;
            using (StreamReader stream = new StreamReader(file))
            {
                while ((line = stream.ReadLine()) != null)
                {
                    login.Add(line);
                }
            }
            Main.Instance.newUser.setUser(login[0], login[1]);
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            canvas.SetActive(true);
        }
    }
   
}
