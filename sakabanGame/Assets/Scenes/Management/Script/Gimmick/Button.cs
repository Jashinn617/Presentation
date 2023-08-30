using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private Animator animator;      // buttonのAnimator

    private void Start()
    {
        // Animatorのコンポーネントを取得
        animator = GetComponent<Animator>();
    }


    // Playerとの当たり判定を調べる
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 接触したオブジェクトがPlayerタグを持っているかチェック
        if (collision.CompareTag("Player"))
        {
            // アニメーションを実行
            animator.Play("button");

            // Recoveryのオブジェクトを取得
            GameObject recovery = GameObject.Find("Recovery");
            // オブジェクト落下
            recovery.transform.Translate(0, -10.0f, 0);
        }
    }
}
