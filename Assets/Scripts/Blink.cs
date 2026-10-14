using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Blink : MonoBehaviour
{
    private List<Renderer> renderers = new List<Renderer>();
    [SerializeField]
    private float blinkInterval = 0.2f;
    private void Awake()
    {
        renderers.AddRange(GetComponentsInChildren<Renderer>());
    }
    private void EnableRenderers(bool isEnabled)
    {
        foreach (var renderer in renderers)
        {
            renderer.enabled = isEnabled;
        }
    }
    public void StartBlink(float duration)
    {
        StartCoroutine(BlinkRoutine(duration));
    }
    private IEnumerator BlinkRoutine(float duration)
    {
        float elapsedTime = 0f;
        bool activateRenderers = true;
        while (elapsedTime < duration)
        {
            EnableRenderers(activateRenderers);
            activateRenderers = !activateRenderers;
            yield return new WaitForSeconds(blinkInterval);
            elapsedTime += blinkInterval;
        }
        EnableRenderers(true);
    }

}
