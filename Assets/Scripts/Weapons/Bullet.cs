using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private int bulletDestroyTime=7;
    [SerializeField] private int damage;
    [SerializeField] private float bulletSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(bulletSpeed * transform.forward);
        
        Destroy(gameObject, bulletDestroyTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<ITakeDamage>().TakeDamage(damage);
        Destroy(gameObject);
    }

}
