using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int enemyBulletDamage = 1;  // 弾のダメージ


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                player.TakeDamage(enemyBulletDamage);
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
