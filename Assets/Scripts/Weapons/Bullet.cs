using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float bulletSpeed;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(bulletSpeed * transform.forward);
        
        Destroy(gameObject,7);
    }
}
