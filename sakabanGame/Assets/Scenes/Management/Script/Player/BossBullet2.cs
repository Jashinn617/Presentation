using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossBullet2 : MonoBehaviour
{
    public int damage = 1;  // ’e‚Ìƒ_ƒ[ƒW


    void Start()
    {
        // ’e‚ğ”­Ë‚·‚éSE‚ğÄ¶
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SkyBoss"))
        {
            SkyBoss2HP bossHp = collision.gameObject.GetComponent<SkyBoss2HP>();

            if (bossHp != null)
            {
                bossHp.Damage(damage);
            }
            Destroy(gameObject);    // ’e‚ğÁ‚·
        }
    }

    // ’e‚ª‰æ–ÊŠO‚Éo‚½‚çíœ
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
