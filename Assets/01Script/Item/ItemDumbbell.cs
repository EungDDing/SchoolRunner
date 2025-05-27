using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDumbbell : ItemBase
{
    public override void Start()
    {
        base.Start();
        SetType(ObjectType.DumbbellCoin);
    }
    public override void ItemGet()
    {
        SoundManager.instance.PlaySFX(SFX_Type.SFX_Coin);
        ScoreManager.Dumbbell++;
    }
}
