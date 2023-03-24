using UnityEngine;

public abstract class Troops : MonoBehaviour, ITakeDamage
{

    [SerializeField]private int maxHealth;
    private int currentHealth;

    [SerializeField] protected float speed;

    protected Rigidbody rb;
    private Weapon weapon;

    protected void Attack() => weapon.Fire();
    protected virtual void Die() => Destroy(gameObject);


    public void TakeDamage(int damage)
    {     
        currentHealth-=damage;
        if (currentHealth <= 0) 
        {
            Die();
        } 
    }

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        weapon = GetComponentInChildren<Weapon>();
    }
}
