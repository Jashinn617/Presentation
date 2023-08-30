using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletNum : MonoBehaviour
{
    GameObject remainingBullets;

    int bulletNum = 30;

    public void Firing()
    {
        this.bulletNum -= 1;
    }

    public void Recovery()
    {
        this.bulletNum += 5;
    }

    // Start is called before the first frame update
    void Start()
    {
        this.remainingBullets = GameObject.Find("BulletNum");
    }

    // Update is called once per frame
    void Update()
    {
        this.remainingBullets.GetComponent<Text>().text = this.bulletNum.ToString();
    }
}
