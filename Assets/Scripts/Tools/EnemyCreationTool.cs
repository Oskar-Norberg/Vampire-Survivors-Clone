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

    private const string XP_ORBS_DATA_PATH = "Assets/ScriptableObjects/XPOrbs";
    
    private const string ENEMY_AI_MOVEMENT_PATH = "Assets/ScriptableObjects/AIMovement";
    
    private new string name;

    private int health;
    
    private int damage;
    private int tickCooldownMilliseconds;
    private int invincibilityTimeMilliseconds;
    
    private float moveSpeed;

    private List<AIMovement> aiMovements;
    private int aiMovementIndex;
    
    private List<XPOrbData> xpOrbsData;
    private int xpOrbPrefabIndex;

    private bool success = false;
    
    [MenuItem("Tools/Enemy Creation")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<EnemyCreationTool>("Enemy Creation Tool");
    }

    private void OnGUI()
    {
        xpOrbsData = LoadAllAssetsInPath<XPOrbData>("scriptableobject", XP_ORBS_DATA_PATH);
        aiMovements = LoadAllAssetsInPath<AIMovement>("scriptableobject", ENEMY_AI_MOVEMENT_PATH);
        
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
        invincibilityTimeMilliseconds =
            EditorGUILayout.IntField("i-Frames time Milliseconds", invincibilityTimeMilliseconds);
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        GUILayout.BeginHorizontal();
        moveSpeed = EditorGUILayout.FloatField("Move Speed", moveSpeed);
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Enemy AI Movement Strategy", EditorStyles.label);
        
        // Convert list of prefab to list of strings for selection in dropdown menu.
        string[] aiMovementNames = new string[aiMovements.Count];
        
        for (int i = 0; i < aiMovements.Count; i++)
        {
            aiMovementNames[i] = aiMovements[i] != null ? aiMovements[i].name : "Missing Data";
        }
        
        aiMovementIndex = EditorGUILayout.Popup(aiMovementIndex, aiMovementNames);
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        GUILayout.Label("XP Orb to Drop", EditorStyles.label);
        
        // Convert list of prefab to list of strings for selection in dropdown menu.
        string[] xpOrbNames = new string[xpOrbsData.Count];
        
        for (int i = 0; i < xpOrbsData.Count; i++)
        {
            xpOrbNames[i] = xpOrbsData[i] != null ? xpOrbsData[i].name : "Missing Data";
        }
        
        xpOrbPrefabIndex = EditorGUILayout.Popup(xpOrbPrefabIndex, xpOrbNames);
        GUILayout.EndHorizontal();

        EditorGUILayout.Space();

        if (GUILayout.Button("Create Enemy"))
        {
            CreateEnemy();
            success = true;
        }

        if (success)
        {
            EditorGUILayout.Space();
            GUILayout.Label("Enemy Created Successfully!", EditorStyles.boldLabel);
        }
    }

    private void CreateEnemy()
    {
        // Create scriptable Object
        EnemyData enemyData = ScriptableObject.CreateInstance<EnemyData>();

        enemyData.health = health;
        enemyData.damage = damage;
        enemyData.tickCooldownMilliseconds = tickCooldownMilliseconds;
        enemyData.invincibilityTimeMilliseconds = invincibilityTimeMilliseconds;
        enemyData.moveSpeed = moveSpeed;
        enemyData.aiMovement = aiMovements[aiMovementIndex];
        enemyData.xpOrbData = xpOrbsData[xpOrbPrefabIndex];

        string scriptableObjectPath = ENEMY_DATA_FOLDER_PATH + "/" + name.Trim(' ').Trim() + ".asset";
        AssetDatabase.CreateAsset(enemyData, scriptableObjectPath);

        GameObject enemy = AssetDatabase.LoadAssetAtPath<GameObject>(ENEMY_BASE_PATH);
        GameObject enemyInstance = PrefabUtility.InstantiatePrefab(enemy) as GameObject;

        if (enemyInstance.TryGetComponent<EnemyBase>(out EnemyBase enemyBase))
        {
            enemyBase.SetEnemyData(enemyData);
        }

        string prefabVariantPath = ENEMY_FOLDER_PATH + "/" + name.Trim(' ').Trim() + ".prefab";
        PrefabUtility.SaveAsPrefabAsset(enemyInstance, prefabVariantPath);

        AssetDatabase.SaveAssets();
        
        DestroyImmediate(enemyInstance);
    }

    private List<T> LoadAllAssetsInPath<T>(string filter, string path) where T : Object
    {
        string[] guids = AssetDatabase.FindAssets("t:" + filter, new string[] {path});

        List<T> assets = new List<T>();
        
        foreach (string guid in guids)
        {
            string objectPath = AssetDatabase.GUIDToAssetPath(guid);
            Object obj = AssetDatabase.LoadAssetAtPath<T>(objectPath);
            
            assets.Add(obj as T);
        }

        return assets;
    }
}
