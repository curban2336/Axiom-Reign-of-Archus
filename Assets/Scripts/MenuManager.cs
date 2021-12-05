using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        if (sceneName == "Begin")
        {
            PlayerPrefs.DeleteKey("Week");
            PlayerPrefs.DeleteKey("Choice1N");
            PlayerPrefs.DeleteKey("Choice2N");
            PlayerPrefs.DeleteKey("Choice3N");
            PlayerPrefs.DeleteKey("Reserve");
            PlayerPrefs.DeleteKey("Opinion");

            SceneManager.LoadScene(sceneName);
        }
        if (sceneName == "Continue")
        {
            if(PlayerPrefs.GetInt("Week") == 1)
            {
                SceneManager.LoadScene("Begin");
            }
            SceneManager.LoadScene("Week" + PlayerPrefs.GetInt("Week"));
        }
    }
}
