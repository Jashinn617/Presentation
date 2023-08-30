using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkyBossHP : MonoBehaviour
{
    public int HP = 6;                      // bossのHP
    Animator animator;                      // Animatorコンポーネント
 //   public Sprite[] bossSprites;            // bossのスプライトを格納する配列
 //   private SpriteRenderer spriteRenderer;  // bossのSpriteRendererコンポーネント

    private void Start()
    {
        // SpriteRendererのコンポーネントを取得
        //spriteRenderer = GetComponent<SpriteRenderer>();

        animator = GetComponent<Animator>();
    }

    // Playerの弾に当たったときの処理
    public void Damage(int bulletDamage)
    {
        HP -= bulletDamage;   // HPを1減らす

        //if(HP > 0 && HP <= 6)
        //{
        //   spriteRenderer.sprite = bossSprites[HP - 1];
        //}

        if(HP == 5)
        {
            animator.Play("boss1");
        }
        if(HP == 4)
        {
            animator.Play("boss2");
        }
        if(HP == 3)
        {
            animator.Play("boss3");
        }
        if(HP == 2)
        {
            animator.Play("boss4");
        }
        if(HP == 1)
        {
            animator.Play("boss5");
        }
        if (HP <= 0)
        {
            SceneManager.LoadScene("SkyBossCut1");  // HPが0になったら遷移
        }
    }
}
