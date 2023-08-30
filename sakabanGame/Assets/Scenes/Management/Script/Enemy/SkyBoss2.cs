using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoss2 : MonoBehaviour
{
    public float speed = 5.0f;                        // 移動速度
    public float moveRange = 1.5f;                    // 移動範囲
    public float changeTime = 3.0f;                   // 目的地変更の間隔
    public Vector2 minMoveArea = new Vector2(-8, -2); // 最小の移動範囲
    public Vector2 maxMoveArea = new Vector2(8, 2);   // 最大の移動範囲

    private Vector2 targetPosition;    // 目的地
    private Rigidbody2D rb2D;



    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

        // 初めの目的地を設定する
        moveRandomPosition();

        // 一定時間で目的地を更新する
        StartCoroutine(ChangeTargetPosition());
    }


    void Update()
    {
        // 目的地への方向と速度を計算
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;
        rb2D.velocity = direction * speed;

        // 目的地との距離を計算する
        float distance = Vector2.Distance(transform.position, targetPosition);

        // 目的地に近づいたら新しい目的地を設定する
        if(distance < 0.1f)
        {
            moveRandomPosition();
        }
    }


    // ランダムな目的地を設定
    void moveRandomPosition()
    {
        float randomX = Random.Range(minMoveArea.x, maxMoveArea.x);
        float randomY = Random.Range(minMoveArea.y, maxMoveArea.y);
        // 新しい位置に移動
        targetPosition = new Vector2(randomX, randomY);
    }


    // 一定時間で目的地を更新するコルーチン
    IEnumerator ChangeTargetPosition()
    {
        while(true)
        {
            yield return new WaitForSeconds(1);
            moveRandomPosition();
        }
        
    }
}