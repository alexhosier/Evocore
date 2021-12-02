using Enums;
using Interfaces;
using Scriptable_Objects;
using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    public class FarmManager : MonoBehaviour, IInteractable
    {
        // Variables
        [Header("Farm Settings")] 
        [SerializeField] private FarmStates farmState;
        [SerializeField] private FarmSettings farmSettings;

        private float stateTimer;
        private float readyTime;
        
        // Start is called before the first frame update
        private void Start()
        {
            // Set the default state
            farmState = FarmStates.Cultivated;
            
            // Debug for is the farm is setup or not
            Debug.Log(farmSettings ? "Farm set up with " + farmSettings.cropType : "Farm settings not set");
        }

        // Update is called once per frame
        private void Update()
        {
            // Increment time
            stateTimer += Time.deltaTime;
            
            // Switch between allowed states
            if (farmState == FarmStates.Planted && stateTimer >= readyTime)
            {
                // Set to ready state
                farmState = FarmStates.Ready;
            }
        }

        // Update the visuals for the farm
        private void UpdateVisuals()
        {
            
        }

        // IInteractable method
        public void Interact()
        {
            switch (farmState)
            {
                // When the crop is cultivated
                case FarmStates.Cultivated:

                    // Set a time
                    readyTime = Random.Range(farmSettings.minGrowthTime, farmSettings.maxGrowthTime);
                    
                    // Reset timer
                    stateTimer = 0f;
                    
                    // Set the state
                    farmState = FarmStates.Planted;
                    
                    // Call update visuals
                    UpdateVisuals();
                    
                    break;
                
                // When the crop is ready to be harvested
                case FarmStates.Ready:
                    
                    // Generate the amount of crop to award
                    var amount = Random.Range(farmSettings.cropMinAmount, farmSettings.cropMaxAmount);

                    Debug.Log("Yes should have added: " + amount);
                    
                    // Based on the crop type do
                    switch (farmSettings.cropType)
                    {
                        // Barley
                        case CropTypes.Barley:

                            // Increment the amount of barley based on this
                            GameManager.Instance.barleyAmount += amount;
                            
                            break;
                        
                        // Oats
                        case CropTypes.Oats:

                            // Increment the amount of oats based on this
                            GameManager.Instance.oatsAmount += amount;
                            
                            break;
                        
                        // Wheat
                        case CropTypes.Wheat:

                            // Increment the amount of wheat based on this
                            GameManager.Instance.wheatAmount += amount;
                            
                            break;
                    }
                    
                    // Set to harvested
                    farmState = FarmStates.Harvested;
                    
                    // Call update visuals
                    UpdateVisuals();
                    
                    break;
                
                // When the farm is harvested
                case FarmStates.Harvested:

                    // Set to cultivated
                    farmState = FarmStates.Cultivated;
                    
                    // Call update visuals
                    UpdateVisuals();
                    
                    break;
            }
        }
    }
}
