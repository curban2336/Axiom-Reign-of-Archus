using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject button;
    public float scaleLimit = 1;

    // Start is called before the first frame update
    void Start()
    {
        button.transform.localScale = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        while (button.transform.localScale.x < scaleLimit)
        {
            Vector3 tempScale = button.transform.localScale;
            tempScale += new Vector3(1, 1, 1) * Time.deltaTime;
            button.transform.localScale = tempScale;
        }
    }
}
