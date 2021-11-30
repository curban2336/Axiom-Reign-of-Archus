using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Script
{
    [TextArea(3, 10)]
    public string[] sentences;
    public string[] names;

    public void Add(string[] sentence, string[] name, int length, int startIndex)
    {
        int j = 0;
        for(int i = startIndex; i < length; i++)
        {
            Debug.Log(i);
            sentences[i] = sentence[j];
            names[i] = name[j];
            if (j < sentence.Length)
            {
                j++;
            }
        }
    }
}
