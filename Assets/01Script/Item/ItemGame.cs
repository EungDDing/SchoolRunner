using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGame : ItemBase
{
    public override void Start()
    {
        base.Start();
        SetType(ObjectType.GameCoin);
    }
    public override void ItemGet()
    {
        SoundManager.instance.PlaySFX(SFX_Type.SFX_Coin);
        ScoreManager.Game++;
    }
}
