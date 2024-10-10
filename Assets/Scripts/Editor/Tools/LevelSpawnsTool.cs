using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSpawnsTool : CreationToolBase
{
    private WaveSpawner waveSpawner;
    
    [MenuItem("Tools/Set Level Spawns")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<LevelSpawnsTool>("Level Spawns Tool");
    }
    
    private void OnGUI()
    {
        FindWaveSpawner();
        if (!IsInValidLevel())
        {
            EditorGUILayout.HelpBox("Change scene to a valid Level.", MessageType.Error);
            return;
        }
        ListEnemies();
    }

    private void FindWaveSpawner()
    {
        GameObject waveSpawnerObject = GameObject.FindWithTag("WaveSpawner");

        if (!waveSpawnerObject) return;
        
        if (waveSpawnerObject.TryGetComponent<WaveSpawner>(out WaveSpawner rootWaveSpawner))
        {
            waveSpawner = rootWaveSpawner;
        }
    }

    private bool IsInValidLevel()
    {
        return waveSpawner != null;
    }

    private void ListEnemies()
    {
        List<WaveSpawner.EnemySpawn> enemiesToSpawn = waveSpawner.GetEnemiesToSpawn();

        List<WaveSpawner.EnemySpawn> enemiesToRemove = new List<WaveSpawner.EnemySpawn>();

        foreach (WaveSpawner.EnemySpawn enemySpawn in enemiesToSpawn)
        {
            EditorGUILayout.BeginHorizontal(); 
            ObjectDropdown<GameObject>("Enemy Prefab", ref enemySpawn.enemy);
            IntField("Enemy Spawn Weight", ref enemySpawn.weight);
            if (ButtonField("Remove"))
            {
                enemiesToRemove.Add(enemySpawn);
            }
            EditorGUILayout.EndHorizontal();
        }

        foreach (WaveSpawner.EnemySpawn enemy in enemiesToRemove)
        {
            enemiesToSpawn.Remove(enemy);
        }
        
        if (ButtonField("Add new Enemy"))
        {
            enemiesToSpawn.Add(new WaveSpawner.EnemySpawn());
            waveSpawner.SetEnemiesToSpawn(enemiesToSpawn);
        }
        if (ButtonField("Apply changes"))
        {
            waveSpawner.SetEnemiesToSpawn(enemiesToSpawn);
            EditorSceneManager.SaveScene(SceneManager.GetActiveScene());
        }

    }
}
