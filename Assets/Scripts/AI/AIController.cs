using System;
using Interfaces;
using UnityEngine;

namespace AI
{
    public class AIController : MonoBehaviour, IInteractable
    {
        // Variables
        private enum AiStates
        {
            Idle,
            Patrol,
            MoveTo,
            Mine
        }

        private float stateTimer;

        [Header("AI State Settings")]
        [SerializeField] private AiStates aiState;
        [SerializeField] private AiStates defaultState;
        [SerializeField] private float idleTime = 5f;
        [SerializeField] private float patrolTime = 10f;
        [SerializeField] private float moveToBreakTime = 30f;

        [Header("AI Stats")] 
        [SerializeField] [Range(0, 100)] private float aiHealth;
        [SerializeField] [Range(0, 100)] private float aiHunger;

        // Start is called before the first frame update
        private void Start()
        {
            // Set default state
            aiState = defaultState;
        }

        // Update is called once per frame
        private void Update()
        {
            // Increment timer
            stateTimer += Time.deltaTime;
            
            // Switch between functionalities
            switch (aiState)
            {
                // Idle functionality
                case AiStates.Idle:

                    // Check time
                    if (stateTimer >= idleTime)
                    {
                        // Reset timer
                        stateTimer = 0f;

                        // Set the AI to patrol
                        aiState = AiStates.Patrol;
                    }
                    
                    break;
                
                // Patrol functionality
                case AiStates.Patrol:

                    // Check time
                    if (stateTimer >= patrolTime)
                    {
                        // Reset timer
                        stateTimer = 0f;
                        
                        // Set AI to idle
                        aiState = AiStates.Idle;
                    }
                    
                    // TODO Add random position
                    
                    break;
                
                // Move to functionality
                case AiStates.MoveTo:

                    // Check time
                    if (stateTimer >= moveToBreakTime)
                    {
                        // Reset timer
                        stateTimer = 0f;

                        // Set the AI to patrol
                        aiState = AiStates.Patrol;
                    }
                    
                    break;
                
                // Mine functionality
                case AiStates.Mine:

                    break;
                
                // Fallback
                default:

                    // Set to idle
                    aiState = AiStates.Idle;
                    
                    break;
            }
        }

        // IInteractable interface method
        public void Interact()
        {
            // TODO Add interact functionality
            Debug.Log("AI Interacted with");
        }
    }
}
