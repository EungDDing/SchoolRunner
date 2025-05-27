using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBall : ItemBase
{
    public override void Start()
    {
        base.Start();
        SetType(ObjectType.Ball);
    }
    public override void ItemGet()
    {
        SoundManager.instance.PlaySFX(SFX_Type.SFX_Item);
        PlayerController.ShootBall();
    }

}
