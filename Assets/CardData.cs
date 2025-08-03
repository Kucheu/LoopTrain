using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardData : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private TMPro.TextMeshProUGUI cardText;
    [SerializeField]
    private List<DataToCardType> cardsData;
    [SerializeField]
    private CardManager cardManager;

    public CardType CardType => cardType;
    public WagonData WagonData => wagonData;

    private CardType cardType;
    private WagonData wagonData;

    public void Setup(CardType cardType, WagonData wagonData)
    {
        this.cardType = cardType;
        if (cardType == CardType.wagonCard)
        {
            image.sprite = wagonData.WagonSprite;
            cardText.text = wagonData.WagonName;
        }
        else
        {
            var data = cardsData.Find(x => x.cardType == cardType);
            image.sprite = data.cardSprite;
            cardText.text = data.cardName;
        }
        this.wagonData = wagonData;
        
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        cardManager.SelectCard(CardType, WagonData);
    }

    [Serializable]
    struct DataToCardType
    {
        public CardType cardType;
        public string cardName;
        public Sprite cardSprite;
    }
}

public enum CardType
{
    damageBoost = 0,
    hpBoost = 1,
    hpRegenBoost = 2,
    wagonCard = 3
}
