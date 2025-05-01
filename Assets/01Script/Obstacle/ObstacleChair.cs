using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleChair : Obstacle
{
    public override void SetObstacleType()
    {
        ObstacleType = ObjectType.Chair;
    }

}
