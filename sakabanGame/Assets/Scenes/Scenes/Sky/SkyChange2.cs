using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyChange2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // コルーチンの起動
        StartCoroutine(ChangeCoroutine());
    }

    IEnumerator ChangeCoroutine()
    {
        // 2秒間待つ
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene("SkyBossScene2");  // 遷移
    }

}
