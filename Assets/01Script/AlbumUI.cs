using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlbumUI : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private RectTransform contentTransform;

    private List<EndingCard> cards = new List<EndingCard>();
    private EndingCard card;

    private int cardCount;

    private void Awake()
    {
        InitCard();   
    }
    private void InitCard()
    {
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
            GameManager.instance.Data.endings[i].isUnlocked = true;
            cards[i].DrawEndingCard(i);
        }
    }
}
