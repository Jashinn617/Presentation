using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip shotSE;    // 弾を発射したSE
    public AudioClip hitSE;     // 弾がEnemyに当たったSE
    AudioSource aud;


    public void PlayShotSE()
    {
        aud.PlayOneShot(shotSE);
    }

    public void PlayHitSE()
    {
        aud.PlayOneShot(hitSE);
    }
}
