using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Health : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    // UnityEvents for the observer pattern
    public UnityEvent<float> onTakeDamage; // Passes damage amount
    public UnityEvent onDeath;

    private void Awake()
    {
        

    }
    private void Start()
    {

        // Subscribe to all bullets' onBulletHit events in the scene
        foreach (var bullet in FindObjectsOfType<Bullet>())
        {
            bullet.onBulletHit.AddListener(HandleBulletHit);
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        onTakeDamage.Invoke(damage);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        currentHealth = 0;
        onDeath.Invoke();
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void HandleBulletHit(GameObject hitObject)
    {
        // Check if the hit object is this object
        if (hitObject == gameObject)
        {
            // You can retrieve the bullet's damage value here if needed
            TakeDamage(10f); // Example damage value
        }
    }
}
