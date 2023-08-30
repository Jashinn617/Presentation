using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastBossAttackGenerator : MonoBehaviour
{
     public GameObject LastBossAttack1;
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
            GameObject go = Instantiate(LastBossAttack1) as GameObject;
            int py = Random.Range(6, -6);
            go.transform.position = new Vector3(7, py, 0);
        }
    }
}
