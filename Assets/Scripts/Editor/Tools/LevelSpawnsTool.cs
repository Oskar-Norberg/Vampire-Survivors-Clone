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

    // Spawn Position
    private float minDistanceFromPlayer, maxDistanceFromPlayer;
    
    
    // EnemySpawn
    private List<WaveSpawner.EnemySpawn> enemiesToSpawn;
    
    [MenuItem("Tools/Set Level Spawns")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<LevelSpawnsTool>("Level Spawns Tool");
    }
    
    private void OnGUI()
    {
        BoldLabel("Select Level Spawn Properties");
        FindWaveSpawner();
        if (!IsInValidLevel())
        {
            EditorGUILayout.HelpBox("Change scene to a valid Level.", MessageType.Error);
            return;
        }
        
        EditorGUILayout.Space();
        SpawnPosition();
        EditorGUILayout.Space();

        
        ListEnemies();
        
        if (ButtonField("Apply changes"))
        {
            SaveWaveSpawnerProperties();
        }
    }

    private void FindWaveSpawner()
    {
        if (waveSpawner) return;
        
        GameObject waveSpawnerObject = GameObject.FindWithTag("WaveSpawner");

        if (!waveSpawnerObject) return;
        
        if (waveSpawnerObject.TryGetComponent<WaveSpawner>(out WaveSpawner rootWaveSpawner))
        {
            waveSpawner = rootWaveSpawner;
            CopyWaveSpawnerProperties();
        }
    }

    private bool IsInValidLevel()
    {
        return waveSpawner != null;
    }

    private void CopyWaveSpawnerProperties()
    {
        minDistanceFromPlayer = waveSpawner.GetMinDistanceFromPlayer();
        maxDistanceFromPlayer = waveSpawner.GetMaxDistanceFromPlayer();
    }

    private void SaveWaveSpawnerProperties()
    {
        waveSpawner.SetMinDistanceFromPlayer(minDistanceFromPlayer);
        waveSpawner.SetMaxDistanceFromPlayer(maxDistanceFromPlayer);
        waveSpawner.SetEnemiesToSpawn(enemiesToSpawn);
        EditorSceneManager.SaveScene(SceneManager.GetActiveScene());
        
        waveSpawner = null;
    }

    private void SpawnPosition()
    {
        BoldLabel("Spawn Position");
        FloatField("Min Distance from Player", ref minDistanceFromPlayer);
        FloatField("Max Distance from Player", ref maxDistanceFromPlayer);
    }
    
    private void ListEnemies()
    {
        BoldLabel("Enemies to spawn:");
        
        enemiesToSpawn = waveSpawner.GetEnemiesToSpawn();

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
        }
    }
}
