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

    private AIMovement.AIType aiType;
    
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
        LoadXPOrbs();
        
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
        aiType = (AIMovement.AIType)EditorGUILayout.EnumPopup("Movement Strategy", aiType);
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
        enemyData.aiType = aiType;
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

    private void LoadXPOrbs()
    {
        string[] guids = AssetDatabase.FindAssets("t:scriptableobject", new string[] {XP_ORBS_DATA_PATH});

        xpOrbsData = new List<XPOrbData>();
        
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            XPOrbData data = AssetDatabase.LoadAssetAtPath<XPOrbData>(path);
            xpOrbsData.Add(data);
        }
    }
}
