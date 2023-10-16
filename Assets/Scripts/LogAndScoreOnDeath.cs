using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Health))]
public class LogAndScoreOnDeath : MonoBehaviour
{
    private Health health;
    public int scoreValue = 10;

    private void Awake()
    {
        health = GetComponent<Health>();
       
    }

    public void LogDeathMessage()
    {
        Debug.Log(gameObject.name + " has died!");
    }
}
