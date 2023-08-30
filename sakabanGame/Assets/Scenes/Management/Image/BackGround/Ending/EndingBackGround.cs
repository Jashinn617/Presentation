using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingBackGround : MonoBehaviour
{
    public List<Sprite> endingBackgrounds; // エンディングの背景のリスト
    private SpriteRenderer spriteRenderer; // SpriteRendererコンポーネント

    private int currentIndex = 0; // 現在の背景画像のインデックス

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRendererコンポーネントの取得
        StartCoroutine(ChangeBackgroundCoroutine());    // コルーチンの開始
    }

    IEnumerator ChangeBackgroundCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f); // 3秒待機

            currentIndex++; // インデックスをインクリメント

            spriteRenderer.sprite = endingBackgrounds[currentIndex]; // 背景画像の変更
        }
    }
}
