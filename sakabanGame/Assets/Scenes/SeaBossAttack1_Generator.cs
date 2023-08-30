using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaBossAttack1_Generator : MonoBehaviour
{
    public GameObject BossAttack1;
    float span = 0.9f;
    float delta = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go = Instantiate(BossAttack1) as GameObject;
            int px = Random.Range(-8, 0);
            go.transform.position = new Vector3(px, 7, 0);
        }
    }
}
