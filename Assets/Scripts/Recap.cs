using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recap : MonoBehaviour
{
    static public int choice1 = 0;
    static public int choice2 = 0;
    static public int choice3 = 0;
    static public int week = 1;

    public int reserve;
    public int opinion;

    private int choice1N = 0;
    private int choice2N = 0;
    private int choice3N = 0;

    void Awake()
    {
        if (PlayerPrefs.HasKey("Choice1"))
        {
            choice1 = PlayerPrefs.GetInt("Choice1");
        }
        PlayerPrefs.SetInt("Choice1", choice1);
        if (PlayerPrefs.HasKey("Choice2"))
        {
            choice2 = PlayerPrefs.GetInt("Choice2");
        }
        PlayerPrefs.SetInt("Choice2", choice2);
        if (PlayerPrefs.HasKey("Choice3"))
        {
            choice3 = PlayerPrefs.GetInt("Choice3");
        }
        PlayerPrefs.SetInt("Choice3", choice3);

        if (PlayerPrefs.HasKey("Week"))
        {
            week = PlayerPrefs.GetInt("Week");
        }
        PlayerPrefs.SetInt("Week", week);

        if (PlayerPrefs.HasKey("Reserve"))
        {
            reserve = PlayerPrefs.GetInt("Reserve");
        }
        PlayerPrefs.SetInt("Reserve", reserve);
        if (PlayerPrefs.HasKey("Opinion"))
        {
            opinion = PlayerPrefs.GetInt("Opinion");
        }
        PlayerPrefs.SetInt("Opinion", opinion);

        if (PlayerPrefs.HasKey("Choice1N"))
        {
            choice1N = PlayerPrefs.GetInt("Choice1N");
        }
        PlayerPrefs.SetInt("Choice1N", choice1N);
        if (PlayerPrefs.HasKey("Choice2N"))
        {
            choice2N = PlayerPrefs.GetInt("Choice2N");
        }
        PlayerPrefs.SetInt("Choice2N", choice2N);
        if (PlayerPrefs.HasKey("Choice3N"))
        {
            choice3N = PlayerPrefs.GetInt("Choice3N");
        }
        PlayerPrefs.SetInt("Choice3N", choice3N);
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Choice1N", choice1);
        PlayerPrefs.SetInt("Choice2N", choice2);
        PlayerPrefs.SetInt("Choice3N", choice3);
    }

    // Update is called once per frame
    void Update()
    {
        if (choice1 != PlayerPrefs.GetInt("Choice1"))
        {
            PlayerPrefs.SetInt("Choice1", choice1);
        }
        if (choice2 != PlayerPrefs.GetInt("Choice2"))
        {
            PlayerPrefs.SetInt("Choice2", choice2);
        }
        if (choice3 != PlayerPrefs.GetInt("Choice3"))
        {
            PlayerPrefs.SetInt("Choice3", choice3);
        }
        if (week != PlayerPrefs.GetInt("Week"))
        {
            PlayerPrefs.SetInt("Week", week);
        }
        if (reserve != PlayerPrefs.GetInt("Reserve"))
        {
            PlayerPrefs.SetInt("Reserve", reserve);
        }
        if (opinion != PlayerPrefs.GetInt("Opinion"))
        {
            PlayerPrefs.SetInt("Opinion", opinion);
        }
    }
}
