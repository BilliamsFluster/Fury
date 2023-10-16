using UnityEngine;

[RequireComponent(typeof(Health))]
public class DestroyOnDeath : MonoBehaviour
{
    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
        health.onDeath.AddListener(DestroySelf);
    }

    public void DestroySelf()
    {
        Debug.Log("Enemy is dead");
    }
}