using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaBossAttack1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // フレームごとに等速で落下させる
        transform.Translate(0, 0.001f, 0);

        // 画面外に出たらオブジェクトを破棄する
        if(transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
