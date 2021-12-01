using UnityEditor;
using UnityEngine;

namespace Editor.Reverie_Arts
{
    public class ReplaceObjects : EditorWindow
    {
        // Variables
        private Object toReplace;
        
        [MenuItem("Reverie Art Tools/Game Objects/Replace")]
        private static void ReplaceObject()
        {
            // Get the window
            ReplaceObjects window = (ReplaceObjects) EditorWindow.GetWindow(typeof(ReplaceObjects), false, "Replace Objects");
            
            // Set the settings
            window.minSize = new Vector2(300, 400);
            window.maxSize = new Vector2(300, 400);

            // Show the window
            window.Show();
        }

        private void OnGUI()
        {
            // Title
            GUILayout.Label("Replace Objects", EditorStyles.boldLabel);
            
            GUILayout.Space(10);

            // Object to replace with
            GUILayout.Label("Replacement Object");
            toReplace = (GameObject)EditorGUILayout.ObjectField(toReplace, typeof(Object), true);
            
            GUILayout.Space(10);

            // Button
            if (GUILayout.Button("Replace"))
            {
                // Check if the replacement object isn't set
                if (toReplace == null)
                {
                    // User feedback
                    ShowNotification(new GUIContent("No replacement object selected!"));
                } else
                {
                    // Check if there are any objects selected
                    if (Selection.gameObjects.Length == 0)
                    {
                        // User feedback
                        ShowNotification(new GUIContent("No selected objects in scene!"));
                    }
                    else
                    {
                        // For telling the user how many was replaced
                        var length = Selection.gameObjects.Length;
                        
                        // Loop through all of the objects
                        foreach (var itemToReplace in Selection.gameObjects)
                        {
                            // Spawn replacement object
                            var item = Instantiate(toReplace, itemToReplace.transform.position, itemToReplace.transform.rotation);
                            
                            // Destroy the old object
                            DestroyImmediate(itemToReplace);
                        }
                        
                        // Tell the user what has happend
                        Debug.Log("<b>RAT:</b> Replace " + length + " objects with " + toReplace.name);
                    }
                }
            }
        }
    }
}
