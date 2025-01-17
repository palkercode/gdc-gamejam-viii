using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Waves
{
    public class WaveController : MonoBehaviour
    {
        public Wave currentWave;
        
        [SerializeField] private Gameplay _gameplay;

        [SerializeField] private ObstacleGenerator snowflake;
        [SerializeField] private GameObject snowflakeWarrior;

        [SerializeField] private Transform player;

        [Header("Waves")] 
        [SerializeField] private Wave mildSnowfall;
        [SerializeField] private Wave snowstorm;
        [SerializeField] private Wave frost;

        public void StartAppropriateWave(int wavesSurvived)
        {
            switch (wavesSurvived)
            {
                case 0:
                    StartWave(frost);
                    break;
                case 1 or 2:
                    int rand = Random.Range(0, 2);
                    if (rand == 0) StartWave(mildSnowfall);
                    if (rand == 1) StartWave(snowstorm);
                    if (rand == 2) StartWave(frost);
                    break;
                case 3:
                    StartWave(frost);
                    break;
            }
        }

        public void StartWave(Wave wave)
        {
            currentWave = wave;
            
            if (wave.enableSnowflakes)
            {
                snowflake.minTimeBetweenSpawn = wave.minTimeBetweenSpawn;
                snowflake.maxTimeBetweenSpawn = wave.maxTimeBetweenSpawn;
                snowflake.StartGenerating();
            }

            if (wave.enableSnowflakeWarriors)
            {
                for (int i = 0; i < wave.snowflakeWarriorsToSpawn; i++)
                {
                    Instantiate(snowflakeWarrior, new Vector3(
                        player.position.x + 5 + i,
                        player.position.y + 5 + i), 
                        Quaternion.identity);
                }
            }
        }
    }
}