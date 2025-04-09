using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObjectType
{
    DumbbellCoin = 0,
    BookCoin,
    MicCoin,
    GameCoin,
    Obstacle01,
}

public class SpawnObject : MonoBehaviour
{
    private int spawnRate;
    private GameObject obj;

    private Vector3 obstacleOffset01 = new Vector3(0.0f, 1.85f, 0.0f);
    private void Start()
    {
        Debug.Log($"SpawnObject {gameObject.name} Awake");
        SpawnRandomObject();
    }
    public void SpawnRandomObject()
    {
        spawnRate = Random.Range(1, 1000);
        
        if (spawnRate < 250)
        {
            SpawnObjectManager.instance.SpawnObject((int)ObjectType.Obstacle01, transform.position + obstacleOffset01);
        }
        else if (spawnRate < 400)
        {
            SpawnObjectManager.instance.SpawnObject((int)ObjectType.DumbbellCoin, transform.position);
        }
        else if (spawnRate < 550)
        {
            SpawnObjectManager.instance.SpawnObject((int)ObjectType.BookCoin, transform.position);
        }
        else if (spawnRate < 700)
        {
            SpawnObjectManager.instance.SpawnObject((int)ObjectType.MicCoin, transform.position);
        }
        else if (spawnRate < 850)
        {
            SpawnObjectManager.instance.SpawnObject((int)ObjectType.GameCoin, transform.position);
        }
    }
}
