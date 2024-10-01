using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyCreationTool : EditorWindow
{
    
    private new string name;

    private int health;
    
    private int damage;
    private int tickCooldownMilliseconds;
    private int invincibilityTimeMilliseconds;
    
    private float moveSpeed;
    
    [MenuItem("Tools/Enemy Creation")]
    public static void ShowWindow()
    {
        EnemyCreationTool window = EditorWindow.GetWindow<EnemyCreationTool>("Enemy Creation Tool");
    }
}
