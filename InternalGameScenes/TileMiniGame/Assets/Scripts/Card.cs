using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Card : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _frontSide;
    [SerializeField] private int _cardScore;

    private AudioSource _onOpenSound;

    public bool IsTurned => _frontSide.activeSelf;
    public int ScoreValue { get => _cardScore; set => _cardScore = value; }

    private void Awake()
    {
        _onOpenSound = GetComponent<AudioSource>();
    }

    public void SetSprite(Sprite sprite)
    {
        _frontSide.GetComponent<Image>().sprite = sprite; // Use sprite for front face
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!IsTurned)
        {
            Open();
            _onOpenSound.Play();
        }
    }

    public void Open()
    {
        GetComponentInParent<OpenedCardsCollector>().AddCard(transform);
        _frontSide.SetActive(true);
    }

    public void Close()
    {
        _frontSide.SetActive(false);
    }

    public Sprite GetFaceSlotValue()
    {
        return _frontSide.GetComponent<Image>().sprite;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
