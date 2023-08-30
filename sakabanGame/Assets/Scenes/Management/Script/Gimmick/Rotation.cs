using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float swingAngle = 30.0f; // —h‚ê‚éŠp“x
    public float swingSpeed = 1.0f;  // —h‚ê‚é‘¬“x

    private float initialRotation;   // ‰Šú‚Ì‰ñ“]Šp“x


    void Start()
    {
        initialRotation = transform.eulerAngles.z;   // Œ»İ‚Ìz²‚ÌŠp“x‚ğæ“¾ 
    }


    void Update()
    {
       float rotationZ = initialRotation + Mathf.Sin(Time.time * swingSpeed) * swingAngle;
       transform.eulerAngles = new Vector3(0, 0, rotationZ);
    }
   
}
