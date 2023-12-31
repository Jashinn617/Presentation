using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastBossHp : MonoBehaviour
{
    public int HP = 3;    // EnemyのHP

    // Playerの弾に当たったときの処理
    public void Damage(int bulletDamage)
    {
        HP -= bulletDamage;   // HPを1減らす

        if (HP <= 0)
        {
            // コルーチンの起動
            StartCoroutine(ChangeCoroutine());
        }
    }


    IEnumerator ChangeCoroutine()
    {
        // 5秒間待つ
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("End1");  // 遷移
    }
}
