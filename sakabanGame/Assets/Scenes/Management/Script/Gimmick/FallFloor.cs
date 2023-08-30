using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallFloor : MonoBehaviour
{
    public float speed = 0.1f;  // 床の落ちる速さ
    private float fallCount;    // 床が落ちるまでの時間
    private bool floorTouch;    // プレイヤーが床に触れたかの判定
    private Rigidbody2D rb2D;



    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();     // Rigidbody2Dのコンポーネントを取得
        fallCount = 0;                          // fallCountの初期化
    }

    void Update()
    {
        // 床に触れたら
        if(floorTouch == true)
        {
            // fallCountを増やす
            fallCount += Time.deltaTime;

            DownStart();
        }
    }

    // 当たり判定
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        if(collision2D.gameObject.tag == "Player")
        {
            fallCount = 0;      // fallCountの初期化
            floorTouch = true;  // floorTouchをtrueにする
        }
    }

    // 数秒後に床が落ちる
    void DownStart()
    {
        if(fallCount>= 0.5f)
        {
            transform.Translate(0, -speed, 0);
        }
    }
}
