using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMic : ItemBase
{
    public override void Start()
    {
        base.Start();
        SetType(ObjectType.MicCoin);
    }
    public override void ItemGet()
    {
        ScoreManager.Mic++;
    }
}
