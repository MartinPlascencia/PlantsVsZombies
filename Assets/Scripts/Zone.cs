using UnityEngine;

public class Zone : MonoBehaviour
{
    private bool isOccupied = false;
    public bool IsOccupied { 
        get { return isOccupied; } 
        set { isOccupied = value; } 
    }
}
