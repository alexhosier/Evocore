using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SetFloatPlayerPrefs : EditorWindow
{
    // Variables
    private string key;
    private string value;
    
    [MenuItem("Reverie Art Tools/Player Prefs/Set Float")]
    private static void SetFloat()
    {
        // Create the window
        SetFloatPlayerPrefs window = (SetFloatPlayerPrefs) EditorWindow.GetWindow(typeof(SetFloatPlayerPrefs), false, "Set Float");
        
        // Set settings
        window.minSize = new Vector2(300, 400);
        window.maxSize = new Vector2(300, 400);
        window.name = "Set Float";
        
        // Show the window
        window.Show();
    }

    private void OnGUI()
    {
        // Title
        GUILayout.Label("Set Float", EditorStyles.boldLabel);
        
        GUILayout.Space(10);
        
        // Key
        GUILayout.Label("Key");
        key = GUILayout.TextField(key);
        
        GUILayout.Space(5);
        
        // Value
        GUILayout.Label("Value");
        value = GUILayout.TextField(value);
        
        GUILayout.Space(10);
        
        // Submit button
        if (GUILayout.Button("Submit"))
        {
            // Try to parse to float
            if (float.TryParse(value, out var val))
            {
                // Set float in Player Prefs
                PlayerPrefs.SetFloat(key, val);
            
                // Tell the user what happend
                Debug.Log("<b>RAT:</b> " + val + " has been stored under " + key);
            
                // Close the window
                this.Close();
            } else
            {
                Debug.LogError("<b>RAT:</b> Please enter a valid value!");
            }
        }
    }
}
