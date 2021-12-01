using UnityEditor;
using UnityEngine;

namespace Editor.Reverie_Arts
{
    public class SetStringPlayerPrefs : EditorWindow
    {
        // Variables
        private string key;
        private string value;

        [MenuItem("Reverie Art Tools/Player Prefs/Set String")]
        private static void SetStringPref()
        {
            // Init the window
            SetStringPlayerPrefs window = (SetStringPlayerPrefs) EditorWindow.GetWindow(typeof(SetStringPlayerPrefs), false, "Set String");
            
            // Set the window settings
            window.minSize = new Vector2(300, 400);
            window.maxSize = new Vector2(300, 400);
            window.name = "Set String";
            
            // Show the window
            window.Show();
        }

        private void OnGUI()
        {
            // Title
            GUILayout.Label("Set String", EditorStyles.boldLabel);
            
            // Space 10 pixels
            GUILayout.Space(10);
            
            // Key input fields
            GUILayout.Label("Key");
            key = GUILayout.TextField(key);
            
            GUILayout.Space(5);
            
            // Text field for the value
            GUILayout.Label("Value");
            value = GUILayout.TextField(value);
            
            // Generate 10 pixels of space
            GUILayout.Space(10);

            // If the button is pressed
            if (GUILayout.Button("Submit"))
            {
                // Store the data in the player prefs
                PlayerPrefs.SetString(key, value);
                
                // Tell the user that the function has been executed
                Debug.Log("<b>RAT:</b> " + value + " has been stored under " + key);
                
                // Close the menu
                this.Close();
            }
        }
    }
}
