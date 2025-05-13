using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessChanger : MonoBehaviour
{
    [SerializeField] private PostProcessVolume postProcessVolume;
    [SerializeField] private PostProcessProfile[] stageProfiles;

    private int stageCount;
    private void Awake()
    {
        Stage.OnChangeStageCount += StageCount;
    }
    public void ChangePostProcessProfile()
    {
        if (stageCount % 5 == 0)
        {
            Debug.Log("post process Bridge");
            postProcessVolume.profile = stageProfiles[4];
        }
        else if (stageCount / 5 == 0)
        {
            Debug.Log("post process 01");
            postProcessVolume.profile = stageProfiles[0];
        }
        else if (stageCount / 5 == 1)
        {
            Debug.Log("post process 02");
            postProcessVolume.profile = stageProfiles[1];
        }
        else if (stageCount / 5 == 2)
        {
            Debug.Log("post process 03");
            postProcessVolume.profile = stageProfiles[2];
        }
        else if (stageCount / 5 == 3)
        {
            Debug.Log("post process 04");
            postProcessVolume.profile = stageProfiles[3];
        }
        else
        {
            Debug.LogWarning("스테이지 인덱스 잘못 들어감!");
        }
    }
    private void StageCount()
    {
        stageCount++;
        ChangePostProcessProfile();
    }
}