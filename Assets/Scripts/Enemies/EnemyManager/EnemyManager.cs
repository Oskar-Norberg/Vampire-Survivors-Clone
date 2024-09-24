using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<EnemyBase> enemies = new List<EnemyBase>();

    private void Start()
    {
        EnemyBase.onEnemyDeath += RemoveEnemyFromList;
    }

    public void SpawnEnemy(GameObject enemy, Vector2 position)
    {
        GameObject instance = Instantiate(enemy, transform);
        instance.transform.position = position;
        enemies.Add(instance.GetComponent<EnemyBase>());
    }

    private void RemoveEnemyFromList(EnemyBase enemy)
    {
        enemies.Remove(enemy);
    }
}
