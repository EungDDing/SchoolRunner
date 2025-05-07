using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessChanger : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    public PostProcessProfile[] stageProfiles;

    public void ChangePostProcessProfile(int stageIndex)
    {
        if (stageIndex >= 0 && stageIndex < stageProfiles.Length)
        {
            postProcessVolume.profile = stageProfiles[stageIndex];
        }
        else
        {
            Debug.LogWarning("스테이지 인덱스 잘못 들어감!");
        }
    }
}