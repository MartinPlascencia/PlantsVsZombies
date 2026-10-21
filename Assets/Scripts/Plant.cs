using UnityEngine;

public class Plant : Character
{
    private Zone zone;
    public void SetZone(Zone newZone)
    {
        zone = newZone;
        zone.IsOccupied = true;
    }
    public void RemoveZone()
    {
        if (zone != null)
        {
            zone.IsOccupied = false;
            zone = null;
        }
    }
}
