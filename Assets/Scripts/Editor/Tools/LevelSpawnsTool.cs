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
    private const string LEVEL_SCENE_PATH = "Assets/Scenes/Levels";
    
    private List<string> levelPaths = new List<string>();
    private int levelSelectionIndex = 0;
    
    private Scene currentScene;
    private int currentLevelIndex = 0;
    private WaveSpawner waveSpawner;
    
    [MenuItem("Tools/Set Level Spawns")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<LevelSpawnsTool>("Level Spawns Tool");
    }
    
    private void OnGUI()
    {
        LoadScene();
        if (!currentScene.isLoaded) return;
        FindWaveSpawner();
        ListEnemies();

    }

    private void LoadScene()
    {
        levelPaths = FindAllAssetsInPath("scene", LEVEL_SCENE_PATH);
        
        BoldLabel("Select Level Spawns");

        DropdownFromStringList("Select Level", ref levelSelectionIndex, levelPaths);

        if (!currentScene.isLoaded || levelSelectionIndex != currentLevelIndex)
        {
            currentScene = EditorSceneManager.OpenScene(levelPaths[levelSelectionIndex]);
        }
    }

    private void FindWaveSpawner()
    {
        GameObject waveSpawnerObject = GameObject.FindWithTag("WaveSpawner");

        if (waveSpawnerObject.TryGetComponent<WaveSpawner>(out WaveSpawner rootWaveSpawner))
        {
            waveSpawner = rootWaveSpawner;
        }
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
}
