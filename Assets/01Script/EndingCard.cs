using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingCard : MonoBehaviour
{
    [SerializeField] private Image endingImage;
    [SerializeField] private Image unlockImage;

    public void DrawEndingCard(int endingID)
    {
        if (DataManager.instance.GetEndingData(endingID, out EndingData_Entity endingData))
        {
            endingImage.sprite = Resources.Load<Sprite>(endingData.Image);
            
            endingImage.enabled = false;
            unlockImage.enabled = false;

            if (!GameManager.instance.Data.endings[endingID].isUnlocked)
            {
                unlockImage.enabled = true;
            }
            else
            {
                endingImage.enabled = true;
            }
        }
    }
}
