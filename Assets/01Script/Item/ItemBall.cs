using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBall : ItemBase
{
    public override void ItemGet()
    {
        PlayerController.ShootBall();
    }

}
