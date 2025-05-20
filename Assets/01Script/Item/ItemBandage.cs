using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBandage : ItemBase
{
    public override void ItemGet()
    {
        PlayerController.RecoverHP();
    }    
}
