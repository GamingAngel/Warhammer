using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private readonly int bulletDestroyTime=2;
    [SerializeField] private int damage;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject bulletHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(bulletSpeed * transform.forward);
        
        Destroy(gameObject, bulletDestroyTime);
    }

    private void OnTriggerEnter(Collider other)
    {    
        print(other.gameObject.name);
        if (other.TryGetComponent(out ITakeDamage doDamage))
        {
            doDamage.TakeDamage(damage);
        }
        GameObject hitEffect = Instantiate(bulletHit, transform.position, Quaternion.identity);
        Destroy(hitEffect, bulletDestroyTime);
        Destroy(gameObject);
    }

}
