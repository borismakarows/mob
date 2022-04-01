using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] bool isLooping;
    [SerializeField] Vector3 spawnOffset;
    [SerializeField] float minBoundZ;
    [SerializeField] float maxBoundZ;

    

    WaveConfigSO currentWave;


    void Start()
    {
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;

                for(int i = 0; i < currentWave.GetPatternPointCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(),
                       currentWave.GetPatternPoint(i).position + spawnOffset,
                       Quaternion.identity,
                       transform);
                }
                
                yield return new WaitForSecondsRealtime(timeBetweenWaves);
            }

        }
        while (isLooping);
    }


}
