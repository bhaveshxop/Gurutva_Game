using System.Collections.Generic;
using UnityEngine;

public class OpenedCardsCollector : MonoBehaviour
{
    private List<Transform> _openedCards = new List<Transform>();

    public void AddCard(Transform card)
    {
        _openedCards.Add(card);

        if (_openedCards.Count == 2)
        {
            GetComponent<OpenedCardsHandler>().InitCardsHandling(_openedCards, IsPairFound(_openedCards));
        }
    }

    private bool IsPairFound(List<Transform> openedCards)
    {
        Transform[] cardsArray = openedCards.ToArray();

        return cardsArray[0].GetComponent<Card>().GetFaceSlotValue() == cardsArray[1].GetComponent<Card>().GetFaceSlotValue();
    }

    public void ClearCardsInfo()
    {
        _openedCards.Clear();
    }
}
