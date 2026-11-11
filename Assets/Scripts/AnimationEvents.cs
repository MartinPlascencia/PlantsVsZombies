using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
public class AnimationEvents : MonoBehaviour
{
    [SerializeField]
    private List<AnimationEventData> animationEvents;
    public void TriggerEvent(string eventName)
    {
        AnimationEventData eventData = animationEvents.Find(e => e.eventName == eventName);
        eventData?.callback.Invoke();
    }
}

[System.Serializable]
public class AnimationEventData
{
    public string eventName;
    public UnityEvent callback;
}
