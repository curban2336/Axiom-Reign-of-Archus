using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecapDialogue : MonoBehaviour
{
    public List<Script> dialogue;
    public List<Script> speak;
    public GameObject startWeek;
    public int i = 0;

    void Start()
    {
        startWeek.SetActive(false);
    }
    
    public void TriggerDialogue1()
    {
        if (PlayerPrefs.GetInt("Choice1") == 0) {
            speak.Add(dialogue[0]);
            TriggerDialogue2();
        }
        else if (PlayerPrefs.GetInt("Choice1") == 1)
        {
            speak.Add(dialogue[1]);
            TriggerDialogue2();
        }
        else if (PlayerPrefs.GetInt("Choice1") == 3)
        {
            speak.Add(dialogue[2]);
            TriggerDialogue2();
        }
        else if (PlayerPrefs.GetInt("Choice1") == 4)
        {
            speak.Add(dialogue[3]);
            TriggerDialogue2();
        }
        i++;
    }

    public void TriggerDialogue2()
    {
        if (PlayerPrefs.GetInt("Choice2") == 0)
        {
            speak.Add(dialogue[4]);
            TriggerDialogue3();
        }
        else if (PlayerPrefs.GetInt("Choice2") == 1)
        {
            speak.Add(dialogue[5]);
            TriggerDialogue3();
        }
        else if (PlayerPrefs.GetInt("Choice2") == 3)
        {
            speak.Add(dialogue[6]);
            TriggerDialogue3();
        }
        else if (PlayerPrefs.GetInt("Choice2") == 4)
        {
            speak.Add(dialogue[7]);
            TriggerDialogue3();
        }
    }

    public void TriggerDialogue3()
    {
        if (PlayerPrefs.GetInt("Choice3") == 0)
        {
            speak.Add(dialogue[8]);
            //FindObjectOfType<Dialogue>().StartDialogue(speak);
        }
        else if (PlayerPrefs.GetInt("Choice3") == 1)
        {
            speak.Add(dialogue[9]);
            //FindObjectOfType<Dialogue>().StartDialogue(speak);
        }
        else if (PlayerPrefs.GetInt("Choice3") == 3)
        {
            speak.Add(dialogue[10]);
            //FindObjectOfType<Dialogue>().StartDialogue(speak);
        }
        else if (PlayerPrefs.GetInt("Choice3") == 4)
        {
            speak.Add(dialogue[11]);
            //FindObjectOfType<Dialogue>().StartDialogue(speak);
        }
    }

    public void StartDialogue()
    {
        startWeek.SetActive(true);
    }

    public void TriggerCheck()
    {
        if (FindObjectOfType<Dialogue>().sentences.Count == 0)
        {
            if (i == 1)
            {
                i++;
            }
            if (i == 2)
            {
                i++;
            }
            if (i == 3)
            {
                i++;
                Invoke("StartDialogue", 2f);
            }
        }
    }
}
