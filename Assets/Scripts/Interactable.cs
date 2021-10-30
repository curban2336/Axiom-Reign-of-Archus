using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Script dialogue;

    public void TriggerDialouge()
    {
        FindObjectOfType<Dialogue>().StartDialogue(dialogue);
    }
}
