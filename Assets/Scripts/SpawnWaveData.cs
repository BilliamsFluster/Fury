using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpawnWaveData
{
   [HideInInspector]
   public int currentSpawn = 0;
   public List<SpawnData> spawns;
}
