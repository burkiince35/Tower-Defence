using System;
using UnityEngine;

public class waveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float TimeBetweenWaves = 5f;
    private float countdown = 3f;
    private int waveNumber = 1; 
    private void Update()
    {
        if (countdown<=0f)
        {
            spawnWave();
            countdown = TimeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    void spawnWave() 
    {
        Debug.Log("Wave incomming!!");
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
        }
        waveNumber++;
    }

    private void SpawnEnemy()
    {
        
    }
}
