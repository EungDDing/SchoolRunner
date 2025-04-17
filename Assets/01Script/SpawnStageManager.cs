using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SpawnStageManager : MonoBehaviour
{
    public static SpawnStageManager instance;

    [SerializeField] private GameObject[] stagePrefabs;
    private Queue<GameObject>[] stagePoolQueue;

    private int poolSize = 2;
    private GameObject obj;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        stagePoolQueue = new Queue<GameObject>[stagePrefabs.Length];

        for (int i = 0; i < stagePrefabs.Length; i++)
        {
            stagePoolQueue[i] = new Queue<GameObject>();
            Allocate(i);
        }
    }
    private void Allocate(int index)
    {
        for (int i = 0; i < poolSize; i++)
        {
            obj = Instantiate(stagePrefabs[index]);
            stagePoolQueue[index].Enqueue(obj);
            obj.SetActive(false);
        }
    }
    private GameObject GetStageFromPool(int index)
    {
        if (stagePoolQueue[index].Count < 1)
        {
            {
                Allocate(index);
            } 
        }
        return stagePoolQueue[index].Dequeue();
    }
    public void ReturnStageToPool(GameObject returnObject, int index)
    {
        Debug.Log("호출");
        returnObject.gameObject.SetActive(false);
        stagePoolQueue[index].Enqueue(returnObject);
    }
    public GameObject SpawnStage(int index, Vector3 spawnPos)
    {
        obj = GetStageFromPool(index);

        if (obj != null)
        {
            obj.transform.position = spawnPos;
            obj.gameObject.SetActive(true);
        }
        return obj;
    }
}
