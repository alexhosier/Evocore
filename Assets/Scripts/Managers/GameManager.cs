using System;
using System.Collections;
using System.Collections.Generic;
using Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        // Variables
        public static GameManager Instance { get; private set; }
        [SerializeField] private GameObject loadingScreen;

        public int wheatAmount, barleyAmount, oatsAmount;
    
        private List<AsyncOperation> scenesLoading = new List<AsyncOperation>();
    
        // Called when the class is loading
        private void Awake()
        {
            // Set the current instance to this
            Instance = this;

            // Load the title screen
            SceneManager.LoadSceneAsync((int) SceneIndexes.Title, LoadSceneMode.Additive);
        }

        // Called before first frame
        private void Start()
        {
            // Fetch the amount of crops stored from last session
            wheatAmount = PlayerPrefs.GetInt("Player_Inventory_Wheat");
            barleyAmount = PlayerPrefs.GetInt("Player_Inventory_Barley");
            oatsAmount = PlayerPrefs.GetInt("Player_Inventory_Oats");
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
                    // Prevent the GameManager class from moving on
                    yield return null;
                }
            }
        
            // Hide the loading screen
            loadingScreen.SetActive(false);
        }

        // Save all players data
        private void OnApplicationQuit()
        {
            // Save players data in PlayerPrefs
            PlayerPrefs.SetInt("Player_Inventory_Wheat", wheatAmount);
            PlayerPrefs.SetInt("Player_Inventory_Barley", barleyAmount);
            PlayerPrefs.SetInt("Player_Inventory_Oats", oatsAmount);
        }
    }
}
