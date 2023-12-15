using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int currentLevel;
    public List<LevelData> levels;
    public List<Pawn> enemies;
    public AIController aiControllerPrefab;
    public Character player;

    private float waveTimer;
    private float timeToNextWave;
    private bool isWaveInProgress;

    void Start()
    {
        StartNewWave();
    }

    void Update()
    {
        if (isWaveInProgress)
        {
            waveTimer += Time.deltaTime;
            if (waveTimer >= timeToNextWave)
            {
                AdvanceToNextWave();
            }
        }
    }

    private void StartNewWave()
    {
        waveTimer = 0f;
        timeToNextWave = Random.Range(5f, 10f); // Random duration between 5 to 10 seconds for each wave
        isWaveInProgress = true;
        SpawnWave();
    }

    private void AdvanceToNextWave()
    {
        LevelData currentLevelData = levels[currentLevel];
        currentLevelData.currentWave++;

        if (currentLevelData.currentWave >= currentLevelData.waves.Count)
        {
            // Move to the next level or reset if all levels are completed
            currentLevel++;
            if (currentLevel >= levels.Count)
            {
                Debug.Log("All levels completed. Restarting...");
                currentLevel = 0;
            }
            currentLevelData.currentWave = 0;
        }

        StartNewWave(); // Start the next wave
    }

    public void SpawnWave()
    {
        LevelData currentLevelData = levels[currentLevel];
        if (currentLevelData.currentWave >= currentLevelData.waves.Count)
        {
            return; // No more waves to spawn
        }

        SpawnWaveData currentWave = currentLevelData.waves[currentLevelData.currentWave];
        foreach (var spawnData in currentWave.spawns)
        {
            for (int i = 0; i < spawnData.numberOfEnemies; i++)
            {
                Transform spawnPoint = currentLevelData.spawnPoints[Random.Range(0, currentLevelData.spawnPoints.Count)].transform;
                SpawnEnemy(spawnData.enemyPrefab, spawnPoint);
            }
        }
    }

    public void SpawnEnemy(GameObject enemyToSpawn, Transform spawnPoint)
    {
        GameObject newEnemy = Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
        Pawn enemyPawn = newEnemy.GetComponent<Pawn>();
        Health enemyHealth = newEnemy.GetComponent<Health>();

        if (enemyPawn != null && enemyHealth != null)
        {
            enemies.Add(enemyPawn);
            enemyHealth.onDeath.AddListener(() => OnEnemyDeath(enemyPawn));
            if (aiControllerPrefab != null)
            {
                AIController aiController = Instantiate(aiControllerPrefab, newEnemy.transform.position, Quaternion.identity, newEnemy.transform);
                aiController.stoppingDistance = Random.Range(3f, 6f);
                aiController.chaseTarget = player.transform;
                aiController.pawn = enemyPawn;
                aiController.Possess(enemyPawn);
            }
            else
            {
                Debug.LogError("AIController prefab is not assigned in GameManager.");
            }
        }
    }

    public void OnEnemyDeath(Pawn enemy)
    {
        enemies.Remove(enemy);
        RagdollControlls ragdoll = enemy.GetComponent<RagdollControlls>();
        if (ragdoll != null)
        {
            ragdoll.EnableRagdoll();
        }

        Destroy(enemy.gameObject);

        enemies.RemoveAll(e => e == null); // Clean up any null references in the list
        Debug.Log("Enemy removed. Remaining enemies: " + enemies.Count);
    }
}
