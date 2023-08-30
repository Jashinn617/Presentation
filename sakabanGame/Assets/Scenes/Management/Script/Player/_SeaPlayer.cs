using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class _SeaPlayer : MonoBehaviour
{
    public int playerHP = 5;             // プレイヤーのHP
    public float speedX = 5.0f;          // プレイヤーのX軸方向の移動速度
    public float speedY = 3.0f;          // プレイヤーのY軸方向の移動速度
    private float moveX;                 // X軸の移動方向
    private float moveY;                 // Y軸の移動方向
    private Vector2 moveDirection;       // 移動方向
    private Vector3 startPosition;       // スタート位置
    private Rigidbody2D rb2D;
    private Animator animator;           // PlayerのAnimator

    public GameObject bulletPrefab;      // 弾のPrefab
    public int bulletNum = 30;           // 弾数
    public float bulletSpeed = 10.0f;    // 弾の速度
    public Transform firePoint;          // 弾を発射する位置
    GameObject bulletManager;            // UIの残弾管理

    public int bulletRecovery = 5;       // 弾数回復アイテム
    public int hpRecovery = 1;           // HP回復アイテム

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();     // Rigidbody2Dのコンポーネントを取得
        animator = GetComponent<Animator>();    // Animatorのコンポーネントを取得
        startPosition = transform.position;     // 初期位置を保存
        this.bulletManager = GameObject.Find("RemainingBulletsManagement");
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

        // 弾を発射
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Shoot();
        }
    }

    // Rigidbodyの速度を更新
    void FixedUpdate()
    {
        rb2D.velocity = moveDirection * new Vector2(speedX, speedY);
    }

    // 弾を発射する
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.right * bulletSpeed;  // 弾を右方向に発射
    }

    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Enemyまたはギミックに当たったときの処理
        if (collision.CompareTag("Enemy") || collision.CompareTag("gimmick"))
        {
            playerHP--;   // HPを1減らす

            // HPが0になったらゲームオーバー
            if (playerHP <= 0)
            {
                // Animation再生
                animator.Play("GameOver");
                // コルーチンの起動
                StartCoroutine(GameOverCoroutine());
            }
        }

        // 壁に挟まれた時の処理
        if(collision.CompareTag("Wall"))
        {
            // ステージの最初から再開
            transform.position = startPosition;
        }

        // 手に当たった際の処理
        if(collision.CompareTag("Hand"))
        {
            // コルーチンの起動
            StartCoroutine(DelayCoroutine());
        }

        // 残弾回復
        if (collision.CompareTag("bulleRecovery"))
        {
            bulletNum += bulletRecovery;
            this.bulletManager.GetComponent<BulletNum>().Recovery();
            collision.gameObject.SetActive(false);
        }

        // HP回復
        if (collision.CompareTag("HpRecovery"))
        {
            playerHP += hpRecovery;
            if (playerHP >= 6)
            {
                playerHP = 5;
            }
            GameObject hpDelete = GameObject.Find("HpDelete");
            hpDelete.GetComponent<Hp>().RecoveryHp();
            collision.gameObject.SetActive(false);
        }

    }

    // 敵の弾に当たった際の処理
    public void TakeDamage(int damage)
    {
        playerHP -= damage;

        if (playerHP <= 0)
        {
            // Animation再生
            animator.Play("GameOver");
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
        // 1秒間待つ
        yield return new WaitForSeconds(1);

        // GameOver画面に遷移
        SceneManager.LoadScene("GameOverScene");
    }

}
