using Enums;
using UnityEngine;

namespace Scriptable_Objects
{
    [CreateAssetMenu(fileName = "farmSettings", menuName = "Evocore/Farm Settings")]
    public class FarmSettings : ScriptableObject
    {
        // Growth Settings
        public int minGrowthTime;
        public int maxGrowthTime;
        
        // Harvest Settings
        public int cropMinAmount;
        public int cropMaxAmount;
        
        // Crop Settings
        public CropTypes cropType;
    }
}
