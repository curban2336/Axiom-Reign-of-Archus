using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Choice : MonoBehaviour
{
    public static Choice S;

    public GameObject button;
    public GameObject otherChoice;
    public TMP_Text Decision;
    public float posX;
    private float tempPos;
    public Vector3 offScreen;
    public Vector3 updatePos;
    private float posMax;
    private float posMin;
    public string directive;


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
        tempPos = 0.4f;
        button.transform.position = updatePos;
        offScreen = button.transform.position;
    }

    public void Press()
    {
        if(ChoiceManager.S.thresholds.Count>=3 && directive == "Left")
        {
            ChoiceManager.S.choice1 = false;
            ChoiceManager.S.choice1S = ChoiceManager.S.SuccessCalculator();
            ChoiceManager.S.ChoiceModifier();
            otherChoice.GetComponent<Choice>().sendBack();
            return;
        }
        if (ChoiceManager.S.thresholds.Count <= 2 && directive == "Left")
        {
            ChoiceManager.S.choice2 = false;
            ChoiceManager.S.choice2S = ChoiceManager.S.SuccessCalculator();
            ChoiceManager.S.ChoiceModifier();
            otherChoice.GetComponent<Choice>().sendBack();
            return;
        }
        if (ChoiceManager.S.thresholds.Count <= 1 && directive == "Left")
        {
            ChoiceManager.S.choice3 = false;
            ChoiceManager.S.choice3S = ChoiceManager.S.SuccessCalculator();
            ChoiceManager.S.ChoiceModifier();
            otherChoice.GetComponent<Choice>().sendBack();
            return;
        }

        if (ChoiceManager.S.thresholds.Count >= 3 && directive == "Right")
        {
            ChoiceManager.S.choice1 = true;
            ChoiceManager.S.choice1S = ChoiceManager.S.SuccessCalculator();
            ChoiceManager.S.ChoiceModifier();
            otherChoice.GetComponent<Choice>().sendBack();
            return;
        }
        if (ChoiceManager.S.thresholds.Count <= 2 && directive == "Right")
        {
            ChoiceManager.S.choice2 = true;
            ChoiceManager.S.choice2S = ChoiceManager.S.SuccessCalculator();
            ChoiceManager.S.ChoiceModifier();
            otherChoice.GetComponent<Choice>().sendBack();
            return;
        }
        if (ChoiceManager.S.thresholds.Count <= 1 && directive == "Right")
        {
            ChoiceManager.S.choice3 = true;
            ChoiceManager.S.choice3S = ChoiceManager.S.SuccessCalculator();
            ChoiceManager.S.ChoiceModifier();
            otherChoice.GetComponent<Choice>().sendBack();
            return;
        }
    }

    public void callChoice()
    {
        if (updatePos.x >= posMax)
        {
            updatePos.x -= tempPos;
            button.transform.position = updatePos;
            Invoke("callChoice", 0.01f);
        }
        else if (updatePos.x <= posMin)
        {
            updatePos.x += tempPos;
            button.transform.position = updatePos;
            Invoke("callChoice", 0.01f);
        }
    }

    public void sendBack()
    {

        if (button.transform.position.x > offScreen.x)
        {
            updatePos.x -= tempPos;
            button.transform.position = updatePos;
            Decision.text = "";
            Invoke("sendBack", 0.01f);
        }
        else if (button.transform.position.x < offScreen.x)
        {
            updatePos.x += tempPos;
            button.transform.position = updatePos;
            Decision.text = "";
            Invoke("sendBack", 0.01f);
        }

    }
}