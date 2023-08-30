using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectSceneSwitch : MonoBehaviour
{
    // 画像
    int Num;
    
    public AudioClip selectSE;      // A,Dを押したときの音
    public AudioClip backSE;        // back
    public AudioClip decisionSE;    // Enter
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Num = 0;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            audioSource.PlayOneShot(selectSE);
            Num--;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            audioSource.PlayOneShot(selectSE);
            Num++;
        }

        // Numは-1以下、10以上にはならない
        if (Num <= -1)
        {
            Num = 9;
        }
        else if (Num >= 10)
        {
            Num = 0;
        }

        // ステージセレクトからホームへ
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            audioSource.PlayOneShot(backSE);
            SceneManager.LoadScene("HomeScene");
        }

        // 各ステージへ(Numの数字はステージの話数-1になっている)
        if (Input.GetKeyDown(KeyCode.Return))
        {
            audioSource.PlayOneShot(decisionSE);

            if (Num == 0)
            {
                SceneManager.LoadScene("Story1");
            }
            else if (Num == 1)
            {
                SceneManager.LoadScene("Story2");
            }
            else if (Num == 2)
            {
                SceneManager.LoadScene("Story3");
            }
            else if (Num == 3)
            {
                SceneManager.LoadScene("Story4");
            }
            else if (Num == 4)
            {
                SceneManager.LoadScene("Story5");
            }
            else if (Num == 5)
            {
                    SceneManager.LoadScene("Story6");
            }
            else if (Num == 6)
            {
                SceneManager.LoadScene("Story7");
            }
            else if (Num == 7)
            {
                SceneManager.LoadScene("Story8");
            }
            else if (Num == 8)
            {
                SceneManager.LoadScene("Story9");

            }
            else if (Num == 9)
            {
                SceneManager.LoadScene("Story10");
            }

        }

       
    }
}
