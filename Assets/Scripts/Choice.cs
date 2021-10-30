using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : MonoBehaviour
{
    public static Choice S;

    public GameObject button;
    public GameObject otherChoice;
    public float posX;
    private float tempPos;
    public Vector3 offScreen;
    public Vector3 updatePos;
    private float posMax;
    private float posMin;
    public bool posConfirm = false;

    void Awake()
    {
        posMax = button.transform.position.x;
        posMin = button.transform.position.x - 0.5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        updatePos = button.transform.position;
        updatePos.x = posX;
        tempPos = 0.2f;
        button.transform.position = updatePos;
        offScreen = button.transform.position;
    }

    public void Press()
    {
        posConfirm = true;
        otherChoice.GetComponent<Choice>().posConfirm = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (posConfirm == false && updatePos.x >= posMax)
        {
            updatePos.x -= tempPos;
            button.transform.position = updatePos;
        }
        else if (posConfirm == false && updatePos.x <= posMin)
        {
            updatePos.x += tempPos;
            button.transform.position = updatePos;
        }
        else if (posConfirm == true && button.transform.position.x > offScreen.x)
        {
            updatePos.x -= tempPos;
            button.transform.position = updatePos;
        }
        else if (posConfirm == true && button.transform.position.x < offScreen.x)
        {
            updatePos.x += tempPos;
            button.transform.position = updatePos;
        }
    }
}