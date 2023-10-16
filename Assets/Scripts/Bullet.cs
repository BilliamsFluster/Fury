using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public UnityEvent<GameObject> onBulletHit; // Invoked when the bullet hits something

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Health>())
        {
            onBulletHit.Invoke(collision.gameObject);
            Destroy(gameObject); // Destroy the bullet after it hits something

        }
    }
}
