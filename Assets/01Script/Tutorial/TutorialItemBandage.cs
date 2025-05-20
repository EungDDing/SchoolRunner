using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialItemBandage : TutorialItem
{
    public override void ItemGet()
    {
        Destroy(gameObject);
        PlayerController.RecoverHP();
    }
}
