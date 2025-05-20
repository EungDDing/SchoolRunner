using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialItemCoin : TutorialItem
{
    public override void ItemGet()
    {
        Debug.Log("호출");
        Destroy(gameObject);
    }
}
