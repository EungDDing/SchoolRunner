using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGame : ItemBase
{
    public override void ItemGet(bool isMain)
    {
        if (isMain)
        {
            ScoreManager.Game++;
        }
        else
        {
            ScoreManager.Book--;
            ScoreManager.Dumbbell--;
            ScoreManager.Mic--;
        }
        Destroy(gameObject);
    }
}
