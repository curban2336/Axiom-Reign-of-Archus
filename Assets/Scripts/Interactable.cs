using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Script dialogue;



    public void TriggerDialogue()
    {
        FindObjectOfType<Dialogue>().StartDialogue(dialogue);
    }
}
