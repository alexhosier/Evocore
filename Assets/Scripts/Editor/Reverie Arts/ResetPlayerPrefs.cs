using UnityEditor;
using UnityEngine;

namespace Editor.Reverie_Arts
{
    public class ResetPlayerPrefs : EditorWindow
    {
        [MenuItem("Reverie Art Tools/Player Prefs/Reset")]
        private static void ResetPrefs()
        {
            // Delete all of the old data
            PlayerPrefs.DeleteAll();
        
            // Save the new data
            PlayerPrefs.Save();
        
            // Output the change that has been made
            Debug.Log("<b>RAT:</b> Player Prefs have been reset");
        }
    }
}
