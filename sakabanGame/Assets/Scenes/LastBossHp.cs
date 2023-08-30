using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastBossHp : MonoBehaviour
{
    public int HP = 3;    // Enemy‚ÌHP

    // Player‚Ì’e‚É“–‚½‚Á‚½‚Æ‚«‚Ìˆ—
    public void Damage(int bulletDamage)
    {
        HP -= bulletDamage;   // HP‚ğ1Œ¸‚ç‚·

        if (HP <= 0)
        {
            // ƒRƒ‹[ƒ`ƒ“‚Ì‹N“®
            StartCoroutine(ChangeCoroutine());
        }
    }


    IEnumerator ChangeCoroutine()
    {
        // 5•bŠÔ‘Ò‚Â
        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("End1");  // ‘JˆÚ
    }
}
