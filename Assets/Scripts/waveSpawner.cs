using System;
using UnityEngine;
using System.Collections;

public class waveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public float TimeBetweenWaves = 5f;
    private float countdown = 3f;
    private int waveIndex = 0;
    public Transform spawnPoint;
    private void Update()
    {
        if (countdown<=0f)
        {
            StartCoroutine(spawnWave());
            countdown = TimeBetweenWaves;
        }
        countdown -= Time.deltaTime;
    }

    IEnumerator spawnWave() 
    {
        waveIndex++;
        PlayerStats.Rounds++;
        Debug.Log("Wave incomming!!");
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
    }
}
