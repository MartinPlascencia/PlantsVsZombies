using UnityEngine;

public class SunManager : MonoBehaviour
{
    [SerializeField]
    private TMPro.TextMeshProUGUI sunText;
    private int currentSun;
    private void Start()
    {
        Initialize();
    }
    public void Initialize()
    {
        currentSun = 0;
        UpdateSunText();
    }
    private void UpdateSunText()
    {
        sunText.text = "x" + currentSun.ToString();
    }
    public void AddSun(int amount)
    {
        currentSun += amount;
        UpdateSunText();
    }
}
