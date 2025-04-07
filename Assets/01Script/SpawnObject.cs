using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject dumbbellPrefab;
    [SerializeField] private GameObject bookPrefab;
    [SerializeField] private GameObject micPrefab;
    [SerializeField] private GameObject gamePrefab;

    private int spawnRate;
    private GameObject obj;
    private void Awake()
    {
        SpawnRandomObject();
    }
    public void SpawnRandomObject()
    {
        spawnRate = Random.Range(1, 1000);

        if (spawnRate < 200)
        {
            obj = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        }
        else if (spawnRate < 400)
        {
            obj = Instantiate(dumbbellPrefab, transform.position, Quaternion.identity);
        }
        else if (spawnRate < 600)
        {
            obj = Instantiate(bookPrefab, transform.position, Quaternion.identity);
        }
        else if (spawnRate < 800)
        {
            obj = Instantiate(micPrefab, transform.position, Quaternion.identity);
        }
        else if (spawnRate < 1000)
        {
            obj = Instantiate(gamePrefab, transform.position, Quaternion.identity);
        }
    }
}
