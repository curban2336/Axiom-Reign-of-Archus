using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text Text;
    public TMP_Text Name;
    private string currentText;
    private Queue<string> sentences;
    private Queue<string> names;
    private int i = 0;
    private bool returnConfirm = false;

    CanvasGroup group;

    void Awake()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
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
        i++;
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
            yield return new WaitForSeconds(0.05f);
        }
        yield return null;
    }

    void Update()
    {
        if (i == 2 && returnConfirm == false)
        {
            foreach(Choice choice in FindObjectsOfType<Choice>())
            {
                choice.callChoice();
            }
            returnConfirm = true;
        }
    }
}
