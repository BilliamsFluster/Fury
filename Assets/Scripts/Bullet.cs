using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public UnityEvent<GameObject> onBulletHit; // Invoked when the bullet hits something
    private float damage = 20f;
    public void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Health>())
        {
            //onBulletHit.Invoke(collision.gameObject);
            Health health = collision.gameObject.GetComponent<Health>();

            health.TakeDamage(damage);
            Destroy(gameObject); // Destroy the bullet after it hits something

        }
    }
}
