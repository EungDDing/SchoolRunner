using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrashCan : Obstacle
{
    public override void SetObstacleType()
    {
        ObstacleType = ObjectType.TrashCan;
    }

}
