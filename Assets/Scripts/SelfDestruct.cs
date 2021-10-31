using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public GameObject button;
    private float tempPos;
    public Vector3 offScreen;
    public Vector3 updatePos;
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
        updatePos.y = -100f;
        tempPos = 0.2f;
        offScreen = updatePos;
    }

    public void Press()
    {
        posConfirm = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (posConfirm == true && button.transform.position.y > offScreen.y)
        {
            updatePos.x -= tempPos;
            button.transform.position = updatePos;
        }
    }
}
