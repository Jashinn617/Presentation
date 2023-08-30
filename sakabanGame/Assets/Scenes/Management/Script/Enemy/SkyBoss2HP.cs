using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyBoss2HP : MonoBehaviour
{
    public int HP = 15;                      // bossのHP
    Animator animator;                      // Animatorコンポーネント


    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Playerの弾に当たったときの処理
    public void Damage(int bulletDamage)
    {
        HP -= bulletDamage;   // HPを1減らす

        if (HP <= 0)
        {
            SceneManager.LoadScene("ResultScene");  // HPが0になったら遷移
        }
    }
}
