using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverSceneSwitch : MonoBehaviour
{
    public AudioClip backSE;          // Aを押したときの音
    public AudioClip selectSE;		  // Spaceを押したときの音
    private AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームオーバーからホームへ
        if (Input.GetKeyDown(KeyCode.A))
        {
            audioSource.PlayOneShot(backSE);
            SceneManager.LoadScene("HomeScene");
        }

        // ゲームオーバーからセレクトへ
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(selectSE);
            SceneManager.LoadScene("StageSelectScene");
        }
    }
}
