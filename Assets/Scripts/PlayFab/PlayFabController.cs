using System;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;

namespace PlayFab
{
    public class PlayFabController : MonoBehaviour
    {
        // Variables
        public static PlayFabController Instance { get; private set; }

        private void Awake()
        {
            // Check if an instance exists
            if (Instance != null && Instance != this)
            {
                // Destroy this instance
                Destroy(this.gameObject);
            } else {
                // Set the current instance to this
                Instance = this;
            }
        }

        // Login method
        public void Login()
        {
            // For editor
            #if UNITY_EDITOR

            var editorRequest = new LoginWithCustomIDRequest {CustomId = "EDITOR", CreateAccount = true};
            PlayFabClientAPI.LoginWithCustomID(editorRequest, OnLoginSuccess, OnLoginFailure);

            #endif
            
            // For built versions
            #if UNITY_STANDALONE

            var standaloneRequest = new LoginWithCustomIDRequest {CustomId = PlayerPrefs.GetString("Player_Username"), CreateAccount = true};
            PlayFabClientAPI.LoginWithCustomID(standaloneRequest, OnLoginSuccess, OnLoginFailure);

            #endif
        }

        private void OnLoginSuccess(LoginResult result)
        {
            Debug.Log("Logged in successfully!");
        }

        private void OnLoginFailure(PlayFabError error)
        {
            Debug.Log("Log in failed: " + error.Error);
        }
    }
}
