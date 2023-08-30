using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoss : MonoBehaviour
{
    public float speed = 5.0f;         // 移動速度
    public float jumpForce = 5.0f;     // ジャンプ力

    private Rigidbody2D rb;
    private bool isMovingRight = true;
    private Vector2 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Vector2.right;  // 右方向に移動する
    }

    void Update()
    {
        // ジャンプ
        if(Mathf.Abs(rb.velocity.y) < 0.01f)    // 地面にいるとき
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        // 左右移動
        rb.velocity = new Vector2(direction.x * speed, rb.velocity.y);
    }


    // 壁との当たり判定
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if(isMovingRight)
            {
                direction = Vector2.left;
                isMovingRight= false;
            }
            else
            {
                direction = Vector2.right;
                isMovingRight = true;
            }
        }
    }
}
