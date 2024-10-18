using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Sprite> _cardSprites; // List of sprites for the cards
    [SerializeField] private GameObject _cardPrefab; // Reference to the card prefab
    [SerializeField] private float _spacing = 1.5f; // Spacing between cards

    // Method to spawn cards in a grid layout
    public void SpawnCards(GameObject cardPrefab, int count)
    {
        List<GameObject> cards = new List<GameObject>();

        // Check if the count is valid and divisible by the number of sprites
        if (count % 2 != 0 || count / 2 != _cardSprites.Count)
        {
            throw new System.ArgumentException("The deck size must be an even number and match twice the number of available sprites.");
        }

        // Ensure each sprite appears exactly twice
        List<Sprite> allCardSprites = new List<Sprite>();
        foreach (Sprite sprite in _cardSprites)
        {
            allCardSprites.Add(sprite); // First occurrence
            allCardSprites.Add(sprite); // Second occurrence
        }

        // Shuffle the cards to randomize the order
        ShuffleCards(allCardSprites);

        // Spawn the cards with the shuffled sprites
        for (int i = 0; i < allCardSprites.Count; i++)
        {
            GameObject card = Instantiate(cardPrefab, transform); // Ensure it is instantiated under the correct parent
            card.GetComponent<Card>().SetSprite(allCardSprites[i]);
            cards.Add(card);
        }

        // Position cards in a grid layout (4x3 for your example)
        int rows = 3;
        int cols = 4;
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                int index = row * cols + col;
                if (index < cards.Count)
                {
                    GameObject card = cards[index];
                    card.transform.SetParent(transform, false); // Parent set to the Spawner GameObject
                    card.transform.localPosition = new Vector3(col * _spacing, row * -_spacing, 0);
                }
            }
        }
    }

    // Utility method to shuffle the list of cards
    private void ShuffleCards<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }
}
