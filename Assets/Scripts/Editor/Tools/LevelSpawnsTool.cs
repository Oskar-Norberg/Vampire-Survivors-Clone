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
    [MenuItem("Tools/Set Level Spawns")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<LevelSpawnsTool>("Level Spawns Tool");
    }
    
    private void OnGUI()
    {
        LoadScene();
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
}
