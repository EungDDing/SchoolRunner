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
    private int count;
    private int stageCount;
    private GameObject[] obj;

    private void Awake()
    {
        obj = new GameObject[3];
    }

    public void InitStage()
    {
        stageCount = 0;
        count = 0;

        obj[stageCount] = SpawnStageManager.instance.SpawnStage((int)StageNumder.Stage01, firstSpawnPos);
        stageCount = 1;
        obj[stageCount] = SpawnStageManager.instance.SpawnStage((int)StageNumder.Stage01, secondSpawnPos);
        stageCount = 2;
    }

    private void Update()
    {
        SpawnStage();
    }
    public void SpawnStage()
    {
        if (obj[count] != null && obj[count].transform.position.z < returnZ)
        {
            SpawnStageManager.instance.ReturnStageToPool(obj[count], (int)StageNumder.Stage01);
            obj[stageCount] = SpawnStageManager.instance.SpawnStage((int)StageNumder.Stage01, secondSpawnPos);
            stageCount++;
            count++;
            Debug.Log("stageCount" + stageCount);
            Debug.Log("Count" + count);
        }
    }

}
