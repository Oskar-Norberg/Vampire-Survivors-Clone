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
    
    private void OnGUI()
    {
        
        GUILayout.Label("Enemy Creation Tool", EditorStyles.boldLabel);
        
        GUILayout.BeginHorizontal();
        name = EditorGUILayout.TextField("Name", name);
        GUILayout.EndHorizontal();
        
        EditorGUILayout.Space();
        
        GUILayout.BeginHorizontal();
        health = EditorGUILayout.IntField("Health", health);
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        damage = EditorGUILayout.IntField("Damage", damage);
        GUILayout.EndHorizontal();
        
        EditorGUILayout.Space();
        
        GUILayout.BeginHorizontal();
        tickCooldownMilliseconds = EditorGUILayout.IntField("Attack Cooldown Milliseconds", tickCooldownMilliseconds);
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        invincibilityTimeMilliseconds = EditorGUILayout.IntField("i-Frames time Milliseconds", invincibilityTimeMilliseconds);
        GUILayout.EndHorizontal();
        
        EditorGUILayout.Space();
        
        GUILayout.BeginHorizontal();
        moveSpeed = EditorGUILayout.FloatField("Move Speed", moveSpeed);
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        movementType = (MovementType) EditorGUILayout.EnumPopup("Movement Strategy", movementType);
        GUILayout.EndHorizontal();
        
        EditorGUILayout.Space();

        if (GUILayout.Button("Create Enemy"))
        {
        }
    }
}
