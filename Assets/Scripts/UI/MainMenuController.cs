using Game;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace UI
{
    public class MainMenuController : MonoBehaviour
    {
        // Variables
        [SerializeField] private GameObject optionsMenu;

        // Before the first frame
        private void Start()
        {
            // Hide the UI
            optionsMenu.SetActive(false);
        }

        // Load the game
        public void StartGame()
        {
            // Call the game to be started
            GameManager.Instance.LoadGame();
        }
        
        // Open options
        public void OpenOptions()
        {
            // TODO Load DATA
            
            // Open UI
            optionsMenu.SetActive(true);
        }
        
        // Close options
        public void CloseOptions()
        {
            // TODO Save DATA
            
            // Close UI
            optionsMenu.SetActive(false);
        }
        
        // Code to exit the game
        public void ExitGame()
        {
            // Quit the application
            Application.Quit(0);
        }
    }
}
