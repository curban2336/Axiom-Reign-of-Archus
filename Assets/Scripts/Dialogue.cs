using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text Text;
    public TMP_Text Name;
    public Text choice1;
    public Text choice2;
    public TMP_Text Decision;
    private string currentText;
    private Queue<string> sentences;
    private Queue<string> names;
    public int i = 1;
    public int j = 0;
    public int[] counter;
    public Queue<string> choice1s;
    public Queue<string> choice2s;
    public Queue<string> decisions;
    public List<Sprite> faces;
    public GameObject speaker;
    public int index = 0;
    private bool returnConfirm = false;
    private bool stopIncrement = false;

    CanvasGroup group;

    void Awake()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
        choice1s = new Queue<string>();
        choice1s.Enqueue("Yes");
        choice1s.Enqueue("Yes");
        choice1s.Enqueue("Exile");
        choice2s = new Queue<string>();
        choice2s.Enqueue("No");
        choice2s.Enqueue("No");
        choice2s.Enqueue("Imprison");
        decisions = new Queue<string>();
        decisions.Enqueue("Declare Martial Law?");
        decisions.Enqueue("Send Investigators beyond Geomet Territory to find Dena?");
        decisions.Enqueue("Exile or Imprison Heretics?");
        Decision.text = "";
    }
    
    // Start is called before the first frame update
    void Start()
    {
        group = GetComponent<CanvasGroup>();
        group.alpha = 0;
    }

    public void StartDialogue(Script dialogue)
    {
        sentences.Clear();
        names.Clear();

        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0) return;
        if (names.Count == 0) return;

        Name.text = names.Dequeue();

        if(Name.text == "Archus:")
        {
            speaker.GetComponent<Image>().sprite = faces[0];
        }
        else if (Name.text == "Circe:")
        {
            speaker.GetComponent<Image>().sprite = faces[1];
        }
        else if (Name.text == "Rectan:")
        {
            speaker.GetComponent<Image>().sprite = faces[2];
        }
        else if (Name.text == "Dena:")
        {
            speaker.GetComponent<Image>().sprite = faces[3];
        }

        string sentence = sentences.Dequeue();

        Show(sentence); 
    }

    public void Show(string text)
    {
        group.alpha = 1;
        currentText = text;
        StartCoroutine(DisplayText());
    }

    public void Close()
    {
        StopAllCoroutines();
        group.alpha = 0;
    }

    public void Increment()
    {
        if (names.Count == 0)
        {
            if (stopIncrement == false)
            {
                i++;
                stopIncrement = true;
            }
            return;
        }
        i++;
        stopIncrement = false;
    }

    private IEnumerator DisplayText()
    {
        Text.text = "";

        string originalText = currentText;
        string displayedText = "";
        int alphaIndex = 0;

        foreach(char c in currentText.ToCharArray())
        {
            alphaIndex++;
            Text.text = originalText;
            displayedText = Text.text.Insert(alphaIndex, "<color=#00000000>");
            Text.text = displayedText;
            yield return new WaitForSeconds(0.02f);
        }
        yield return null;
    }

    void Update()
    {
        if (returnConfirm == false && counter[index] != null && decisions.Count > 0 && i == counter[index])
        {
            choice1.text = choice1s.Dequeue();
            choice2.text = choice2s.Dequeue();
            Decision.text = decisions.Dequeue();
            foreach(Choice choice in FindObjectsOfType<Choice>())
            {
                choice.callChoice();
            }
            returnConfirm = true;
            if (index < 2)
            {
                index++;
            }
        }
        else
        {
            returnConfirm = false;
        }
    }
}
