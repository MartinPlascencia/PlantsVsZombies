using UnityEngine;

public class Lane : MonoBehaviour
{
    [SerializeField]
    private Transform[] zones;
    public Transform[] Zones => zones;
    [SerializeField]
    private Transform laneStart;
    public Transform LaneStart => laneStart;
}
