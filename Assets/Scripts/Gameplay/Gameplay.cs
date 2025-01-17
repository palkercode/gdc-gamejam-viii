using System.Collections;
using Gameplay.Waves;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class Gameplay : MonoBehaviour
    {
        public uint score;
        public int wavesSurvived;

        [SerializeField] private WaveController _waveController;
        [SerializeField] private TextMeshProUGUI scoreText;
        
        private void Start()
        {
            // TODO: Implement and start intro cutscene
            
            StartCoroutine(nameof(ScoreCoroutine));
            StartCoroutine(nameof(GameplayCoroutine));
        }

        private IEnumerator ScoreCoroutine()
        {
            score++;
            scoreText.text = score.ToString("D6");
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(nameof(ScoreCoroutine));
        }

        private IEnumerator GameplayCoroutine()
        {
            _waveController.StartAppropriateWave(wavesSurvived);
            Debug.Log(_waveController.currentWave.name);
            yield return new WaitForSeconds(_waveController.currentWave.secondsToFinish);
            wavesSurvived++;
            StartCoroutine(nameof(GameplayCoroutine));
        }
    }
}