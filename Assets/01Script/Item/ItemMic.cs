using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMic : ItemBase
{
    public override void ItemGet(bool isMain)
    {
        if (isMain)
        {
            ScoreManager.Mic++;
        }
        else
        {
            ScoreManager.Book--;
            ScoreManager.Dumbbell--;
            ScoreManager.Game--;
        }
        Destroy(gameObject);
    }
}
