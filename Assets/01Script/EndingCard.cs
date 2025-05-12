using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndingCard : MonoBehaviour
{
    [SerializeField] private Image endingImage;
    [SerializeField] private Image unlockImage;

    private int id;

    public delegate void ClickCard();
    public ClickCard OnClickCard;
    public void DrawEndingCard(int endingID)
    {
        id = endingID;

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

    public void ClickEndingCard()
    {
        if (GameManager.instance.Data.endings[id].isUnlocked)
        {
            Debug.Log("ending ID : " + id);
            GameManager.instance.EndingIndex = id;
            OnClickCard?.Invoke();
        }    
    }
}
