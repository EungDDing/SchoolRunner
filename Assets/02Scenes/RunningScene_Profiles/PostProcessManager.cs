using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessChanger : MonoBehaviour
{
    [SerializeField] private PostProcessVolume postProcessVolume;
    [SerializeField] private PostProcessProfile[] stageProfiles;

    private int stageCount;
    private void Awake()
    {
        stageCount = 0;
        Stage.OnChangeStageCount += StageCount;
    }
    public void ChangePostProcessProfile()
    {
        if (stageCount % 5 == 0)
        {
            Debug.Log(postProcessVolume.profile);
            postProcessVolume.profile = stageProfiles[4];
        }
        else if (stageCount / 5 == 0)
        {
            Debug.Log(postProcessVolume.profile);
            postProcessVolume.profile = stageProfiles[0];
        }
        else if (stageCount / 5 == 1)
        {
            Debug.Log(postProcessVolume.profile);
            postProcessVolume.profile = stageProfiles[1];
        }
        else if (stageCount / 5 == 2)
        {
            Debug.Log(postProcessVolume.profile);
            postProcessVolume.profile = stageProfiles[2];
        }
        else if (stageCount / 5 == 3)
        {
            Debug.Log(postProcessVolume.profile);
            postProcessVolume.profile = stageProfiles[3];
        }
    }
    private void StageCount()
    {
        Debug.Log(stageCount);
        stageCount++;
        ChangePostProcessProfile();
    }
}