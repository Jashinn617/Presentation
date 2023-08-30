using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SeaPlayer_test : MonoBehaviour
{
    public int playerHP = 5;             // プレイヤーのHP
    public float speedX = 5.0f;          // プレイヤーのX軸方向の移動速度
    public float speedY = 3.0f;          // プレイヤーのY軸方向の移動速度
    private float moveX;                 // X軸の移動方向
    private float moveY;                 // Y軸の移動方向
    private Vector2 moveDirection;       // 移動方向
    private Vector3 startPosition;       // スタート位置
    private Rigidbody2D rb2D;
    private SpriteRenderer renderer;
    private Animator animator;           // PlayerのAnimator

    public AudioClip hitSE;              // 敵に当たったときの音
    public AudioClip shotSE;             // 弾を発射したときの音
    public AudioClip recoverySE;         // 回復をとったときの音
    private AudioSource audioSource;     // 音源

    public GameObject bulletPrefab;      // 弾のPrefab
    public float bulletSpeed = 10.0f;    // 弾の速度
    public int bulletNum = 30;           // 弾数
    public Transform firePoint;          // 弾を発射する位置

    GameObject bulletManager;           // UIの残弾管理
    public int bulletRecovery = 5;      // 残段回復アイテム
    public int hpRecovery = 1;          // Hp回復アイテム


    void Start()
    {
        startPosition = transform.position;                                     // 初期位置を保存
     renderer = GetComponent<SpriteRenderer>();                              // SpriteRenderのコンポーネントを取得
        rb2D = GetComponent<Rigidbody2D>();                                     // Rigidbody2Dのコンポーネントを取得
        animator = GetComponent<Animator>();                                    // Animatorのコンポーネントを取得
        this.bulletManager = GameObject.Find("RemainingBulletsManagement");     // 残弾の管理
        audioSource = GetComponent<AudioSource>();  // AudioSourceコンポーネントを取得
    }


    void Update()
    {
        moveX = 0;
        moveY = 0;

        if (Input.GetKey(KeyCode.A))    // 左方向
        {
            moveX = -speedX;
           
        }
        if (Input.GetKey(KeyCode.D))    // 右方向
        {
            moveX = speedX;
          
        }
        if (Input.GetKey(KeyCode.W))    // 上方向
        {
            moveY = speedY;
        }
        if (Input.GetKey(KeyCode.S))    // 下方向
        {
            moveY = -speedY;
        }
        moveDirection = new Vector2(moveX, moveY).normalized;

        // 弾発射呼び出し
        if (Input.GetKeyDown(KeyCode.Return) && (bulletNum > 0))
        {
            audioSource.PlayOneShot(shotSE);
            Shoot();

            bulletNum--;

            this.bulletManager.GetComponent<BulletNum>().Firing();
        }

        // 弾発射
        void Shoot()
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = Vector2.right * bulletSpeed;  // 弾を右方向に発射
        }

    }

    // Rigidbodyの速度を更新
    void FixedUpdate()
    {
        rb2D.velocity = moveDirection * new Vector2(speedX, speedY);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bulleRecovery"))
        {
            audioSource.PlayOneShot(recoverySE);
            bulletNum += bulletRecovery;
            this.bulletManager.GetComponent<BulletNum>().Recovery();
            collision.gameObject.SetActive(false);
        }
        if (collision.CompareTag("HpRecovery"))
        {
            audioSource.PlayOneShot(recoverySE);
            playerHP += hpRecovery;

            if (playerHP >= 6)
            {
                playerHP = 5;
            }
            GameObject hpDelete = GameObject.Find("HpDelete");
            hpDelete.GetComponent<Hp>().RecoveryHp();
            collision.gameObject.SetActive(false);

        }
        if (collision.CompareTag("Enemy"))
        {
            audioSource.PlayOneShot(hitSE);
            playerHP--;

            // HPのUI表示
            GameObject HP = GameObject.Find("Hp");  // Hpスクリプトを取得
            HP.GetComponent<Hp>().DeleteHp();       // HpスクリプトのDeleteHp関数を呼び出し

            if (playerHP <= 0)
            {
                // Animation再生
                animator.Play("GameOver");
                // コルーチンの起動
                StartCoroutine(GameOverCoroutine());
            }
        }
    }

    // 敵の弾に当たった際の処理
    public void TakeDamage(int damage)
    {
        audioSource.PlayOneShot(hitSE);
        playerHP -= damage;

        if (playerHP <= 0)
        {
            // コルーチンの起動
            StartCoroutine(GameOverCoroutine());
        }
    }


    // Player削除のコルーチン
    IEnumerator DelayCoroutine()
    {
        // 1秒間待つ
        yield return new WaitForSeconds(1);

        // Playerの削除
        Destroy(gameObject);
    }


    // GameOverのコルーチン
    IEnumerator GameOverCoroutine()
    {
        speedX = 0;
        speedY = 0;

        // Animation再生
        animator.Play("GameOver");

        // 2秒間待つ
        yield return new WaitForSeconds(2);

        // GameOver画面に遷移
        SceneManager.LoadScene("GameOverScene");
    }


}

