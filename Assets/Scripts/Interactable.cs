using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public List<Script> dialogue;
    public int i = 0;



    public void TriggerDialogue()
    {
        FindObjectOfType<Dialogue>().StartDialogue(dialogue[i]);
        if (dialogue.Count > 1)
        {
            foreach (GameObject choice in GameObject.FindGameObjectsWithTag("Choice"))
            {
                choice.GetComponent<Interactable>().i++;
            }
        }
    }
}
