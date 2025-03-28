using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemExercise : ItemBase
{
    public override void ItemGet()
    {
        ScoreManager.Exercise++;
        Destroy(gameObject);
    }
}
