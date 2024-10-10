using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// Class to make common EditorWindow functions easier to perform.
public abstract class CreationToolBase : EditorWindow
{
    protected void BoldLabel(string text)
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(text, EditorStyles.boldLabel);
        GUILayout.EndHorizontal();
    }

    protected void TextField(string labelText, ref string text)
    {
        GUILayout.BeginHorizontal();
        text = EditorGUILayout.TextField(labelText, text);
        GUILayout.EndHorizontal();
    }

    protected void IntField(string labelText, ref int num)
    {
        GUILayout.BeginHorizontal();
        num = EditorGUILayout.IntField(labelText, num);
        GUILayout.EndHorizontal();
    }

    protected void FloatField(string labelText, ref float num)
    {
        GUILayout.BeginHorizontal();
        num = EditorGUILayout.FloatField(labelText, num);
        GUILayout.EndHorizontal();
    }

    protected bool ButtonField(string labelText)
    {
        return GUILayout.Button(labelText);
    }

    protected void EnumPopup<T>(string labelText, ref T value) where T : Enum
    {
        GUILayout.BeginHorizontal();
        value = (T)EditorGUILayout.EnumPopup(labelText, value);
        GUILayout.EndHorizontal();
    }
    
    protected void ObjectDropdown<T>(string labelText, ref T objectReference) where T : UnityEngine.Object
    {
        GUILayout.BeginHorizontal();
        objectReference = (T)EditorGUILayout.ObjectField(labelText, objectReference, typeof(T), true);
        GUILayout.EndHorizontal();
    }
    
    protected void DropdownFromList<T>(string headerLabel, ref int selectionIndex, List<T> list) where T : UnityEngine.Object
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(headerLabel, EditorStyles.label);
        
        // Convert list of prefab to list of strings for selection in dropdown menu.
        string[] listNames = new string[list.Count];
        
        for (int i = 0; i < list.Count; i++)
        {
            listNames[i] = list[i] ? list[i].name : "Missing Data";
        }
        
        selectionIndex = EditorGUILayout.Popup(selectionIndex, listNames);
        GUILayout.EndHorizontal();
    }
    
    protected List<T> LoadAllAssetsInPath<T>(string filter, string path) where T : UnityEngine.Object
    {
        string[] guids = AssetDatabase.FindAssets("t:" + filter, new string[] {path});

        List<T> assets = new List<T>();
        
        foreach (string guid in guids)
        {
            string objectPath = AssetDatabase.GUIDToAssetPath(guid);
            UnityEngine.Object obj = AssetDatabase.LoadAssetAtPath<T>(objectPath);
            
            assets.Add(obj as T);
        }

        return assets;
    }
    
    protected List<string> FindAllAssetsInPath(string filter, string path)
    {
        string[] guids = AssetDatabase.FindAssets("t:" + filter, new string[] {path});

        List<string> paths = new List<string>();
        
        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            paths.Add(assetPath);
        }

        return paths;
    }
}
