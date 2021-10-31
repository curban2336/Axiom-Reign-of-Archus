using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextButton : MonoBehaviour
{
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        button.SetActive(false);
    }

    public void Activate()
    {
        button.SetActive(true);
    }
}
