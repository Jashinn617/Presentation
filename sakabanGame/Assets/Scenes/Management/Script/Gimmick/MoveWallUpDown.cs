using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWallUpDown : MonoBehaviour
{
    public float top;               // ã‚Éã‚ª‚é
    public float bottom;            // ‰º‚É‰º‚ª‚é
    public float exchange = -1.0f;  // ã‰º”½“]

    void Start()
    {
        top = gameObject.transform.position.y + 3f;
        bottom = gameObject.transform.position.y - 3f;
    }

    void Update()
    {
        if (gameObject.transform.position.y > top)
        {
            exchange = -0.03f;
        }

        if (gameObject.transform.position.y < bottom)
        {
            exchange = 0.03f;
        }
        gameObject.transform.Translate(0, exchange, 0);
    }
}
