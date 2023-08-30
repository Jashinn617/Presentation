using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class same : MonoBehaviour
{
    public float speed = 9.0f;              // 移動速度
    private Rigidbody2D rb2D;               // Rigidbody2Dを定義

    // アニメーション再生
    public float animationDistance = 10.0f;  // この距離内にプレイヤーが入ったらアニメーションを開始
    private Animator animator;              // sameのAnimator
    private Transform player;               // PlayerのTransform


    private void Start()
    {
        // Rigidbody2Dのコンポーネントを取得
        rb2D = GetComponent<Rigidbody2D>();
        // Animatorのコンポーネントを取得
        animator = GetComponent<Animator>();

        // PlayerタグのTransformを取得
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    private void Update()
    {
        // 敵とプレイヤーとの距離を計算
        float distance = Vector2.Distance(transform.position, player.position);

        // 距離内に入ったらアニメーションを開始
        if (distance <= animationDistance)
        {
            animator.Play("same");
        }
    }


    // 物理演算の処理
    private void FixedUpdate()
    {
        Vector2 move = new Vector2(-speed, 0);  // 左方向に移動
        // rigidbody2Dのvelocity(速度)へ取得したspeedを代入する
        rb2D.velocity = new Vector2(move.x, rb2D.velocity.y);
    }
}