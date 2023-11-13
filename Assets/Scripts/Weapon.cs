using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Weapon : MonoBehaviour
{
    [Header("Events")]

    // UnityEvents for the observer pattern
    [Tooltip("The event to call other events when invoked.")]
    public UnityEvent onTriggerPull;
    [Tooltip("The event to call other events when invoked.")]
    public UnityEvent onTriggerRelease;

    [Header("Inverse Kinematics")]
    public Transform RHPoint;
    public Transform LHPoint;

    [Header("Accuracy Data")]
    [Range(0f, 100f)]
    public float weaponAccuracy;

    private float maxWeaponAccuracy = 100;
    [Tooltip("This is the max rotation of a projectile from on-target if the weapon has 0 accuracy.")]
    public float maxWeaponAccuracyRotationOffset;



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
        // Check if the GameObject has a NavMeshAgent component
        NavMeshAgent agent = GetComponentInParent<NavMeshAgent>();


        // Trigger mechanism using mouse click
        if (Input.GetMouseButtonDown(0))
        {
            if (agent == null)
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
            // Implement automatic firing logic using fireRate
        }
    }

    public float GetAccuracyRotation() 
    {
        //Find what percent of accuracy our weapon has
        float percentAccuracy = weaponAccuracy / maxWeaponAccuracy;
        //flip it so 100% accuracy is 0 rotation
        percentAccuracy = 1 - percentAccuracy;
        // find the max amt we should rotate based on this accuracy
        float maxRotationOffset = maxWeaponAccuracyRotationOffset * percentAccuracy;
        // choose a random rotation less than  the max
        float accuracyRotationOffset = maxRotationOffset * UnityEngine.Random.value;
        //convert the quaternion we would adjust our rotation of our projectile by
        return accuracyRotationOffset;

    }
}
