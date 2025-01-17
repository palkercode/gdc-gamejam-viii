using System;
using System.Collections;
using System.Collections.Generic;
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

        public void StartWave(Wave wave)
        {
            currentWave = wave;
            
            if (wave.enableSnowflakes)
            {
                snowflake.minTimeBetweenSpawn = wave.minTimeBetweenSpawn;
                snowflake.maxTimeBetweenSpawn = wave.maxTimeBetweenSpawn;

                snowflake.obstacle.minHorizontalSpeed = wave.minHorizontalSpeed;
                snowflake.obstacle.maxHorizontalSpeed = wave.maxHorizontalSpeed;
            
                snowflake.StartGenerating();
            }

            if (wave.enableSnowflakeWarriors)
            {
                List<GameObject> warriors = new List<GameObject>();
            
                for (int i = 0; i < wave.snowflakeWarriorsToSpawn; i++)
                {
                    warriors.Add(Instantiate(snowflakeWarrior, new Vector3(
                            player.position.x + 5 + i,
                            player.position.y + 5 + i), 
                        Quaternion.identity));
                }
            }
        }

        public void StopWave(Wave wave)
        {
            snowflake.StopGenerating();

            foreach (var warrior in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                warrior.GetComponent<SnowflakeWarrior>().Die();
            }
        }
    }
}