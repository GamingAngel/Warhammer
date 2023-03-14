using UnityEngine;

public abstract class Troops : MonoBehaviour
{

    [SerializeField]private int maxHealth;
    private int currentHealth;

    [SerializeField] protected float speed;

    protected Rigidbody rb;
    private Weapon weapon;

    protected void Attack()
    {
        weapon.Fire();
    }
    protected abstract void Die();
    protected void TakeDamage(int damage)
    {
        currentHealth-=damage;

        if (currentHealth <= 0) 
        {
            Die();
        } 
    }
    protected void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        weapon = GetComponentInChildren<Weapon>();
    }
}
