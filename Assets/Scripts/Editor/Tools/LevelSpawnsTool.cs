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
        SpawnProperties();
        EditorGUILayout.Space();
        DifficultyScaling();
        
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
        }
    }

    private bool IsInValidLevel()
    {
        return waveSpawner != null;
    }

    private void SaveWaveSpawnerProperties()
    {
        EditorSceneManager.SaveScene(SceneManager.GetActiveScene());
        
        waveSpawner = null;
    }

    private void SpawnPosition()
    {
        BoldLabel("Spawn Position");
        FloatField("Min Distance from Player", ref waveSpawner.minDistanceFromPlayer);
        FloatField("Max Distance from Player", ref waveSpawner.maxDistanceFromPlayer);
    }
    
    private void SpawnProperties()
    {
        BoldLabel("Spawn Properties");
        FloatField("Milliseconds between spawns", ref waveSpawner.timeBetweenSpawnsMilliseconds);
        IntField("Enemies per spawn", ref waveSpawner.enemiesPerSpawn);
    }

    private void DifficultyScaling()
    {
        BoldLabel("Difficulty Scaling");
        IntField("Spawns per increase", ref waveSpawner.spawnsPerIncrease);
        IntField("Enemies per increase", ref waveSpawner.enemiesPerSpawnIncrement);
    }

    private void ListEnemies()
    {
        BoldLabel("Enemies to spawn:");
        
        List<WaveSpawner.EnemySpawn> enemiesToRemove = new List<WaveSpawner.EnemySpawn>();

        foreach (WaveSpawner.EnemySpawn enemySpawn in waveSpawner.enemiesToSpawn)
        {
            EditorGUILayout.BeginHorizontal(); 
            ObjectField<GameObject>("Enemy Prefab", ref enemySpawn.enemy);
            IntField("Enemy Spawn Weight", ref enemySpawn.weight);
            if (ButtonField("Remove"))
            {
                enemiesToRemove.Add(enemySpawn);
            }
            EditorGUILayout.EndHorizontal();
        }

        foreach (WaveSpawner.EnemySpawn enemy in enemiesToRemove)
        {
            waveSpawner.enemiesToSpawn.Remove(enemy);
        }
        
        if (ButtonField("Add new Enemy"))
        {
            waveSpawner.enemiesToSpawn.Add(new WaveSpawner.EnemySpawn());
        }
    }
}
