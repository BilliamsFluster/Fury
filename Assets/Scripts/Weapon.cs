using UnityEngine;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    // UnityEvents for the observer pattern
    public UnityEvent onTriggerPull;
    public UnityEvent onTriggerRelease;

    // Weapon properties
    [Tooltip("The projectile to be instantiated when the weapon is fired.")]
    public GameObject projectilePrefab;
    [Tooltip("The speed at which the projectile will move.")]
    public float projectileSpeed = 10f;
    [Tooltip("The rate of fire for automatic weapons.")]
    public float fireRate = 10f;
    private bool isShooting = false;

    void Update()
    {
        // Trigger mechanism using mouse click
        if (Input.GetMouseButtonDown(0))
        {
            onTriggerPull.Invoke();
            isShooting = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            onTriggerRelease.Invoke();
            isShooting = false;
        }

        // For automatic firing
        if (isShooting)
        {
            // Implement automatic firing logic here using fireRate
        }
    }
}
