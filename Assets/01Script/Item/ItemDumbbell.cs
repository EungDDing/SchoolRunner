using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDumbbell : ItemBase
{
    public override void ItemGet(bool isMain)
    {
        if (isMain)
        {
            ScoreManager.Dumbbell++;
        }
        else
        {
            ScoreManager.Book--;
            ScoreManager.Mic--;
            ScoreManager.Game--;
        }
        Destroy(gameObject);
    }
}
