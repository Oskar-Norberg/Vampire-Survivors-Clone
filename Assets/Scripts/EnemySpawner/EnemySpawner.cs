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
        
        Vector2 distanceFromPlayer = new Vector2();

        float randomRadian = Random.Range(0f, Mathf.PI * 2f);
        distanceFromPlayer.x = Mathf.Cos(randomRadian) * Random.Range(minDistanceFromPlayer, maxDistanceFromPlayer);
        distanceFromPlayer.y = Mathf.Sin(randomRadian) * Random.Range(minDistanceFromPlayer, maxDistanceFromPlayer);
            
        GameObject enemy = Instantiate(enemies[(int) Random.Range(0, enemies.Count)], transform);

        enemy.transform.localPosition = distanceFromPlayer + (Vector2) playerTransform.position;
    }
}
