using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingSceneManager : MonoBehaviour
{
    [SerializeField] private Image endingImage;

    private void Start()
    {
        int endingIndex = GameManager.instance.EndingIndex;
        DisplayEndingImage(endingIndex);
    }
    private void DisplayEndingImage(int endingIndex)
    {
        if (DataManager.instance.GetEndingData(endingIndex, out EndingData_Entity endingData))
        {
            endingImage.sprite = Resources.Load<Sprite>(endingData.Image);
            Debug.Log(endingData.Script);
        }
    }
}
