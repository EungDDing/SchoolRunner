using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialItemCoin : TutorialItem
{
    public override void ItemGet()
    {
        SoundManager.instance.PlaySFX(SFX_Type.SFX_Coin);
        Debug.Log("호출");
        Destroy(gameObject);
    }
}
