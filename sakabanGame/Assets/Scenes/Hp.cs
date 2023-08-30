using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    GameObject HP;

    // Start is called before the first frame update
    void Start()
    {
        this.HP = GameObject.Find("HP");    // SceneからHPのオブジェクトを探す
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void DeleteHp()
    {
       this.HP.GetComponent<Image>().fillAmount -= 0.2f;
    }
    public void RecoveryHp()
    {
        this.HP.GetComponent<Image>().fillAmount += 0.2f;
    }
}
