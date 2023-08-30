using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hand2 : MonoBehaviour
{
    public float speed = 5.0f;      // 移動速度
    private Rigidbody2D rb2D;       // Rigidbody2Dを定義

    private Animator animator;      // handのAnimator

    private bool isMoving = true;   // handが移動しているか判定

    private void Start()
    {
        // Rigidbody2Dのコンポーネントを取得
        rb2D = GetComponent<Rigidbody2D>();

        // Animatorのコンポーネントを取得
        animator = GetComponent<Animator>();
    }


    // 物理演算の処理
    private void FixedUpdate()
    {
        if (isMoving)
        {
            Vector2 move = new Vector2(speed, 0);  // 右方向に移動
            rb2D.velocity = new Vector2(move.x, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = Vector2.zero;   // 停止
        }
    }


    // Playerとの当たり判定を調べる
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 接触したオブジェクトがPlayerタグを持っているかチェック
        if (collision.CompareTag("Player"))
        {
            // アニメーションを実行
            animator.Play("hand2");
            isMoving = false;   // Playerに接触したら停止
        }
    }
}