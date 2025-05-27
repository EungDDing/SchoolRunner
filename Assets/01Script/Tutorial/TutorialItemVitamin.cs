using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialItemVitamin : TutorialItem
{

    public override void ItemGet()
    {
        SoundManager.instance.PlaySFX(SFX_Type.SFX_Item);
        Destroy(gameObject);
        PlayerController.SetInvincible();
    }
}
