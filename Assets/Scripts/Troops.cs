using UnityEngine;

public abstract class Troops : MonoBehaviour
{

    protected  int MaxHealth { get; }
    protected  int CurrentHealth { set; get; }

    [SerializeField] protected float speed;

    protected Rigidbody rb;
    protected Weapon weapon;

    protected abstract void Attack();
    protected abstract void Die();
    protected void TakeDamage()
    {

    }

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        weapon = GetComponentInChildren<Weapon>();
    }
}
