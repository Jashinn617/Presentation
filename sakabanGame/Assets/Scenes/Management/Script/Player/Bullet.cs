using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 1;  // 弾のダメージ


    void Start()
    {
        // 弾を発射するSEを再生
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHP enemyHp = collision.gameObject.GetComponent<EnemyHP>();

            if (enemyHp != null)
            {
                enemyHp.Damage(damage);
            }
            Destroy(gameObject);    // 弾を消す
        }

        // 海ステージボス用
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SeaBossHp seaBossHp = collision.gameObject.GetComponent<SeaBossHp>();

            if (seaBossHp != null)
            {
                seaBossHp.Damage(damage);
            }
            Destroy(gameObject);    // 弾を消す
        }

        // 最終ステージボス用
        if (collision.gameObject.CompareTag("Enemy"))
        {
            LastBossHp lastBossHp = collision.gameObject.GetComponent<LastBossHp>();

            if (lastBossHp != null)
            {
                lastBossHp.Damage(damage);
            }
            Destroy(gameObject);    // 弾を消す
        }
    }

    // 弾が画面外に出たら削除
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
