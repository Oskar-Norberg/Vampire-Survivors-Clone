using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<GameObject> enemies = new List<GameObject>();
    
    public void SpawnEnemy(GameObject enemy, Vector2 position)
    {
        GameObject instance = Instantiate(enemy, transform);
        enemies.Add(instance.gameObject);

        instance.transform.localPosition = position;
    }
}
