using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GroupObjects : EditorWindow
{
    // Variables
    private string groupName;
    
    [MenuItem("Reverie Art Tools/Game Objects/Group")]
    private static void GroupObject()
    {
        // Fetch window
        GroupObjects window = (GroupObjects) EditorWindow.GetWindow(typeof(GroupObjects), false, "Group Objects");

        // Set settings
        window.minSize = new Vector2(300, 400);
        window.maxSize = new Vector2(300, 400);
        
        // Show window
        window.Show();
    }

    private void OnGUI()
    {
        // Title
        GUILayout.Label("Group Objects", EditorStyles.boldLabel);
        
        GUILayout.Space(10);
        
        // Group Name
        GUILayout.Label("Group Name");
        groupName = GUILayout.TextField(groupName);
        
        // Group button
        if (GUILayout.Button("Group"))
        {
            // Check if they have inputted nothing
            if (groupName == null)
            {
                // Tell the user what they have done wrong
                ShowNotification(new GUIContent("Please enter a name for the group"));
            } else {
                // Check if they have nothing selected
                if (Selection.gameObjects.Length == 0)
                {
                    // Tell the user what is wrong
                    ShowNotification(new GUIContent("Please select items in the scene view"));
                } else {
                    // Check if the object exists
                    if (GameObject.Find(groupName)) {
                        var parent = GameObject.Find(groupName);
                        
                        // Set the parent of the selected objects to the new object
                        foreach (var objectToParent in Selection.gameObjects)
                        {
                            // Set the parent
                            objectToParent.transform.SetParent(parent.transform);
                        }
                    } else {
                        // Make a new a GameObject that will become the parent
                        var parent = new GameObject(groupName);

                        // Set the parent of the selected objects to the new object
                        foreach (var objectToParent in Selection.gameObjects) {
                            // Set the parent
                            objectToParent.transform.SetParent(parent.transform);
                        }
                    }
                }
            }
        }
    }
}
