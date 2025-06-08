using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    DumbbellCoin = 0,
    BookCoin,
    MicCoin,
    GameCoin,
    TrashCan,
    Desk,
    Chair,
    VaultingBox,
    BookShelf,
    Bench,
    Vitamin,
    Bandage,
    Ball
}

public enum ObjectPosition
{
    Ground,
    Air
}

public class SpawnObject : MonoBehaviour
{
    private int spawnRate;

    private ObjectPosition objectPos;

    private bool isInit = false;
    private Vector3 obstacleOffset01 = new Vector3(0.0f, 1.7f, 0.0f);
    public void Awake()
    {
        if (transform.parent.name == "GroundSpawnPos")
        {
            objectPos = ObjectPosition.Ground;
        }
        else if (transform.parent.name == "AirSpawnPos")
        {
            objectPos = ObjectPosition.Air;
        }   
    }
    private void OnEnable()
    {
        if (!isInit)
        {
            isInit = true;
            return;
        }    
        SpawnRandomObject();
    }
    public void SpawnRandomObject()
    {
        spawnRate = Random.Range(1, 1000);
        
        if (objectPos == ObjectPosition.Ground)
        {
            if (spawnRate < 50)
            {
                SpawnObjectManager.instance.SpawnObject((int)ObjectType.TrashCan, transform.position + obstacleOffset01);
            }
            else if (spawnRate < 100)
            {
                SpawnObjectManager.instance.SpawnObject((int)ObjectType.Desk, transform.position);
            }
            else if (spawnRate < 150)
            {
                SpawnObjectManager.instance.SpawnObject((int)ObjectType.Chair, transform.position);
            }
            else if (spawnRate < 200)
            {
                SpawnObjectManager.instance.SpawnObject((int)ObjectType.VaultingBox, transform.position);
            }
            else if (spawnRate < 230)
            {
                SpawnObjectManager.instance.SpawnObject((int)ObjectType.BookShelf, transform.position);
            }
            else if (spawnRate < 260)
            {
                SpawnObjectManager.instance.SpawnObject((int)ObjectType.Bench, transform.position);
            }
            else if (spawnRate < 310)
            {
                SpawnObjectManager.instance.SpawnObject((int)ObjectType.DumbbellCoin, transform.position);
            }
            else if (spawnRate < 360)
            {
                SpawnObjectManager.instance.SpawnObject((int)ObjectType.BookCoin, transform.position);
            }
            else if (spawnRate < 410)
            {
                SpawnObjectManager.instance.SpawnObject((int)ObjectType.MicCoin, transform.position);
            }
            else if (spawnRate < 460)
            {
                SpawnObjectManager.instance.SpawnObject((int)ObjectType.GameCoin, transform.position);
            }
            else if (spawnRate < 465)
            {
                SpawnObjectManager.instance.SpawnObject((int)ObjectType.Vitamin, transform.position);
            }
            else if (spawnRate < 470)
            {
                SpawnObjectManager.instance.SpawnObject((int)ObjectType.Bandage, transform.position);
            }
            else if (spawnRate < 475)
            {
                SpawnObjectManager.instance.SpawnObject((int)ObjectType.Ball, transform.position);
            }
        }
        else if (objectPos == ObjectPosition.Air)
        {
            if (spawnRate < 50)
            {
                SpawnObjectManager.instance.SpawnObject((int)ObjectType.DumbbellCoin, transform.position);
            }
            else if (spawnRate < 100)
            {
                SpawnObjectManager.instance.SpawnObject((int)ObjectType.BookCoin, transform.position);
            }
            else if (spawnRate < 150)
            {
                SpawnObjectManager.instance.SpawnObject((int)ObjectType.MicCoin, transform.position);
            }
            else if (spawnRate < 200)
            {
                SpawnObjectManager.instance.SpawnObject((int)ObjectType.GameCoin, transform.position);
            }
        }
    }
}
