using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public UnityEvent<GameObject> onBulletHit; // Invoked when the bullet hits something
    public GameObject hitPrefab;
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
            if(hitPrefab != null)
            {
                GameObject hit = Instantiate(hitPrefab, collision.transform.position, collision.transform.rotation);
                hit.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f); // Adjust the scale of the hit effect as needed
                Destroy(hit, 0.1f);
            }
            Destroy(gameObject); // Destroy the bullet after it hits something

        }
    }
}
