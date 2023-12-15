using UnityEngine;
using UnityEngine.AI;

public class ProjectileShooter : MonoBehaviour
{
    [Tooltip("weapon so we can bind events")]
    public Weapon weapon;
    [Tooltip("bullet spawn location")]
    public Transform firePoint;

    private void Awake()
    {
        // Check if the GameObject has a NavMeshAgent component
        NavMeshAgent agent = GetComponentInParent<NavMeshAgent>();

        
        // Subscribe to the weapon's trigger pull event
        
        EventSystemDelay obj = gameObject.GetComponent<EventSystemDelay>();
        // If there is no NavMeshAgent, it's likely a player character
        if (agent == null)
        {
            obj.afterDelayEvent.AddListener(ShootProjectile);
        }
        
    }

    public void ShootProjectile()
    {
        //spawn projectile 
        GameObject projectile = Instantiate(weapon.projectilePrefab, firePoint.position, firePoint.rotation);
        Quaternion originalRotation = firePoint.rotation;
        float accuracyRotation = weapon.GetAccuracyRotation();
        accuracyRotation = (accuracyRotation / 2) - accuracyRotation;
        firePoint.transform.Rotate(0, accuracyRotation, 0);
        weapon.spawnMuzzleFlash.Invoke();



        //check for rb component
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb)
        {
            // add velocity to give the bullet extra bang
            rb.velocity = firePoint.forward * weapon.projectileSpeed;
        }
        // Reset fire point rotation
        firePoint.rotation = originalRotation;
    }
}