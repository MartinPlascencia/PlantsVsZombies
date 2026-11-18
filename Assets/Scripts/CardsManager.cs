using UnityEngine;
using System.Collections.Generic;

public class CardsManager : MonoBehaviour
{
    [SerializeField]
    private Transform cardsBar;
    private List<GameObject> cards = new List<GameObject>();
    private void Awake()
    {
        foreach (Transform child in cardsBar)
        {
            cards.Add(child.gameObject);
        }
    }
    public void SetCards(PlantCardData[] plantCards)
    {
        foreach (GameObject card in cards)
        {
            for (int i = 0; i < plantCards.Length; i++)
            {
                if (plantCards[i].cardPrefab.name == card.name)
                {
                    card.SetActive(true);
                    break;
                }
                if (i == plantCards.Length - 1)
                {
                    card.SetActive(false);
                }
            }
        }
    }
}
