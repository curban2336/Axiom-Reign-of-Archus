using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Choice : MonoBehaviour
{
    public static Choice S;

    public GameObject button;
    public GameObject otherChoice;
    public GameObject dialogue;
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
        tempPos = 250f;
        button.transform.position = updatePos;
        offScreen = button.transform.position;
    }

    public void Press()
    {
        if (ChoiceManager.S.canClick == true)
        {
            button.GetComponent<Interactable>().TriggerDialogue();
            dialogue.GetComponent<Dialogue>().Increment();
            Debug.Log("triggered dialogue");
            if (ChoiceManager.S.thresholds.Count == 3 && directive == "Left")
            {
                ChoiceManager.S.choice1 = false;
                ChoiceManager.S.choice1S = ChoiceManager.S.SuccessCalculator();
                if (ChoiceManager.S.choice1S == true)
                {
                    ChoiceManager.S.successModifier += 1.3f;
                }
                else if (ChoiceManager.S.choice1S == false)
                {
                    ChoiceManager.S.successModifier -= 1.3f;
                }
                ChoiceManager.S.ChoiceModifier1();
                return;
            }
            if (ChoiceManager.S.thresholds.Count == 2 && directive == "Left")
            {
                ChoiceManager.S.choice2 = false;
                ChoiceManager.S.choice2S = ChoiceManager.S.SuccessCalculator();
                if (ChoiceManager.S.choice2S == true)
                {
                    ChoiceManager.S.successModifier += 0.5f;
                }
                else if (ChoiceManager.S.choice2S == false)
                {
                    ChoiceManager.S.successModifier -= 0.5f;
                }
                ChoiceManager.S.ChoiceModifier2();
                return;
            }
            if (ChoiceManager.S.thresholds.Count == 1 && directive == "Left")
            {
                ChoiceManager.S.choice3 = false;
                ChoiceManager.S.choice3S = ChoiceManager.S.SuccessCalculator();
                if (ChoiceManager.S.choice3S == true)
                {
                    ChoiceManager.S.successModifier += 0.6f;
                }
                else if (ChoiceManager.S.choice3S == false)
                {
                    ChoiceManager.S.successModifier -= 0.6f;
                }
                ChoiceManager.S.ChoiceModifier3();
                return;
            }
            if (ChoiceManager.S.thresholds.Count == 3 && directive == "Right")
            {
                ChoiceManager.S.choice1 = true;
                ChoiceManager.S.choice1S = ChoiceManager.S.SuccessCalculator();
                ChoiceManager.S.ChoiceModifier1();
                return;
            }
            if (ChoiceManager.S.thresholds.Count == 2 && directive == "Right")
            {
                ChoiceManager.S.choice2 = true;
                ChoiceManager.S.choice2S = ChoiceManager.S.SuccessCalculator();
                if (ChoiceManager.S.choice2S == true)
                {
                    ChoiceManager.S.successModifier += 1f;
                }
                ChoiceManager.S.ChoiceModifier2();
                return;
            }
            if (ChoiceManager.S.thresholds.Count == 1 && directive == "Right")
            {
                ChoiceManager.S.choice3 = true;
                ChoiceManager.S.choice3S = ChoiceManager.S.SuccessCalculator();
                ChoiceManager.S.ChoiceModifier3();
                return;
            }
        }
    }

    public void callChoice()
    {
        ChoiceManager.S.canClick = true;
        if (updatePos.x >= posMax)
        {
            updatePos.x -= tempPos * Time.deltaTime;
            button.transform.position = updatePos;
            Invoke("callChoice", 0.001f);
        }
        else if (updatePos.x <= posMin)
        {
            updatePos.x += tempPos * Time.deltaTime;
            button.transform.position = updatePos;
            Invoke("callChoice", 0.001f);
        }
    }

    public void sendBack()
    {
        Decision.text = "";
        if (ChoiceManager.S.canClick = false)
        {
            return;
        }
        else
        {
            if (button.transform.position.x > offScreen.x)
            {
                updatePos.x -= tempPos * Time.deltaTime;
                button.transform.position = updatePos;
                if(otherChoice.transform.position.x < otherChoice.GetComponent<Choice>().offScreen.x)
                {
                    otherChoice.GetComponent<Choice>().updatePos.x += tempPos * Time.deltaTime;
                    otherChoice.transform.position = otherChoice.GetComponent<Choice>().updatePos;
                    Invoke("sendBack", 0.001f);
                }
            }
            else if (button.transform.position.x < offScreen.x)
            {
                updatePos.x += tempPos * Time.deltaTime;
                button.transform.position = updatePos;
                if (otherChoice.transform.position.x > otherChoice.GetComponent<Choice>().offScreen.x)
                {
                    otherChoice.GetComponent<Choice>().updatePos.x -= tempPos * Time.deltaTime;
                    otherChoice.transform.position = otherChoice.GetComponent<Choice>().updatePos;
                    Invoke("sendBack", 0.001f);
                }
            }
        }
    }
}