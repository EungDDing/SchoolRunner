using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStudy : ItemBase
{
    public override void ItemGet()
    {
        ScoreManager.Study++;
        Destroy(gameObject);
    }
}
