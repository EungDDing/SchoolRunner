using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBook : ItemBase
{
    public override void Start()
    {
        base.Start();
        SetType(ObjectType.BookCoin);
    }
    public override void ItemGet()
    {
        ScoreManager.Book++;
    }
}
