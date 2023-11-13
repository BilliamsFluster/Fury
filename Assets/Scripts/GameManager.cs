using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int currentLevel;
    public List<LevelData> levels;
    public List<Pawn> enemies;
    public AIController aiControllerPrefab; // Reference to the AIController prefab

    public Character player;

    void Start()
    {
        // Initialize the first wave
        SpawnWave();
    }

    void Update()
    {
        // Check if all enemies are defeated to spawn the next wave
        if (enemies.Count == 0 && levels[currentLevel].currentWave < levels[currentLevel].waves.Count)
        {
            SpawnWave();
        }
    }

    public void SpawnWave()
    {
        LevelData currentLevelData = levels[currentLevel];
        if (currentLevelData.currentWave >= currentLevelData.waves.Count)
        {
            // Handle the scenario when all waves are completed
            return;
        }

        SpawnWaveData currentWave = currentLevelData.waves[currentLevelData.currentWave];
        foreach (var spawnData in currentWave.spawns)
        {
            for (int i = 0; i < spawnData.numberOfEnemies; i++)
            {
                // Randomly select a spawn point from the level's spawn points
                Transform spawnPoint = currentLevelData.spawnPoints[Random.Range(0, currentLevelData.spawnPoints.Count)].transform;
                SpawnEnemy(spawnData.enemyPrefab, spawnPoint);
            }
        }

        // Move to the next wave
        currentLevelData.currentWave++;
    }

    public void SpawnEnemy(GameObject enemyToSpawn, Transform spawnPoint)
    {
        GameObject newEnemy = Instantiate(enemyToSpawn, spawnPoint.position, spawnPoint.rotation);
        Pawn enemyPawn = newEnemy.GetComponent<Pawn>();
        Health enemyHealth = newEnemy.GetComponent<Health>();

        if (enemyPawn != null && enemyHealth != null)
        {
            enemies.Add(enemyPawn);
            enemyHealth.onDeathBackup.AddListener(() => OnEnemyDeath(enemyPawn));
            

            // Instantiate and configure AIController
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
        enemy.GetComponent<RagdollControlls>().EnableRagdoll();
        enemies.Remove(enemy);
        
    }
    
}
