using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemies = new List<GameObject>();
    
    [Header("Spawn Position")]
    [SerializeField] private float minDistanceFromPlayer;
    [SerializeField] private float maxDistanceFromPlayer;
    
    [Header("Spawn Properties")]
    [SerializeField] private float timeBetweenSpawnsMilliseconds;
    [SerializeField] private int enemiesPerSpawn;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(WaveCoroutine());
    }
    
    // Spawns enemies in a circle around the player
    private IEnumerator WaveCoroutine()
    {
        while (true)
        {
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                SpawnRandomEnemy();
            }
            yield return new WaitForSeconds(timeBetweenSpawnsMilliseconds / 1000);
        }
    }

    private void SpawnRandomEnemy()
    {
        if (playerTransform == null) return;

        Vector2 randomDirection = Random.insideUnitCircle.normalized;

        Vector2 distanceFromPlayer = randomDirection * Random.Range(minDistanceFromPlayer, maxDistanceFromPlayer);
        
        GameObject enemy = enemies[(int)Random.Range(0, enemies.Count)];
        
        SpawnEnemy(enemy, distanceFromPlayer);
    }

    private void SpawnEnemy(GameObject enemy, Vector2 position)
    {
        GameObject instance = Instantiate(enemy, transform);

        instance.transform.localPosition = position + (Vector2) playerTransform.position;
    }
}
