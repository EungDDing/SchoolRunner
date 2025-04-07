using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGame : ItemBase
{
    public override void ItemGet()
    {
        ScoreManager.Game++;

        Destroy(gameObject);
    }
}
