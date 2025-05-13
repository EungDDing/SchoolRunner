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
        PlayerController.ShootBall();
    }

}
