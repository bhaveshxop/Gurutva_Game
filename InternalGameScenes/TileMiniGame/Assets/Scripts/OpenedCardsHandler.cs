using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenedCardsHandler : MonoBehaviour
{
    [SerializeField] private float _closeCountdown;
    [SerializeField] private float _hideCountdown;

    private bool _isCoroutineRunning = false;

    public void InitCardsHandling(List<Transform> cards, bool isPair)
    {
        if (!_isCoroutineRunning)
        {
            StartCoroutine(HandlingCardsCoroutine(cards, isPair));
        }
    }

    private IEnumerator HandlingCardsCoroutine(List<Transform> cards, bool isPair)
    {
        SetHandlingState(true);

        yield return new WaitForSeconds(GetCountdown(isPair));

        if (isPair)
        {
            HidePair(cards);
        }
        else
        {
            CloseCards(cards);
        }

        GetComponent<OpenedCardsCollector>().ClearCardsInfo();
        SetHandlingState(false);
    }

    private void SetHandlingState(bool state)
    {
        _isCoroutineRunning = state;
        GetComponent<Deck>().SetBlockerState(state);
    }

    private float GetCountdown(bool isPairFound)
    {
        return isPairFound ? _hideCountdown : _closeCountdown;
    }

    private void HidePair(List<Transform> cards)
    {
        foreach (Transform child in cards)
        {
            child.GetComponent<Card>().Hide();
            GetComponent<Deck>().UpdateGameScore(child.GetComponent<Card>().ScoreValue);
        }

        GetComponent<Deck>().UpdatePairsCount(-1);
    }

    private void CloseCards(List<Transform> cards)
    {
        foreach (Transform child in cards)
        {
            child.GetComponent<Card>().Close();
        }
    }
}
