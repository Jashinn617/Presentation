using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
  
    // Playerがゴールに触れたらクリア画面に遷移
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // クリア画面に移動する
            SceneManager.LoadScene("ResultScene");
        }
    }
}