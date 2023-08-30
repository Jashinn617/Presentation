using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyCameraController : MonoBehaviour
{
    public float moveSpeed = 5.0f;  // カメラの移動速度

   
    // 右方向にカメラを移動
    void Update()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
    }
}
