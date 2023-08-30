using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LandPlayer : MonoBehaviour
{
    Rigidbody2D rigid2D;
    float jumpForce = 400.0f;
    float walkForce = 30.0f;
    float maxWalkSpeed = 2.0f;

    public int playerHP = 5;             // プレイヤーのHP
    private Vector2 moveDirection;       // 移動方向
    private Vector3 startPosition;       // スタート位置
    private Rigidbody2D rb2D;
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
    public int bulletRecovery = 5;       // 弾数回復アイテム
    public int hpRecovery = 1;           // HP回復アイテム



    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();

        rb2D = GetComponent<Rigidbody2D>();         // Rigidbody2Dのコンポーネントを取得
        animator = GetComponent<Animator>();        // Animatorのコンポーネントを取得
        audioSource = GetComponent<AudioSource>();  // AudioSourceコンポーネントを取得
        startPosition = transform.position;         // 初期位置を保存
        this.bulletManager = GameObject.Find("RemainingBulletsManagement");     // 残弾の管理
        animator.Play("SkyBsps");   // Animation再生

    }

    // Update is called once per frame
    void Update()
    {
        // ジャンプする
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // 左右移動
        int key = 0;
        if (Input.GetKey(KeyCode.D)) key = 1;
        if (Input.GetKey(KeyCode.A)) key = -1;

        // プレイヤの速度
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // スピード制限
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // 動く方向に応じて反転
        if (key != 0)
        {
            transform.localScale = new Vector3(0.3f, 0.3f, 1);
        }

        // 弾を発射
        if (Input.GetKeyDown(KeyCode.Return) && (bulletNum > 0))
        {
            Shoot();

            bulletNum--;
            this.bulletManager.GetComponent<BulletNum>().Firing();
        }
    }


    // 弾を発射する
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.right * bulletSpeed;  // 弾を右方向に発射
        audioSource.PlayOneShot(shotSE); // 弾を発射したSE
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        // Enemyまたはギミックに当たったときの処理
        if (collision.CompareTag("Enemy") || collision.CompareTag("gimmick") || collision.CompareTag("SkyBoss"))
        {
            audioSource.PlayOneShot(hitSE); // 敵に当たったSE
            playerHP--;     // HPを1減らす

            // HPのUI表示
            GameObject HP = GameObject.Find("Hp");  // Hpスクリプトを取得
            HP.GetComponent<Hp>().DeleteHp();       // HpスクリプトのDeleteHp関数を呼び出し

            // HPが0になったらゲームオーバー
            if (playerHP > 0)
            {
                // HPが1以上なら EnemyTouch アニメーションを再生
                animator.Play("EnemyTouch");
                animator.SetTrigger("PlayEnemyTouch");

                StartCoroutine(AnimationCoroutine());

            }
            if (playerHP <= 0)
            {
                // コルーチンの起動
                StartCoroutine(GameOverCoroutine());
            }
        }

        // 壁に挟まれた時の処理
        if (collision.CompareTag("Wall"))
        {
            // ステージの最初から再開
            transform.position = startPosition;
        }

        // 手に当たった際の処理
        if (collision.CompareTag("Hand"))
        {
            // コルーチンの起動
            StartCoroutine(DelayCoroutine());
        }

        // 残弾回復
        if (collision.CompareTag("bulleRecovery"))
        {
            audioSource.PlayOneShot(recoverySE); // 回復SE
            bulletNum += bulletRecovery;
            this.bulletManager.GetComponent<BulletNum>().Recovery();
            collision.gameObject.SetActive(false);
        }

        // HP回復
        if (collision.CompareTag("HpRecovery"))
        {
            audioSource.PlayOneShot(recoverySE); // 回復SE
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
            // コルーチンの起動
            StartCoroutine(GameOverCoroutine());
        }
    }


    // コルーチンの起動
    IEnumerator AnimationCoroutine()
    {
        // 2秒間待つ
        yield return new WaitForSeconds(2);

        // Animation再生
        animator.Play("SkyBsps");
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
        // Animation再生
        animator.Play("GameOver");

        bulletNum = 0;

        // 2秒間待つ
        yield return new WaitForSeconds(2);

        // GameOver画面に遷移
        SceneManager.LoadScene("GameOverScene");
    }
}
