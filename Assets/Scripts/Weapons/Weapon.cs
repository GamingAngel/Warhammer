using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private Transform shootingPosition;
    [SerializeField] private GameObject bullet;

    [SerializeField] protected int damage;
    [SerializeField] protected float fireRate;
    
    [SerializeField] protected int maxBullets;
    private int currentBullets;

    [SerializeField] protected float reloadTime;
    private bool isReloading;
    private float lastShotTime;

    public void Fire()
    {
        if (currentBullets > 0 && Time.time>lastShotTime+fireRate)
        {
            Instantiate(bullet, shootingPosition.position, shootingPosition.rotation);
            lastShotTime = Time.time;
            currentBullets--;
            print("Shot");
        }
        else if (currentBullets<=0 && !isReloading)
        {
            isReloading = true;
            Invoke(nameof(ReloadWeapon),reloadTime);
        }
    }

    private void ReloadWeapon()
    {
        print("Reload");
       
        currentBullets = maxBullets;
        isReloading = false;
    }

    private void Start()
    {
        currentBullets = maxBullets;
    }




}
