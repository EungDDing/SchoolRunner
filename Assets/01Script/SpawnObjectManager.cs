using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectManager : MonoBehaviour
{
    public static SpawnObjectManager instance;

    [SerializeField] private GameObject[] objectPrefabs;
    private Queue<GameObject>[] objectPoolQueue;

    private int poolSize = 10;
    private GameObject obj;

    private void Awake()
    {
        Debug.Log("SpawnObjectManager Awake");

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        objectPoolQueue = new Queue<GameObject>[objectPrefabs.Length];

        for (int i = 0; i < objectPrefabs.Length; i++)
        {
            objectPoolQueue[i] = new Queue<GameObject>();
            Allocate(i);
        }
    }

    private void Allocate(int index)
    {
        for (int i = 0; i < poolSize; i++)
        {
            obj = Instantiate(objectPrefabs[index]);
            objectPoolQueue[index].Enqueue(obj);
            obj.SetActive(false);
        }
    }
    
    private GameObject GetObjectFromPool(int index)
    {
        if (objectPoolQueue[index].Count < 1)
        {
            Allocate(index);
        }

        return objectPoolQueue[index].Dequeue();
    }    

    public void ReturnObjectToPool(GameObject returnObject, int index)
    {
        returnObject.gameObject.SetActive(false);
        objectPoolQueue[index].Enqueue(returnObject);
        Debug.Log("호출됨" + index);
    }
    
    public void SpawnObject(int index, Vector3 spawnPos)
    {
        obj = GetObjectFromPool(index);

        if (obj != null)
        {
            obj.transform.position = spawnPos;
            obj.gameObject.SetActive(true);
        }
    }
}
