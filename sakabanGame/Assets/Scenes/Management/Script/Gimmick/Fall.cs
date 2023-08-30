using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public float speedY = 0.3f;

    void Update()
    {
        // ƒtƒŒ[ƒ€‚²‚Æ‚É—‰º‚³‚¹‚é
        transform.Translate(0, -speedY, 0);
    }

    // stage‚Æ‚Ì“–‚½‚è”»’è‚ğ’²‚×‚é
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // °‚É‚Â‚¢‚½‚çã‚É–ß‚é
        if (collision.CompareTag("stage"))
        {
            transform.Translate(0, speedY, 0);
        }
    }
}
