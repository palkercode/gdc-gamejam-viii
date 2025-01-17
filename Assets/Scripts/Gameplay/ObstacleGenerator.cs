using System;
using System.Collections;
using Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class ObstacleGenerator : MonoBehaviour
    {
        [SerializeField] private bool startGeneratingOnStart;
        
        public Obstacle obstacle;

        public float minPos, maxPos, y;
        public float minTimeBetweenSpawn, maxTimeBetweenSpawn;

        private void Start()
        {
            if (startGeneratingOnStart) StartGenerating();
        }

        public void StartGenerating()
        {
            StartCoroutine(nameof(Generate));
        }

        public void StopGenerating()
        {
            StopAllCoroutines();
        }

        private IEnumerator Generate()
        {
            Instantiate(obstacle, new Vector3(Random.Range(minPos, maxPos), y, 0), Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(minTimeBetweenSpawn, maxTimeBetweenSpawn));
            StartCoroutine(nameof(Generate));
        }
    }
}