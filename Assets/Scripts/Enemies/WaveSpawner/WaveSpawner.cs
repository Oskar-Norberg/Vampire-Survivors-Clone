using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class WaveSpawner : PausableMonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;
    
    [SerializeField] private List<GameObject> enemiesToSpawn = new List<GameObject>();
    
    [Header("Spawn Position")]
    [SerializeField] private float minDistanceFromPlayer;
    [SerializeField] private float maxDistanceFromPlayer;
    
    [Header("Spawn Properties")]
    [SerializeField] private float timeBetweenSpawnsMilliseconds;
    [SerializeField] private int enemiesPerSpawn;
    
    [Header("Difficulty Scaling")]
    // Every spawnsPerIncrease spawns increase enemiesPerSpawn by enemiesPerSpawnIncrement
    [SerializeField] private int spawnsPerIncrease;
    [SerializeField] private int enemiesPerSpawnIncrement;

    private Transform playerTransform;
    private float timeSinceLastSpawn;

    private int spawnCounter;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void FixedUpdate()
    {
        if (isPaused) return;
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= timeBetweenSpawnsMilliseconds / 1000)
        {
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                SpawnRandomEnemy();
            }

            spawnCounter++;

            if (spawnCounter >= spawnsPerIncrease)
            {
                spawnCounter = 0;
                enemiesPerSpawn += enemiesPerSpawnIncrement;
            }

            timeSinceLastSpawn = 0.0f;
        }
    }

    private void SpawnRandomEnemy()
    {
        if (playerTransform == null) return;

        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        Vector2 distanceFromPlayer = randomDirection * Random.Range(minDistanceFromPlayer, maxDistanceFromPlayer);
        
        GameObject enemy = enemiesToSpawn[(int)Random.Range(0, enemiesToSpawn.Count)];
        
        Vector2 enemyPosition = distanceFromPlayer + (Vector2) playerTransform.position;
        
        enemyManager.SpawnEnemy(enemy, enemyPosition);
    }
}
