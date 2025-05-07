using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Unity.VisualScripting;
using UnityEngine;
using static StageManager;

public class StageManager : MonoBehaviour
{

    private Vector3 firstSpawnPos = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 secondSpawnPos = new Vector3(0.0f, 0.0f, 200.0f);
    private Vector3 loopSpawnPos = new Vector3(0.0f, 0.0f, 190.0f);
    private float returnZ = -210.0f;
    private int stageIndex;
    private int stageSpawnCount;
    private Stage[] obj;

    private bool isSpawn;

    private void Awake()
    {
        isSpawn = true;
        obj = new Stage[20];
    }
    public void InitStageManager()
    {
        isSpawn = true;

        stageSpawnCount = 0;
        stageIndex = 0;

        obj[stageSpawnCount] = SpawnStageManager.instance.SpawnStage((int)StageNumber.Stage01, firstSpawnPos);
        obj[stageSpawnCount].InitStage();
        stageSpawnCount = 1;
        obj[stageSpawnCount] = SpawnStageManager.instance.SpawnStage((int)StageNumber.Stage01, secondSpawnPos);
        obj[stageSpawnCount].InitStage();
        stageSpawnCount = 2;
    }

    private void Update()
    {
        SpawnStage();
    }
    public void SpawnStage()
    {
        if (obj[stageIndex] != null && obj[stageIndex].transform.position.z < returnZ && isSpawn)
        {
            StageNumber returnNumber = GetStageCount(stageIndex);
            SpawnStageManager.instance.ReturnStageToPool(obj[stageIndex], (int)returnNumber);

            StageNumber spawnNumber = GetStageCount(stageSpawnCount);
            obj[stageSpawnCount] = SpawnStageManager.instance.SpawnStage((int)spawnNumber, loopSpawnPos);
            obj[stageSpawnCount].InitStage();

            stageSpawnCount++;
            stageIndex++;

            // stop spawn stage
            if (stageSpawnCount == 20)
            { 
                isSpawn = false;
            }
        }
    }
    private StageNumber GetStageCount(int count)
    {
        int index = count / 5;
        int stageCount = count % 5;

        if (stageCount < 4)
        {
            return (StageNumber)index;
        }
        else
        {
            return StageNumber.Bridge;
        }
    }
}
