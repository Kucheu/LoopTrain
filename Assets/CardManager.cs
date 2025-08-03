using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField]
    private List<WagonData> wagons;
    [SerializeField]
    private List<CardType> otherCards;
    [SerializeField]
    private GameplayManager gameplayManager;
    [SerializeField]
    private GameObject cardsUIObject;
    [SerializeField]
    private List<CardData> cards;
    [SerializeField]
    private TrainWagonsController trainWagonsController;

    public void SelectCard(CardType cardType, WagonData wagonData)
    {
        if (cardType == CardType.wagonCard)
        {
            trainWagonsController.StartAddingWagon(wagonData);
        }
        else
        {
            StatsManager.Instance.SetStat(cardType);
            gameplayManager.ChangeGameState(GameState.Playing);
        }
        cardsUIObject.SetActive(false);
    }

    [ContextMenu("Get Cards")]
    private void GetCardsOptions()
    {
        gameplayManager.ChangeGameState(GameState.Cards);
        int numberOfAllCards = wagons.Count + otherCards.Count;
        SetCards(GetCards(numberOfAllCards));
        cardsUIObject.SetActive(true);
    }

    private void SetCards(List<int> cardsPointers)
    {
        for (int i = 0; i < 3; i++)
        {
            if (cardsPointers[i] < wagons.Count)
            {
                cards[i].Setup(CardType.wagonCard, wagons[cardsPointers[i]]);
            }
            else
            {
                cards[i].Setup(otherCards[cardsPointers[i] - wagons.Count], null);
            }
        }
    }

    private List<int> GetCards(int allCards)
    {
        List<int> cardsPointers = new();
        while (cardsPointers.Count < 3)
        {
            int newCard = UnityEngine.Random.Range(0, allCards);
            if (!cardsPointers.Contains(newCard))
            {
                cardsPointers.Add(newCard);
            }
        }
        return cardsPointers;
    }
}
