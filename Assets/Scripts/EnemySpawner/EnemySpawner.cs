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
    [SerializeField] private float enemiesPerSpawn;

    private Transform _playerTransform;

    private void Start()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnEnemies());
    }
    
    // Spawns enemies in a circle around the player
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (_playerTransform == null) yield break;
            
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                Vector2 distanceFromPlayer = new Vector2();

                for (int j = 0; j < 2; j++)
                {
                    distanceFromPlayer[j] = Mathf.Cos(Random.value * Mathf.PI * 2f) * Random.Range(minDistanceFromPlayer, maxDistanceFromPlayer);
                }
            
                GameObject enemy = Instantiate(enemies[0], transform);

                enemy.transform.localPosition = distanceFromPlayer + (Vector2) _playerTransform.position;
            
                yield return new WaitForSeconds(timeBetweenSpawnsMilliseconds / 1000);
            }
        }
    }
}
