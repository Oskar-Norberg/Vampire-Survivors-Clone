using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class WaveSpawner : PausableMonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;

    [Serializable]
    public class EnemySpawn
    {
        public GameObject enemy;
        public int weight;
    }
    
    [SerializeField] public List<EnemySpawn> enemiesToSpawn = new List<EnemySpawn>();
    private int totalWeight;
    
    [Header("Spawn Position")]
    [SerializeField] public float minDistanceFromPlayer;
    [SerializeField] public float maxDistanceFromPlayer;
    
    [Header("Spawn Properties")]
    [SerializeField] public float timeBetweenSpawnsMilliseconds;
    [SerializeField] public int enemiesPerSpawn;
    
    [Header("Difficulty Scaling")]
    // Every spawnsPerIncrease spawns increase enemiesPerSpawn by enemiesPerSpawnIncrement
    [SerializeField] public int spawnsPerIncrease;
    [SerializeField] public int enemiesPerSpawnIncrement;

    [SerializeField] private Transform playerTransform;
    private float timeSinceLastSpawn;

    private int spawnCounter;

    private void Start()
    { 
        totalWeight = GetTotalWeight();
    }

    public void FixedUpdate()
    {
        if (IsPaused) return;
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
        Vector2 enemyPosition = distanceFromPlayer + (Vector2) playerTransform.position;

        GameObject enemy = WeightedGetRandomEnemy();

        if (!enemy)
        {
            Debug.LogWarning("Null enemy in WaveSpawner enemies list.\n" +
                             "Did you delete an enemy without removing it from the spawn list?");

        }
        
        enemyManager.SpawnEnemy(enemy, enemyPosition);
    }

    private GameObject WeightedGetRandomEnemy()
    {
        int randomWeight = Random.Range(0, totalWeight);

        // Find the enemy that corresponds to the random weight
        foreach (var enemy in enemiesToSpawn)
        {
            if (randomWeight < enemy.weight)
            {
                return enemy.enemy;
            }
            randomWeight -= enemy.weight;
        }
        
        return null;
    }

    private int GetTotalWeight()
    {
        int weight = 0;
        
        foreach (EnemySpawn enemy in enemiesToSpawn)
        {
            weight += enemy.weight;
        }

        return weight;
    }
}
