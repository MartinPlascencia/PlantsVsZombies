using UnityEngine;
using System.Collections;

public class Sun : MonoBehaviour
{
    [SerializeField]
    private int value;
    public int Value => value;
    [SerializeField]
    private GameObject sunParticles;
    [SerializeField]
    private string collectSound;
    [SerializeField]
    private float duration;
    private Collider assetCollider;
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        assetCollider = GetComponent<Collider>();
    }
    private void OnEnable()
    {
        assetCollider.enabled = true;
        animator.Play("Appear", 0, 0f);
        StartCoroutine(AutoDeactivate());
    }
    public void Collect()
    {
        StopAllCoroutines();
        assetCollider.enabled = false;
        SoundManager.instance.Play(collectSound);
        PoolManager.Instance.GetObject(sunParticles, transform.position);
        gameObject.SetActive(false);
    }

    private IEnumerator AutoDeactivate()
    {
        yield return new WaitForSeconds(duration);
        gameObject.SetActive(false);
    }
}
