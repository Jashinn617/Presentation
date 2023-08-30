using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeftMove : MonoBehaviour
{
    public float speed = 5.0f;  // 移動速度
    private Rigidbody2D rb2D;   // Rigidbody2Dを定義


    private void Start()
    {
        // Rigidbody2Dのコンポーネントを取得
        rb2D = GetComponent<Rigidbody2D>();
    }


    // 物理演算の処理
    private void FixedUpdate()
    {
        Vector2 move = new Vector2(-speed, 0);  // 左方向に移動
        rb2D.velocity = new Vector2(move.x, rb2D.velocity.y);
    }
}