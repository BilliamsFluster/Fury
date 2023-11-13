using UnityEngine;

[RequireComponent(typeof(Health))]
public class DestroyOnDeath : MonoBehaviour
{
    [SerializeField]
    private float delayDeathTime;
    private Health health;

    private void Awake()
    {
        //health = GetComponent<Health>();
        //health.onDeath.AddListener(DestroySelf);
    }

    public void DestroySelf()
    {
        Debug.Log("Destroying object: " + gameObject.name + ", Instance ID: " + gameObject.GetInstanceID());
        Destroy(gameObject, delayDeathTime);
        //DestroyImmediate(gameObject, true);
    }
}