using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioClip shotSE;    // ’e‚ð”­ŽË‚µ‚½SE
    public AudioClip hitSE;     // ’e‚ªEnemy‚É“–‚½‚Á‚½SE
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
