using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SeaPlayer : MonoBehaviour
{
    private float speed = 0.03f;
    public float bulletSpeed = 5.0f;

    private SpriteRenderer renderer;
    private Animator animator;              // PlayerのAnimator

    // 弾
    public GameObject Minipis;
    // 弾の数
    public int bulletNum = 30;
    // UIの残団管理
    GameObject bulletManager;
    // 残段回復アイテム
    public int bulletRecovery = 5;

    // プレイヤーのHP
    public int playerHp = 5;
    // Hp回復アイテム
    public int hpRecovery = 1;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        this.bulletManager = GameObject.Find("RemainingBulletsManagement");
    }

    void Update()
    {

        // 四方向移動
        Vector2 position = transform.position;

        if (Input.GetKey(KeyCode.A))
        {
            position.x -= speed;
            renderer.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            position.x += speed;
            renderer.flipX = false;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            position.y += speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            position.y -= speed;
        }

        transform.position = position;

        // 弾発射呼び出し
        if (Input.GetKeyDown(KeyCode.Return) && (bulletNum > 0))
        {
            Shoot();

            bulletNum--;

            this.bulletManager.GetComponent<BulletNum>().Firing();
        }

        // 弾発射
        void Shoot()
        {
            GameObject playerShot = Instantiate(Minipis) as GameObject;
            playerShot.transform.position = this.transform.position * bulletSpeed;
        }

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "bulleRecovery")
        {
            bulletNum += bulletRecovery;
            this.bulletManager.GetComponent<BulletNum>().Recovery();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "HpRecovery")
        {
            playerHp += hpRecovery;
            if (playerHp >= 6)
            {
                playerHp = 5;
            }
            GameObject hpDelete = GameObject.Find("HpDelete");
            hpDelete.GetComponent<Hp>().RecoveryHp();
            other.gameObject.SetActive(false);

        }
        else if (other.gameObject.tag == "Enemy")
        {
            playerHp--;
            GameObject hpDelete = GameObject.Find("HpDelete");
            hpDelete.GetComponent<Hp>().DeleteHp();
            if (playerHp <= 0)
            {
                // Animation再生
                animator.Play("GameOver");
                // コルーチンの起動
                GameOverCoroutine();
            }
        }
    }

    // GameOverのコルーチン
    IEnumerator GameOverCoroutine()
    {
        // 2秒間待つ
        yield return new WaitForSeconds(2);

        // GameOver画面に遷移
        SceneManager.LoadScene("GameOverScene");
    }


}

