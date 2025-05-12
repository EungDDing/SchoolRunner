using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AlbumUI : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private RectTransform contentTransform;

    [SerializeField] private Image albumInfo;
    [SerializeField] private TextMeshProUGUI infoName;
    [SerializeField] private Image infoImage;

    private List<EndingCard> cards = new List<EndingCard>();
    private EndingCard card;

    private int cardCount;
    private bool isOpenAlbumInfo;

    private void Awake()
    {
        InitCard();   
    }
    private void InitCard()
    {
        isOpenAlbumInfo = false;
        cardCount = 7;
        for (int i = 0; i < cardCount; i++)
        {
            if (Instantiate(cardPrefab, contentTransform).TryGetComponent<EndingCard>(out card))
            {
                cards.Add(card);
            }
        }
    }
    public void RefreshAlbum()
    {
        for (int i = 0; i < cardCount; i++)
        {
            cards[i].DrawEndingCard(i);
            cards[i].OnClickCard -= OpenAlbumInfo;
            cards[i].OnClickCard += OpenAlbumInfo;
        }

        StartCoroutine(SetScrollPosition());
    }

    private IEnumerator SetScrollPosition()
    {
        // wait update layout
        yield return null;
        // update layout by force
        Canvas.ForceUpdateCanvases();
        // config scroll position
        scrollRect.verticalNormalizedPosition = 1f;
    }
    public void OpenAlbumInfo()
    {
        Debug.Log("OpenAlbumInfo");
        isOpenAlbumInfo = !isOpenAlbumInfo;
        if (isOpenAlbumInfo)
        {
            albumInfo.gameObject.LeanScale(Vector3.one, 0.7f).setEase(LeanTweenType.easeInOutElastic);
            if (DataManager.instance.GetEndingData(GameManager.instance.EndingIndex, out EndingData_Entity endingData))
            {
                infoImage.sprite = Resources.Load<Sprite>(endingData.Image);
                infoName.text = endingData.Name;
            }
        }
    }
    public void CloseAlbumInfo()
    {
        isOpenAlbumInfo = !isOpenAlbumInfo;
        albumInfo.gameObject.LeanScale(Vector3.zero, 0.7f).setEase(LeanTweenType.easeInOutElastic);
    }
    public void ReplayEnding()
    {
        GameManager.instance.AsyncLoadNextScene(SceneName.EndingScene);
    }
}
