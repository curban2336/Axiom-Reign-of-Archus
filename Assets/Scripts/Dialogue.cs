using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TMP_Text Text;
    private string currentText;

    CanvasGroup group;
    
    // Start is called before the first frame update
    void Start()
    {
        group = GetComponent<CanvasGroup>();
        group.alpha = 0;
        Show(Text.text);
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
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }
}
