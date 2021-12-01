using UnityEditor;
using UnityEngine;

namespace Editor.Reverie_Arts
{
    public class SetIntPlayerPrefs : EditorWindow
    {
        // Variables
        private string key;
        private string value;
    
        [MenuItem("Reverie Art Tools/Player Prefs/Set Int")]
        private static void SetIntPref()
        {
            // Create the window
            SetIntPlayerPrefs window = (SetIntPlayerPrefs) EditorWindow.GetWindow(typeof(SetIntPlayerPrefs), false, "Set Int");

            // Set the window settings
            window.minSize = new Vector2(300, 400);
            window.maxSize = new Vector2(300, 400);
            window.name = "Set Int";

            // Show the window to the user
            window.Show();
        }

        private void OnGUI()
        {
            // Title
            GUILayout.Label("Set Int", EditorStyles.boldLabel);
        
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
                if (int.TryParse(value, out var val))
                {
                    // Set the settings
                    PlayerPrefs.SetInt(key, val);
            
                    // Tell the user what has been executed
                    Debug.Log("<b>RAT:</b> " + val + " has been stored under " + key);
            
                    // Close the menu
                    this.Close();
                } else
                {
                    Debug.LogError("<b>RAT:</b> Please enter a valid value!");
                }
            }
        }
    }
}
