using PlayFab;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

namespace UI
{
    public class MainMenuController : MonoBehaviour
    {
        // Variables
        [Header("Main Screen References")] 
        [SerializeField] private TMP_Text usernameText;
        
        [Header("Username References")]
        [SerializeField] private GameObject usernamePanel;
        [SerializeField] private TMP_InputField usernameInput;
        
        // Start is called before the first frame update
        void Start()
        {
            #if UNITY_EDITOR

            // Set the username text
            usernameText.text = "EDITOR";

            // Hide the username panel
            usernamePanel.SetActive(false);
            
            // Login
            PlayFabController.Instance.Login();

            #endif
            
            #if UNITY_STANDALONE
            
            // Check if the user has chosen a name
            if (PlayerPrefs.HasKey("Player_Username"))
            {
                // Set the username text
                usernameText.text = PlayerPrefs.GetString("Player_Username");
                
                // Hide the username panel
                usernamePanel.SetActive(false);
                
                // Login
                PlayFabController.Instance.Login();
            }
            
            #endif
        }

        // Submit username
        public void SubmitUsername()
        {
            // Generate player's name
            var playerName = usernameInput.text + "#" + RandomNumber() + RandomNumber() + RandomNumber() + RandomNumber();
            
            // Set the player's name
            PlayerPrefs.SetString("Player_Username", playerName);
            
            // Set the player's name on the UI
            usernameText.text = playerName;
            
            // Hide the UI panel
            usernamePanel.SetActive(false);
            
            // Login
            PlayFabController.Instance.Login();
        }

        // TODO Loading screen
        
        // Code to exit the game
        public void ExitGame()
        {
            // Quit the application
            Application.Quit(0);
        }
        
        // Generate a random number
        private static int RandomNumber()
        {
            // Return a random int
            return Random.Range(1, 10);
        }
    }
}
