using UnityEngine;

public class CardsManager : MonoBehaviour
{
    [SerializeField]
    private Transform cardsBar;
    [SerializeField]
    private SunManager sunManager;
    [SerializeField]
    private PlantCreator plantCreator;
    public void SetCards(GameObject[] plantCards)
    {
        foreach (GameObject plantCard in plantCards)
        {
            GameObject cardObject = PoolManager.Instance.GetObject(plantCard, Vector3.zero);
            cardObject.transform.SetParent(cardsBar);
            cardObject.transform.localScale = Vector3.one;
            PlantCard card = cardObject.GetComponent<PlantCard>();
            card.SunManager = sunManager;
            card.onPlantBought += plantCreator.SetObjectToPlace;
        }
    }
}
