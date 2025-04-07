using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBook : ItemBase
{
    public override void ItemGet()
    {
        ScoreManager.Book++;

        Destroy(gameObject);
    }
}
