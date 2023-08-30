using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Houdai2Shooter : MonoBehaviour
{
    public GameObject bulletPrefab;    // ’e‚ÌPrefab
    public Transform firePoint;        // ’e‚ğ”­Ë‚·‚éˆÊ’u
    public float bulletSpeed = 5.0f;   // ’e‚Ì‘¬“x
    public float fireInterval = 1.0f;  // ”­Ë‚·‚éŠÔ‚ÌŠÔŠu

    private float lastFireTime;        // ÅŒã‚É’e‚ğ”­Ë‚µ‚½ŠÔ

    void Start()
    {
        lastFireTime = -fireInterval; // ‰Šú‰»‚ÉÅ‰‚Ì”­Ë‚ğ‹–‰Â‚·‚é
    }

    void Update()
    {
        // Œo‰ßŠÔ‚ª”­ËŠÔŠu‚ğ’´‚¦‚½‚ç’e‚ğ”­Ë
        if (Time.time - lastFireTime >= fireInterval)
        {
            Shoot();
            lastFireTime = Time.time; // ”­ËŠÔ‚ğXV
        }
    }

    // ’e‚ğ”­Ë‚·‚é
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = Vector2.left * bulletSpeed + Vector2.up * bulletSpeed;  // ’e‚ğ¶ã•ûŒü‚É”­Ë
    }
}
