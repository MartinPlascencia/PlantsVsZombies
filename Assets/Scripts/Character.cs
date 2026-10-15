using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Blink))]
[RequireComponent(typeof(Health))]
public class Character : MonoBehaviour
{
    protected Health health;
    protected Collider characterCollider;
    private Blink blink;
    [SerializeField]
    protected Animator characterAnimator;
    [SerializeField]
    protected float initialRotationY = 0f;
    [SerializeField]
    private float blinkDuration = 3f;
    protected virtual void Awake()
    {
        health = GetComponent<Health>();
        characterCollider = GetComponent<Collider>();
        blink = GetComponent<Blink>();
    }
    protected virtual void OnEnable()
    {
        transform.rotation = Quaternion.Euler(0f, initialRotationY, 0f);
        characterCollider.enabled = false;
        health.Initialize();
        Initialize();
    }
    public virtual void Initialize()
    {
        characterCollider.enabled = true;
    }
    public virtual void Die()
    {
        StopAllCoroutines();
        characterCollider.enabled = false;
        StartCoroutine(DieCoroutine());
    }
    private IEnumerator DieCoroutine()
    {
        characterAnimator.Play("Death", 0, 0f);
        yield return characterAnimator.WaitForCurrentAnimation();
        blink.StartBlink(blinkDuration);
        yield return new WaitForSeconds(blinkDuration);
        gameObject.SetActive(false);
    }
}
