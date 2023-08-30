using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUpDownMove : MonoBehaviour
{
    public float speed = 1.0f;        // 移動速度
    public float moveRange = 3.0f;    // 移動範囲
    private Vector2 startPosition;    // 初期位置


    private void Start()
    {
        startPosition = transform.position;   // 初期位置を保存
    }


    private void Update()
    {
        // sin関数を使用して位置を計算する
        float newYPosition = startPosition.y + Mathf.Sin(Time.time * speed) * moveRange;

        // 新しい位置にオブジェクトを移動
        transform.position = new Vector2(startPosition.x, newYPosition);
    }
}