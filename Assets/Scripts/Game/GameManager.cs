using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        // Variables
        public static GameManager Instance { get; private set; }
        [SerializeField] private GameObject loadingScreen;
    
        private List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    
        // Called when the class is loading
        private void Awake()
        {
            // Set the current instance to this
            Instance = this;

            // Load the title screen
            SceneManager.LoadSceneAsync((int) SceneIndexes.Title, LoadSceneMode.Additive);
        }

        // Load the game
        public void LoadGame()
        {
            // Show the loading screen
            loadingScreen.SetActive(true);
        
            // Unload the main menu
            scenesLoading.Add(SceneManager.UnloadSceneAsync((int) SceneIndexes.Title));

            // Load in the game
            scenesLoading.Add(SceneManager.LoadSceneAsync((int) SceneIndexes.Game, LoadSceneMode.Additive));

            // Check the progress
            StartCoroutine(GetSceneProgress());
        }

        // Get scene loading progress
        private IEnumerator GetSceneProgress()
        {
            // Loop through all of the operations
            for (int i = 0; i < scenesLoading.Count; i++)
            {
                // While they aren't complete
                while (!scenesLoading[i].isDone)
                {
                    yield return null;
                }
            }
        
            // Hide the loading screen
            loadingScreen.SetActive(false);
        }
    
    }
}
