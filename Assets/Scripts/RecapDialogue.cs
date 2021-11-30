using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecapDialogue : MonoBehaviour
{
    public List<Script> dialogue;
    public Script speak;
    public int speakLength;
    public int start1;
    public int start2;
    public int start3;
    public GameObject startWeek;
    public int i = 0;

    void Start()
    {
        startWeek.SetActive(false);
        speak.sentences = new string[speakLength];
        speak.names = new string[speakLength];
        Debug.Log(speak.names.Length);
        Debug.Log(speak.sentences.Length);
    }
    
    public void TriggerDialogue1()
    {
        if (PlayerPrefs.GetInt("Choice1") == 0) {
            speak.Add(dialogue[0].sentences, dialogue[0].names, (start2), start1);
            TriggerDialogue2();
        }
        else if (PlayerPrefs.GetInt("Choice1") == 1)
        {
            speak.Add(dialogue[1].sentences, dialogue[1].names, (start2), start1);
            TriggerDialogue2();
        }
        else if (PlayerPrefs.GetInt("Choice1") == 3)
        {
            speak.Add(dialogue[2].sentences, dialogue[2].names, (start2), start1);
            TriggerDialogue2();
        }
        else if (PlayerPrefs.GetInt("Choice1") == 4)
        {
            speak.Add(dialogue[3].sentences, dialogue[3].names, (start2), start1);
            TriggerDialogue2();
        }
        i++;
    }

    public void TriggerDialogue2()
    {
        if (PlayerPrefs.GetInt("Choice2") == 0)
        {
            speak.Add(dialogue[4].sentences, dialogue[4].names, (start3), start2);
            TriggerDialogue3();
        }
        else if (PlayerPrefs.GetInt("Choice2") == 1)
        {
            speak.Add(dialogue[5].sentences, dialogue[5].names, (start3), start2);
            TriggerDialogue3();
        }
        else if (PlayerPrefs.GetInt("Choice2") == 3)
        {
            speak.Add(dialogue[6].sentences, dialogue[6].names, (start3), start2);
            TriggerDialogue3();
        }
        else if (PlayerPrefs.GetInt("Choice2") == 4)
        {
            speak.Add(dialogue[7].sentences, dialogue[7].names, (start3), start2);
            TriggerDialogue3();
        }
    }

    public void TriggerDialogue3()
    {
        if (PlayerPrefs.GetInt("Choice3") == 0)
        {
            speak.Add(dialogue[8].sentences, dialogue[8].names, speakLength, start3);
            FindObjectOfType<Dialogue>().StartDialogue(speak);
        }
        else if (PlayerPrefs.GetInt("Choice3") == 1)
        {
            speak.Add(dialogue[9].sentences, dialogue[9].names, speakLength, start3);
            FindObjectOfType<Dialogue>().StartDialogue(speak);
        }
        else if (PlayerPrefs.GetInt("Choice3") == 3)
        {
            speak.Add(dialogue[10].sentences, dialogue[10].names, speakLength, start3);
            FindObjectOfType<Dialogue>().StartDialogue(speak);
        }
        else if (PlayerPrefs.GetInt("Choice3") == 4)
        {
            speak.Add(dialogue[11].sentences, dialogue[11].names, speakLength, start3);
            FindObjectOfType<Dialogue>().StartDialogue(speak);
        }
    }

    public void StartD()
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
                Invoke("StartD", 2f);
            }
        }
    }
}
