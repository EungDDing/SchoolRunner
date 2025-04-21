using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public enum StageNumder
{ 
    Stage01 = 0,
    Stage02,
    Stage03,
    Stage04,
}

public class StageManager : MonoBehaviour
{

    private Vector3 firstSpawnPos = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 secondSpawnPos = new Vector3(0.0f, 0.0f, 200.0f);
    private float returnZ = -200.0f;
    private int stageIndex;
    private int stageSpawnCount;
    private Stage[] obj;

    private void Awake()
    {
        obj = new Stage[8];
    }

    public void InitStageManager()
    {
        stageSpawnCount = 0;
        stageIndex = 0;

        obj[stageSpawnCount] = SpawnStageManager.instance.SpawnStage((int)StageNumder.Stage01, firstSpawnPos);
        obj[stageSpawnCount].InitStage();
        stageSpawnCount = 1;
        obj[stageSpawnCount] = SpawnStageManager.instance.SpawnStage((int)StageNumder.Stage01, secondSpawnPos);
        obj[stageSpawnCount].InitStage();
        stageSpawnCount = 2;
    }

    private void Update()
    {
        SpawnStage();
    }
    public void SpawnStage()
    {
        if (obj[stageIndex] != null && obj[stageIndex].transform.position.z < returnZ)
        {
            SpawnStageManager.instance.ReturnStageToPool(obj[stageIndex], (int)StageNumder.Stage01);
            obj[stageSpawnCount] = SpawnStageManager.instance.SpawnStage((int)StageNumder.Stage01, secondSpawnPos);
            stageSpawnCount++;
            stageIndex++;
            Debug.Log("stageCount" + stageSpawnCount);
            Debug.Log("Count" + stageIndex);
        }
    }
}
