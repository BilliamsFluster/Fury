using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    [Tooltip("weapon so we can bind events")]
    public Weapon weapon;
    [Tooltip("bullet spawn location")]
    public Transform firePoint;

    private void Awake()
    {
        // Subscribe to the weapon's trigger pull event
        weapon.onTriggerPull.AddListener(ShootProjectile);
        
    }

    public void ShootProjectile()
    {
        //spawn projectile 
        GameObject projectile = Instantiate(weapon.projectilePrefab, firePoint.position, firePoint.rotation);
        //check for rb component
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb)
        {
            // add velocity to give the bullet extra bang
            rb.velocity = firePoint.forward * weapon.projectileSpeed;
        }
    }
}