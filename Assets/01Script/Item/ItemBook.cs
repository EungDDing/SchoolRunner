using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBook : ItemBase
{
    public override void ItemGet(bool isMain)
    {
        if (isMain)
        {
            ScoreManager.Book++;
        }
        else
        {
            ScoreManager.Dumbbell--;
            ScoreManager.Mic--;
            ScoreManager.Game--;
        }
        Destroy(gameObject);
    }
}
