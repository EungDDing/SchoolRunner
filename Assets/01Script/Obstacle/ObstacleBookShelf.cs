using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleBookShelf : Obstacle
{
    public override void SetObstacleType()
    {
        ObstacleType = ObjectType.BookShelf;
    }

}
