using UnityEngine;

namespace Gameplay.Waves
{
    [CreateAssetMenu(fileName = "Wave", menuName = "Scriptable Objects/Wave")]
    public class Wave : ScriptableObject
    {
        [Header("Main Attributes")]
        public string name;
        
        public int secondsToFinish;
        
        [Header("Snowflakes")]
        public bool enableSnowflakes;
        public float minTimeBetweenSpawn, maxTimeBetweenSpawn;
        
        [Header("Snowflake Warriors")]
        public bool enableSnowflakeWarriors;
        public int snowflakeWarriorsToSpawn;

        [Header("Boss")]
        public bool enableBoss;
        public GameObject boss;
    }    
}
