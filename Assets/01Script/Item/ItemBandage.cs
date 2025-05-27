using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBandage : ItemBase
{
    public override void ItemGet()
    {
        SoundManager.instance.PlaySFX(SFX_Type.SFX_Item);
        PlayerController.RecoverHP();
    }    
}
