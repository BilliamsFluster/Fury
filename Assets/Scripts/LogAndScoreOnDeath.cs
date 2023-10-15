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
        health.onDeath.AddListener(LogDeathMessage);
    }

    void LogDeathMessage()
    {
        Debug.Log(gameObject.name + " has died!");
        //ScoreManager.Instance.AddScore(scoreValue); // Assuming you have a ScoreManager singleton
    }
}
