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
    public GameObject choiceManager;


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
        if(choiceManager.GetComponent<ChoiceManager>().thresholds.Count>=3 && directive == "Left")
        {
            choiceManager.GetComponent<ChoiceManager>().choice1 = false;
            choiceManager.GetComponent<ChoiceManager>().SuccessCalculator(choiceManager.GetComponent<ChoiceManager>().choiceS[0]);
            choiceManager.GetComponent<ChoiceManager>().ChoiceModifier();
            otherChoice.GetComponent<Choice>().sendBack();
            return;
        }
        if (choiceManager.GetComponent<ChoiceManager>().thresholds.Count <= 2 && directive == "Left")
        {
            choiceManager.GetComponent<ChoiceManager>().choice2 = false;
            choiceManager.GetComponent<ChoiceManager>().SuccessCalculator(choiceManager.GetComponent<ChoiceManager>().choiceS[1]);
            choiceManager.GetComponent<ChoiceManager>().ChoiceModifier();
            otherChoice.GetComponent<Choice>().sendBack();
            return;
        }
        if (choiceManager.GetComponent<ChoiceManager>().thresholds.Count <= 1 && directive == "Left")
        {
            choiceManager.GetComponent<ChoiceManager>().choice3 = false;
            choiceManager.GetComponent<ChoiceManager>().SuccessCalculator(choiceManager.GetComponent<ChoiceManager>().choiceS[2]);
            choiceManager.GetComponent<ChoiceManager>().ChoiceModifier();
            otherChoice.GetComponent<Choice>().sendBack();
            return;
        }

        if (choiceManager.GetComponent<ChoiceManager>().thresholds.Count >= 3 && directive == "Right")
        {
            choiceManager.GetComponent<ChoiceManager>().choice1 = true;
            choiceManager.GetComponent<ChoiceManager>().SuccessCalculator(choiceManager.GetComponent<ChoiceManager>().choiceS[0]);
            choiceManager.GetComponent<ChoiceManager>().ChoiceModifier();
            otherChoice.GetComponent<Choice>().sendBack();
            return;
        }
        if (choiceManager.GetComponent<ChoiceManager>().thresholds.Count <= 2 && directive == "Right")
        {
            choiceManager.GetComponent<ChoiceManager>().choice2 = true;
            choiceManager.GetComponent<ChoiceManager>().SuccessCalculator(choiceManager.GetComponent<ChoiceManager>().choiceS[1]);
            choiceManager.GetComponent<ChoiceManager>().ChoiceModifier();
            otherChoice.GetComponent<Choice>().sendBack();
            return;
        }
        if (choiceManager.GetComponent<ChoiceManager>().thresholds.Count <= 1 && directive == "Right")
        {
            choiceManager.GetComponent<ChoiceManager>().choice3 = true;
            choiceManager.GetComponent<ChoiceManager>().SuccessCalculator(choiceManager.GetComponent<ChoiceManager>().choiceS[2]);
            choiceManager.GetComponent<ChoiceManager>().ChoiceModifier();
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