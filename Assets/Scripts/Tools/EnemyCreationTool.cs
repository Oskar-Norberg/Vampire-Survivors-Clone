using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyCreationTool : EditorWindow
{
    private const string ENEMY_FOLDER_PATH = "Assets/Prefabs/Enemies";
    private const string ENEMY_BASE_PATH = ENEMY_FOLDER_PATH + "/" + "EnemyBase.prefab";
    
    private const string ENEMY_DATA_FOLDER_PATH = "Assets/ScriptableObjects/EnemyData";
    
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
            EnemyData enemyData = ScriptableObject.CreateInstance<EnemyData>();

            enemyData.health = health;
            enemyData.damage = damage;
            enemyData.tickCooldownMilliseconds = tickCooldownMilliseconds;
            enemyData.invincibilityTimeMilliseconds = invincibilityTimeMilliseconds;
            enemyData.moveSpeed = moveSpeed;
            
            
            GameObject enemyBase = AssetDatabase.LoadAssetAtPath<GameObject>(ENEMY_BASE_PATH);
            GameObject enemyBaseInstance = PrefabUtility.InstantiatePrefab(enemyBase) as GameObject;
            
            // Save EnemyData and prefab
            GameObject newEnemy = PrefabUtility.SaveAsPrefabAsset(enemyBaseInstance, ENEMY_FOLDER_PATH + "/" + name + ".prefab");
            AssetDatabase.CreateAsset(enemyData, ENEMY_DATA_FOLDER_PATH + "/" + name.Trim(' ').Trim() + ".asset");
        }
        }
    }
}
