using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    [HideInInspector]
    public int currentWave = 0;
    public List<SpawnWaveData> waves;
    public List<SpawnPoint> spawnPoints;
}
