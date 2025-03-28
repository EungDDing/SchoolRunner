using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSing : ItemBase
{
    public override void ItemGet()
    {
        ScoreManager.Sing++;
        Destroy(gameObject);
    }
}
