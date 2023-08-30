using UnityEngine;
 
/// <summary>
/// y”wŒi‚ÌƒRƒ“ƒgƒ[ƒ‹—pƒNƒ‰ƒXz
///     ”wŒi‚Í3–‡AƒJƒƒ‰‚©‚çŒ©Ø‚ê‚½‚ç‰ñ‚è‚Ş
/// </summary>
public class BackGroundController : MonoBehaviour
{

    // ”wŒi‚Ì–‡”
    int spriteCount = 3;
    // ”wŒi‚ª‰ñ‚è‚İ
    float rightOffset = 1.45f;
    float leftOffset = -0.4f;

    Transform bgTfm;
    SpriteRenderer mySpriteRndr;
    float width;

    void Start()
    {
        bgTfm = transform;
        mySpriteRndr = GetComponent<SpriteRenderer>();
        width = mySpriteRndr.bounds.size.x;
    }


    void Update()
    {
        // À•W•ÏŠ·
        Vector3 myViewport = Camera.main.WorldToViewportPoint(bgTfm.position);

        // ”wŒi‚Ì‰ñ‚è‚İ(ƒJƒƒ‰‚ªX²ƒvƒ‰ƒX•ûŒü‚ÉˆÚ“®)
        if (myViewport.x < leftOffset)
        {
            bgTfm.position += Vector3.right * (width * spriteCount);
        }
        // ”wŒi‚Ì‰ñ‚è‚İ(ƒJƒƒ‰‚ªX²ƒ}ƒCƒiƒX•ûŒü‚ÉˆÚ“®)
        else if (myViewport.x > rightOffset)
        {
            bgTfm.position -= Vector3.right * (width * spriteCount);
        }
    }
}