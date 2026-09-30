using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private string enemyTag;
    [SerializeField]
    private GameObject hitParticles;
    [SerializeField]
    private string hitSound;
    private Rigidbody rb;
    private float damage;
    public float Damage { set { damage = value; } }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void OnEnable()
    {
        rb.linearVelocity = transform.forward * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(enemyTag))
        {
            if (other.TryGetComponent<Health>(out Health health))
            {
                health.TakeDamage(damage);
                PoolManager.Instance.GetObject(hitParticles, transform.position);
                SoundManager.instance.Play(hitSound);
                gameObject.SetActive(false);
            }
        }
    }
}
