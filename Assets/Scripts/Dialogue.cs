using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public TMP_Text Text;
    public TMP_Text Name;
    public Text choice1;
    public Text choice2;
    public TMP_Text Decision;
    private string currentText;
    public Queue<string> sentences;
    private Queue<string> names;
    public int i = 1;
    public int j = 0;
    public int[] counter;
    public Queue<string> choice1s;
    public Queue<string> choice2s;
    public List<Sprite> faces;
    public GameObject speaker;
    public int index = 0;
    private bool stopIncrement = false;
    private bool next = true;
    CanvasGroup group;
    public Queue<string> decisions;
    public GameObject recap;
    public GameObject nextWeek;
    public GameObject quit;
    public List<AudioSource> audioSources;


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
        nextWeek.SetActive(false);
        quit.SetActive(false);
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
        StopAllCoroutines();
        StartCoroutine(DisplayText());
        next = true;
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
            if (Name.text == "Archus:")
            {
                audioSources[0].Play();
            }
            else if (Name.text == "Circe:")
            {
                audioSources[1].Play();
            }
            else if (Name.text == "Rectan:")
            {
                audioSources[2].Play();
            }
            alphaIndex++;
            Text.text = originalText;
            displayedText = Text.text.Insert(alphaIndex, "<color=#00000000>");
            Text.text = displayedText;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(1.5f);
        if (i == 61)
        {
            nextWeek.SetActive(true);
            quit.SetActive(true);
        }
        yield return null;
    }

    public void Transition()
    {
        int weekNum = PlayerPrefs.GetInt("Week") + 1;
        recap.GetComponent<Recap>().Save();
        SceneManager.LoadScene("Week" + weekNum);
        Recap.week++;
    }

    public void Return()
    {
        SceneManager.LoadScene("Menu");
    }

    void Update()
    {
        if (decisions.Count > 0 && i == counter[index])
        {
            choice1.text = choice1s.Dequeue();
            choice2.text = choice2s.Dequeue();
            Decision.text = decisions.Dequeue();
            foreach(Choice choice in FindObjectsOfType<Choice>())
            {
                choice.callChoice();
            }
            if (index < 2)
            {
                index++;
            }
        }
    }
}
