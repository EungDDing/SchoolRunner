using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialItemVitamin : TutorialItem
{

    public override void ItemGet()
    {
        Destroy(gameObject);
        PlayerController.SetInvincible();
    }
}
