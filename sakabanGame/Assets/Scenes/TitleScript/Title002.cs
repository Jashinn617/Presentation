using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title002 : MonoBehaviour
{
    int Num;

    public Image displayImage;

    // Start is called before the first frame update
    void Start()
    {
        Num = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Num--;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Num++;
        }

        if (Num <= -1)
        {
            Num = 9;
        }
        else if (Num >= 10)
        {
            Num = 0;
        }

        if (Num == 1)
        {
            displayImage.gameObject.SetActive(true);
        }
        else
        {
            displayImage.gameObject.SetActive(false);
        }
    }
}
