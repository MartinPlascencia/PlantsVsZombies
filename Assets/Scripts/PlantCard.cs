using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlantCard : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private int price;
    [SerializeField]
    private TextMeshProUGUI priceText;
    [SerializeField]
    private GameObject plantPrefab;
    [SerializeField]
    private SunManager sunManager;
    [SerializeField]
    private UnityEvent<Transform> onPlantBought;
    private void Awake()
    {
        priceText.text = price.ToString();
    }
    public void TryToBuyPlant()
    {
        if (sunManager.HasEnoughSun(price))
        {
            sunManager.SpendSun(price);
            GameObject plant = PoolManager.Instance.GetObject(plantPrefab, Vector3.zero);
            onPlantBought?.Invoke(plant.transform);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TryToBuyPlant();
    }
}
