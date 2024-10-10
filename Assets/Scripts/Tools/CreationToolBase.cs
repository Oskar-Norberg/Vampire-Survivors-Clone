using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

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
    
    protected void DropdownFromList<T>(string headerLabel, ref int selectionIndex, List<T> list) where T : UnityEngine.Object
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label(headerLabel, EditorStyles.label);
        
        // Convert list of prefab to list of strings for selection in dropdown menu.
        string[] listNames = new string[list.Count];
        
        for (int i = 0; i < list.Count; i++)
        {
            listNames[i] = list[i] != null ? list[i].name : "Missing Data";
        }
        
        selectionIndex = EditorGUILayout.Popup(selectionIndex, listNames);
        GUILayout.EndHorizontal();
    }
    
    protected List<T> LoadAllAssetsInPath<T>(string filter, string path) where T : Object
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
