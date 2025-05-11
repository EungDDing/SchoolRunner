using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVitamin : ItemBase
{
    public override void Start()
    {
        base.Start();
        SetType(ObjectType.Vitamin);
    }
    public override void ItemGet()
    {
        PlayerController.SetInvincible();
    }
}
