using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{ 
    public void SpawnEnemy(GameObject enemy, Vector2 position)
    {
        GameObject instance = Instantiate(enemy, transform);
        instance.transform.position = position;
    }
}
