using UnityEngine;
using System.Collections.Generic;

public class CardsManager : MonoBehaviour
{
    [SerializeField]
    private Transform cardsBar;
    private List<PlantCard> cards = new List<PlantCard>();
    private void Awake()
    {
        foreach (Transform child in cardsBar)
        {
            cards.Add(child.GetComponent<PlantCard>());
        }
    }
    public void SetCards(PlantCardType[] plantCards)
    {
        foreach (PlantCard card in cards)
        {
            for (int i = 0; i < plantCards.Length; i++)
            {
                if (plantCards[i] == card.PlantCardType)
                {
                    card.gameObject.SetActive(true);
                    break;
                }
                if (i == plantCards.Length - 1)
                {
                    card.gameObject.SetActive(false);
                }
            }
        }
    }
}
