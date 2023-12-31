using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public float speedY = 0.3f;

    void Update()
    {
        // フレームごとに落下させる
        transform.Translate(0, -speedY, 0);
    }

    // stageとの当たり判定を調べる
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 床についたら上に戻る
        if (collision.CompareTag("stage"))
        {
            transform.Translate(0, speedY, 0);
        }
    }
}
