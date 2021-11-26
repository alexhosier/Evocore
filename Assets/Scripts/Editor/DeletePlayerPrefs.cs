using UnityEditor;
using UnityEngine;

namespace EditorTools
{
    public class DeletePlayerPrefs : EditorWindow
    {
        [MenuItem("Evocore/Reset Player Prefs")]
        private static void ResetPlayerPrefs()
        {
            // Delete all of the player prefs
            PlayerPrefs.DeleteAll();
            PlayerPrefs.Save();
        
            // Send a message
            Debug.Log("<b>Player prefs have been deleted</b>");
        }
    }
}
