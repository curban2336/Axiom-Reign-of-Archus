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
    private int i = 0;

    CanvasGroup group;

    void Awake()
    {
        sentences = new Queue<string>();
        //Name.text = scripts[i]._name;
        //Text.text = scripts[i]._line;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        group = GetComponent<CanvasGroup>();
        group.alpha = 0;
        Show(Text.text);
    }

    public void StartDialogue(Script dialogue)
    {

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
        //Name.text = scripts[i]._name;
        //Text.text = scripts[i]._line;
        Show(Text.text);
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
}
