using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealthUI : MonoBehaviour
{
    public Slider healthSlider;

    private Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
        health.onTakeDamage.AddListener(UpdateHealthUI);
    }

    private void Start()
    {
        healthSlider.maxValue = health.maxHealth;
        healthSlider.value = health.currentHealth;
    }

    void UpdateHealthUI(float damage)
    {
        healthSlider.value = health.currentHealth;
    }
}
