using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class _choice
{
    public int modifierS;
    public int modifierF;
    public string designatorS;
    public string designatorF;
    public int modifier2S;
    public int modifier2F;
    public string designator2S;
    public string designator2F;
}

public class ChoiceManager: MonoBehaviour
{
    public bool choice1 = false;
    public bool choice2 = false;
    public bool choice3 = false;
    public bool choice1S = false;
    public bool choice2S = false;
    public bool choice3S = false;
    public List<bool> choiceS;
    public float successModifier = 0;
    public int publicOpinion = 100;
    public int axiomReserve = 1000;
    public int resourceR = 0;
    public int resourceP = 0;
    public Queue<int> thresholds;
    public int threshold1;
    public int threshold2;
    public int threshold3;
    public TMP_Text POText;
    public TMP_Text ARText;
    public GameObject PO;
    public GameObject AR;
    public _choice choiceOne;
    public _choice choiceTwo;
    public _choice choiceThree;
    
    // Start is called before the first frame update
    void Start()
    {
        resourceP = publicOpinion;
        resourceR = axiomReserve;

        thresholds = new Queue<int>();
        thresholds.Enqueue(threshold1);
        thresholds.Enqueue(threshold2);
        thresholds.Enqueue(threshold3);
        choiceS = new List<bool>();
        choiceS.Add(choice1S);
        choiceS.Add(choice2S);
        choiceS.Add(choice3S);
        POText = PO.GetComponent<TextMeshProUGUI>();
        POText.text = "Public Opinion: " + publicOpinion;
        ARText = AR.GetComponent<TextMeshProUGUI>();
        ARText.text = "Axiom Reserve: " + axiomReserve;
    }

    public void SuccessCalculator(bool choice)
    {
        float successChance = Random.Range(1f, 10f) + successModifier;
        int threshold = thresholds.Dequeue();
        if (successChance >= threshold)
        {
            choice = true;
        }
        else
        {
            choice = false;
        }
    }

    public void ChoiceModifier()
    {
        string designator = "";
        int resource = 0;
        if (choice1 == false)
        {
            if (choiceS[0] == false)
            {
                if (choiceOne.designatorF == "PO")
                {
                    designator = "Public Opinion: ";
                    resourceP += choiceOne.modifierF;
                    resource = resourceP;
                }
                else if (choiceOne.designatorF == "AR")
                {
                    designator = "Axiom Reserve: ";
                    resourceR += choiceOne.modifierF;
                    resource = resourceR;
                }

                GameObject.FindGameObjectWithTag(choiceOne.designatorF).GetComponent<TextMeshProUGUI>().text = designator + (resource);
                return;
            }
            if (choiceS[0] == true)
            {
                if (choiceOne.designatorS == "PO")
                {
                    designator = "Public Opinion: ";
                    resourceP += choiceOne.modifierS;
                    resource = resourceP;
                }
                else if (choiceOne.designatorS == "AR")
                {
                    designator = "Axiom Reserve: ";
                    resourceR += choiceOne.modifierS;
                    resource = resourceR;
                }

                GameObject.FindGameObjectWithTag(choiceOne.designatorS).GetComponent<TextMeshProUGUI>().text = designator + (resource);
                return;
            }
        }
        if (choice1 == true)
        {
            if (choiceS[0] == false)
            {
                if (choiceOne.designator2F == "PO")
                {
                    designator = "Public Opinion: ";
                    resourceP += choiceOne.modifier2F;
                    resource = resourceP;
                }
                else if (choiceOne.designator2F == "AR")
                {
                    designator = "Axiom Reserve: ";
                    resourceR += choiceOne.modifier2F;
                    resource = resourceR;
                }

                GameObject.FindGameObjectWithTag(choiceOne.designator2F).GetComponent<TextMeshProUGUI>().text = designator + (resource);
                return;
            }
            if (choiceS[0] == true)
            {
                if (choiceOne.designator2S == "PO")
                {
                    designator = "Public Opinion: ";
                    resourceP += choiceOne.modifier2S;
                    resource = resourceP;
                }
                else if (choiceOne.designator2S == "AR")
                {
                    designator = "Axiom Reserve: ";
                    resourceR += choiceOne.modifier2S;
                    resource = resourceR;
                }

                GameObject.FindGameObjectWithTag(choiceOne.designator2S).GetComponent<TextMeshProUGUI>().text = designator + (resource);
                return;
            }
        }
        if (choice2 == false)
        {
            if (choiceS[1] == false)
            {
                if (choiceTwo.designatorF == "PO")
                {
                    designator = "Public Opinion: ";
                    resourceP += choiceTwo.modifierF;
                    resource = resourceP;
                }
                else if (choiceTwo.designatorF == "AR")
                {
                    designator = "Axiom Reserve: ";
                    resourceR += choiceTwo.modifierF;
                    resource = resourceR;
                }

                GameObject.FindGameObjectWithTag(choiceTwo.designatorF).GetComponent<TextMeshProUGUI>().text = designator + (resource);
                return;
            }
            if (choiceS[1] == true)
            {
                if (choiceTwo.designatorS == "PO")
                {
                    designator = "Public Opinion: ";
                    resourceP += choiceTwo.modifierS;
                    resource = resourceP;
                }
                else if (choiceTwo.designatorS == "AR")
                {
                    designator = "Axiom Reserve: ";
                    resourceR += choiceTwo.modifierS;
                    resource = resourceR;
                }

                GameObject.FindGameObjectWithTag(choiceTwo.designatorS).GetComponent<TextMeshProUGUI>().text = designator + (resource);
                return;
            }
        }
        if (choice2 == true)
        {
            if (choiceS[1] == false)
            {
                if (choiceTwo.designator2F == "PO")
                {
                    designator = "Public Opinion: ";
                    resourceP += choiceTwo.modifier2F;
                    resource = resourceP;
                }
                else if (choiceTwo.designator2F == "AR")
                {
                    designator = "Axiom Reserve: ";
                    resourceR += choiceTwo.modifier2F;
                    resource = resourceR;
                }

                GameObject.FindGameObjectWithTag(choiceTwo.designator2F).GetComponent<TextMeshProUGUI>().text = designator + (resource);
                return;
            }
            if (choiceS[1] == true)
            {
                if (choiceTwo.designator2S == "PO")
                {
                    designator = "Public Opinion: ";
                    resourceP += choiceTwo.modifier2S;
                    resource = resourceP;
                }
                else if (choiceTwo.designator2S == "AR")
                {
                    designator = "Axiom Reserve: ";
                    resourceR += choiceTwo.modifier2S;
                    resource = resourceR;
                }

                GameObject.FindGameObjectWithTag(choiceTwo.designator2S).GetComponent<TextMeshProUGUI>().text = designator + (resource);
                return;
            }
        }
        if (choice3 == false)
        {
            if (choiceS[2] == false)
            {
                if (choiceThree.designatorF == "PO")
                {
                    designator = "Public Opinion: ";
                    resourceP += choiceThree.modifierF;
                    resource = resourceR;
                }
                else if (choiceThree.designatorF == "AR")
                {
                    designator = "Axiom Reserve: ";
                    resourceR += choiceThree.modifierF;
                    resource = resourceP;
                }

                GameObject.FindGameObjectWithTag(choiceThree.designatorF).GetComponent<TextMeshProUGUI>().text = designator + (resource);
                return;
            }
            if (choiceS[2] == true)
            {
                if (choiceThree.designatorS == "PO")
                {
                    designator = "Public Opinion: ";
                    resourceP += choiceThree.modifierS;
                    resource = resourceP;
                }
                else if (choiceThree.designatorS == "AR")
                {
                    designator = "Axiom Reserve: ";
                    resourceP += choiceThree.modifierS;
                    resource = resourceR;
                }

                GameObject.FindGameObjectWithTag(choiceThree.designatorS).GetComponent<TextMeshProUGUI>().text = designator + (resource);
                return;
            }
        }
        if (choice3 == true)
        {
            if (choiceS[2] == false)
            {
                if (choiceThree.designator2F == "PO")
                {
                    designator = "Public Opinion: ";
                    resourceP += choiceThree.modifier2F;
                    resource = resourceP;
                }
                else if (choiceThree.designator2F == "AR")
                {
                    designator = "Axiom Reserve: ";
                    resourceR += choiceThree.modifier2F;
                    resource = resourceR;
                }

                GameObject.FindGameObjectWithTag(choiceThree.designator2F).GetComponent<TextMeshProUGUI>().text = designator + (resource);
                return;
            }
            if (choiceS[2] == true)
            {
                if (choiceThree.designator2S == "PO")
                {
                    designator = "Public Opinion: ";
                    resourceP += choiceThree.modifier2S;
                    resource = resourceP;
                }
                else if (choiceThree.designator2S == "AR")
                {
                    designator = "Axiom Reserve: ";
                    resourceR += choiceThree.modifier2S;
                    resource = resourceR;
                }

                GameObject.FindGameObjectWithTag(choiceThree.designator2S).GetComponent<TextMeshProUGUI>().text = designator + (resource);
                return;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}