using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleVaultingBox : Obstacle
{
    public override void SetObstacleType()
    {
        ObstacleType = ObjectType.VaultingBox;
    }
}
