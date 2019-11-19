using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Web : MonoBehaviour
{
    public GameObject errorText;
    string LoginURL = "http://poxdb.000webhostapp.com/Login.php";
    string RegisterURL = "http://poxdb.000webhostapp.com/Register.php";
    string UpdateURL = "http://poxdb.000webhostapp.com/UpdateRecord.php";

    public IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);

        using (UnityWebRequest www = UnityWebRequest.Post(LoginURL, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.downloadHandler.text.Contains("Password") || www.downloadHandler.text.Contains("Username"))
                {
                    StartCoroutine(LoginError());
                }
                else
                {
                    Main.Instance.newUser.setUser(username, password);
                    Main.Instance.newUser.setRecord(www.downloadHandler.text);
                    using (StreamWriter login = new StreamWriter("lgncred.txt"))
                    {
                        login.WriteLine(username);
                        login.WriteLine(password);
                    }
                        goToMenu();
                }
            }
        }
    }

    public IEnumerator Register(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);

        using (UnityWebRequest www = UnityWebRequest.Post(RegisterURL, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.downloadHandler.text.Contains("Username"))
                {
                    StartCoroutine(LoginError());
                }
                else
                {
                    Main.Instance.newUser.setNewUser(username, password);
                    using (StreamWriter login = new StreamWriter("lgncred.txt"))
                    {
                        login.WriteLine(username);
                        login.WriteLine(password);
                    }
                    goToMenu();
                }
            }
        }
    }
    public IEnumerator LoginError()
    {
        errorText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        errorText.SetActive(false);
    }
    public IEnumerator updateRecord(string username, string password, int wins, int losses)
    {
        WWWForm form = new WWWForm();
        form.AddField("usernamePost", username);
        form.AddField("passwordPost", password);
        form.AddField("userWins", wins);
        form.AddField("userLosses", losses);

        using (UnityWebRequest www = UnityWebRequest.Post(UpdateURL, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.downloadHandler.text.Contains("Error") || www.downloadHandler.text.Contains("Update"))
                {
                    Debug.Log(www.downloadHandler.text);
                    StartCoroutine(LoginError());
                }
            }
        }
    }
    public void goToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
