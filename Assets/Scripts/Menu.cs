using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public static int S;
    
    public GameObject button;
    private float tempPos;
    private Vector3 updatePos;
    private float posMax;
    private float posMin;
    public bool posConfirm = false;

    void Awake()
    {
        posMax = button.transform.position.y;
        posMin = button.transform.position.y - 0.5f;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        updatePos = button.transform.position;
        updatePos.y = -35;
        tempPos = 0.1f;
        button.transform.position = updatePos;
    }

    // Update is called once per frame
    void Update()
    {
        if(posConfirm = false && updatePos.y >= posMax)
        {
            posConfirm = true;
            Menu.S++;
            Debug.Log("S: " + Menu.S);
        }
        else if (updatePos.y <= posMin)
        {
            updatePos.y += tempPos;
            button.transform.position = updatePos;
        }
    }
}
