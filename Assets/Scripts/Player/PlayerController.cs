using System;
using Interfaces;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        // Variables
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float rotateSpeed = 50f;
        [SerializeField] private Vector3 focusOffset;

        private PlayerInputs playerInputs;
        private GameObject selectedObject;

        #region PlayerInputs
        // Called when the instance is being loaded
        private void Awake()
        {
            // Create a new PlayerInputs class
            playerInputs = new PlayerInputs();

            // Bind events to functions
            playerInputs.Player.Interact.started += Interact_Performed;
            playerInputs.Player.Focus.started += Focus_Performed;
        }

        // When the instance is enabled
        private void OnEnable()
        {
            // Enabled the player inputs
            playerInputs.Enable();
        }

        // When the instance is disabled
        private void OnDisable()
        {
            // Disable the player inputs
            playerInputs.Disable();
        }

        #endregion

        // Update is called once per frame
        private void Update()
        {
            // Fetch the player's input
            var moveForward = playerInputs.Player.MoveForward.ReadValue<float>();
            var moveRight = playerInputs.Player.MoveRight.ReadValue<float>();
            var rotate = playerInputs.Player.Rotate.ReadValue<float>();
            
            // Move the player based on input
            transform.Translate(Vector3.forward * (Time.deltaTime * moveSpeed * moveForward));
            transform.Translate(Vector3.right * (Time.deltaTime * moveSpeed * moveRight));
            transform.Rotate(Vector3.down * (Time.deltaTime * rotateSpeed * rotate));
        }
        
        // When the player presses interact
        private void Interact_Performed(InputAction.CallbackContext obj)
        {
            var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            // Send out the Raycast
            if (Physics.Raycast(ray, out var hit))
            {
                // Set the selected object to the object just hit
                selectedObject = hit.collider.gameObject;
                
                // Call the interact function
                hit.collider.gameObject.GetComponent<IInteractable>().Interact();
            }
        }

        // When the player presses focus
        private void Focus_Performed(InputAction.CallbackContext obj)
        {
            // Check if there is a selected object
            if (selectedObject != null)
            {
                // Move the camera to the selected object with the offset
                transform.position = selectedObject.transform.position + focusOffset;
            }
        }
    }
}