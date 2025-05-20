using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialItemBall : TutorialItem
{
    public override void ItemGet()
    {
        Destroy(gameObject);
        PlayerController.ShootBall();
    }
}
