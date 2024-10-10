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
    [MenuItem("Tools/Set Level Spawns")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<LevelSpawnsTool>("Level Spawns Tool");
    }
}
