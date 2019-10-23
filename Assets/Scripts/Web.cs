using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Web : MonoBehaviour
{
    public GameObject errorText;
    string LoginURL = "http://poxdb.000webhostapp.com/Login.php";
    string RegisterURL = "http://poxdb.000webhostapp.com/Register.php";


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
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("Password") || www.downloadHandler.text.Contains("Username"))
                {
                    StartCoroutine(LoginError());
                }
                else
                {
                    Main.Instance.newUser.setUser(username, password);
                    Main.Instance.newUser.setRecord(www.downloadHandler.text);
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
                Debug.Log(www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("Username"))
                {
                    StartCoroutine(LoginError());
                }
                else
                {
                    Main.Instance.newUser.setNewUser(username, password);
                    goToMenu();
                }
            }
        }
    }
    public IEnumerator LoginError()
    {
        errorText.active = true;
        yield return new WaitForSeconds(2.0f);
        errorText.active = false;
    }
    public void goToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
