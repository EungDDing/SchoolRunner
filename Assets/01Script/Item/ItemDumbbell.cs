using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDumbbell : ItemBase
{
    public override void ItemGet()
    {
        ScoreManager.Dumbbell++;
        
        Destroy(gameObject);
    }
}
