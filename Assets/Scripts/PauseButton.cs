using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public string designator;
    public GameObject pause;
    public GameObject next;

    public void Click()
    {
        if(designator == "Return")
        {
            pause.SetActive(false);
            next.SetActive(true);
        }
        else if(designator == "Menu")
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
