using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    protected float waitTime;       // protected:åpè≥ÇµÇΩÉNÉâÉXÇ≈égÇ¶ÇÈ

    protected bool stop = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    protected IEnumerator Wait()
    {
        stop = true;

        yield return new WaitForSeconds(waitTime);

        stop= false;
    }
}
