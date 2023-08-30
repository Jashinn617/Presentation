using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLeftRightMove : MonoBehaviour
{
    public float speed = 5.0f;          // 移動速度
    public float moveDistance = 10.0f;  // 左右に移動する距離

    private float leftEnd;              // 左端
    private float rightEnd;             // 右端
    private int direction = -1;         // 移動方向（1: 右、-1: 左）

    private void Start()
    {
        // 左端と右端の位置を計算
        leftEnd = transform.position.x - moveDistance;
        rightEnd = transform.position.x + moveDistance;
    }

    private void Update()
    {
        // 現在の位置を更新
        transform.position += new Vector3(speed * direction * Time.deltaTime, 0, 0);

        // もし左端または右端に到達したら、方向を反転
        if (transform.position.x > rightEnd || transform.position.x < leftEnd)
        {
            direction *= -1;  // 方向を反転

            // spriteの向きを反転
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}