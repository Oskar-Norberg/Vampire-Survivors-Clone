using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UpgradeCreationTool : EditorWindow
{
    // Start is called before the first frame update
    void Start()
    private string upgradeName;
    private string upgradeDescription;

    private enum Type {MaxHealth, Speed}
    private Type type;
    [MenuItem("Tools/Upgrade Creation")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow<UpgradeCreationTool>("Upgrade Creation Tool");
    }
    
    private void OnGUI()
    {
        GUILayout.Label("Upgrade Creation Tool", EditorStyles.boldLabel);
        
        GUILayout.BeginHorizontal();
        upgradeName = EditorGUILayout.TextField("Name", upgradeName);
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        upgradeDescription = EditorGUILayout.TextField("Description", upgradeDescription);
        GUILayout.EndHorizontal();
        
        GUILayout.BeginHorizontal();
        type = (Type) EditorGUILayout.EnumPopup("Upgrade type", type);
        GUILayout.EndHorizontal();
    }
}
