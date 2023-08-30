using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    // ç∂âE
    public bool lr;

    // Start is called before the first frame update
    void Start()
    {
        // SupisNormalÇÃéÊìæ
        GameObject player = GameObject.Find("bspsPrefab");
        lr = player.GetComponent<SpriteRenderer>().flipX;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        if (lr)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-8, 0);
            transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(8, 0);
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }
    }

    // âÊñ äOÇ…èoÇΩÇÁè¡Ç∑
    public void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

}
