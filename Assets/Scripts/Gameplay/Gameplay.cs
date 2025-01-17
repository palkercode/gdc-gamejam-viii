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
            StartCoroutine(nameof(IntroCoroutine));
        }

        private IEnumerator IntroCoroutine()
        {
            yield return new WaitForSeconds(4);
            
            StartCoroutine(nameof(ScoreCoroutine));
        }

        private IEnumerator ScoreCoroutine()
        {
            score++;
            scoreText.text = score.ToString("D6");
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(nameof(ScoreCoroutine));
        }
    }
}