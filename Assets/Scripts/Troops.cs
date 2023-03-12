
using UnityEngine;

public abstract class Troops : MonoBehaviour
{

    protected  int MaxHealth { get; }
    protected  int CurrentHealth { set; get; }
    protected  int Speed { get; }



    protected abstract void Attack();
    protected abstract void Die();

    protected void TakeDamage()
    {

    }


}
