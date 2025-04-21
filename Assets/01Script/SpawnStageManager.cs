using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SpawnStageManager : MonoBehaviour
{
    public static SpawnStageManager instance;

    [SerializeField] private GameObject[] stagePrefabs;
    private Queue<Stage>[] stagePoolQueue;

    private int poolSize = 2;
    private GameObject obj;
    private Stage stage;

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
        stagePoolQueue = new Queue<Stage>[stagePrefabs.Length];

        for (int i = 0; i < stagePrefabs.Length; i++)
        {
            stagePoolQueue[i] = new Queue<Stage>();
            Allocate(i);
        }
    }
    private void Allocate(int index)
    {
        for (int i = 0; i < poolSize; i++)
        {
            obj = Instantiate(stagePrefabs[index]);
            if (obj.TryGetComponent<Stage>(out stage))
            {
                stagePoolQueue[index].Enqueue(stage);
            }
            obj.SetActive(false);
        }
    }
    private Stage GetStageFromPool(int index)
    {
        if (stagePoolQueue[index].Count < 1)
        {
            {
                Allocate(index);
            } 
        }
        return stagePoolQueue[index].Dequeue();
    }
    public void ReturnStageToPool(Stage returnObject, int index)
    {
        returnObject.gameObject.SetActive(false);
        stagePoolQueue[index].Enqueue(returnObject);
    }
    public Stage SpawnStage(int index, Vector3 spawnPos)
    {
        stage = GetStageFromPool(index);

        if (stage != null)
        {
            stage.transform.position = spawnPos;
            stage.gameObject.SetActive(true);
        }
        return stage;
    }
}
