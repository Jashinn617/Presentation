using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public int HP = 3;    // Enemy‚ÌHP

    // Player‚Ì’e‚É“–‚½‚Á‚½‚Æ‚«‚Ìˆ—
    public void Damage(int bulletDamage)
    {
        HP -= bulletDamage;   // HP‚ğ1Œ¸‚ç‚·
        
        if(HP <= 0)
        {
            Destroy(gameObject);    // “G‚ªÁ‚¦‚é
        }
    }
}
