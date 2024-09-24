using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : PausableMonoBehaviour
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

    public void FixedUpdateEnemies()
    {
        foreach (EnemyBase enemy in enemies)
        {
            if (!enemy) continue;
                enemy.PathFind();
        }
    }

    private void RemoveEnemyFromList(EnemyBase enemy)
    {
        enemies.Remove(enemy);
    }

    public override void Pause()
    {
        foreach (EnemyBase enemy in enemies)
        {
            if (!enemy) continue;
            enemy.Pause();
        }
    }

    public override void UnPause()
    {
        foreach (EnemyBase enemy in enemies)
        {
            if (!enemy) continue;
            enemy.UnPause();
        }
    }
}
