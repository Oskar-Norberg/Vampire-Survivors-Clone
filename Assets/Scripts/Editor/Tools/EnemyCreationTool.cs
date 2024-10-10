using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class EnemyCreationTool : CreationToolBase
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

        BoldLabel("Enemy Creation Tool");

        TextField("Name", ref name);

        EditorGUILayout.Space();

        IntField("Health", ref health);
        IntField("Damage", ref damage);
        
        EditorGUILayout.Space();
        
        IntField("Attack Cooldown Milliseconds", ref tickCooldownMilliseconds);
        IntField("i-Frames time Milliseconds", ref invincibilityTimeMilliseconds);
        
        EditorGUILayout.Space();
        
        FloatField("Move Speed", ref moveSpeed);
        
        DropdownFromList("Enemy AI Movement Strategy", ref aiMovementIndex, aiMovements);
        
        EditorGUILayout.Space();
        
        DropdownFromList("XP Orb to Drop", ref xpOrbPrefabIndex, xpOrbsData);

        EditorGUILayout.Space();

        if (ButtonField("Create Enemy"))
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
}
