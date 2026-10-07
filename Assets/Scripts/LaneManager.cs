using UnityEngine;

public class LaneManager : MonoBehaviour
{
    [SerializeField]
    private Lane[] lanes;
    public Lane GetRandomLane()
    {
        return lanes[Random.Range(0, lanes.Length)];
    }
}
