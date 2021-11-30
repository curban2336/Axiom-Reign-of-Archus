using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Script
{
    [TextArea(3, 10)]
    public string[] sentences;
    public string[] names;

    public void Add(string[] sentence, string[] name, int length)
    {
        for(int i = 0; i < length; i++)
        {
            sentences[i] = sentence[i];
            names[i] = name[i];
        }
    }
}
