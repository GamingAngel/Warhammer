using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private Transform shootingPosition;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject muzzleParticle;

    [SerializeField] private float fireRate;
    
    [SerializeField] private int maxBullets;
    private int currentBullets;

    [SerializeField] private float reloadTime;
    private bool isReloading;
    private float lastShotTime;

    public void Fire()
    {
        if (currentBullets > 0 && Time.time>lastShotTime+fireRate)
        {
            Instantiate(bullet, shootingPosition.position, shootingPosition.rotation);
            GameObject particle = Instantiate(muzzleParticle, shootingPosition.position, shootingPosition.rotation);
            Destroy(particle ,1f);
            lastShotTime = Time.time;
            currentBullets--;        
        }
        else if (currentBullets<=0 && !isReloading)
        {
            isReloading = true;
            Invoke(nameof(ReloadWeapon),reloadTime);
        }
    }

    private void ReloadWeapon()
    {      
        currentBullets = maxBullets;
        isReloading = false;
    }

    private void Start()
    {
        currentBullets = maxBullets;
    }




}
