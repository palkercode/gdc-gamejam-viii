using System;
using System.Collections;
using System.Collections.Generic;
using Gameplay.Waves;
using UnityEngine;

namespace Gameplay
{
    public class MusicManager : MonoBehaviour
    {
        [SerializeField] private float currentSecond;
        
        [SerializeField] private AudioSource source;
        public List<Music> queue;

        [SerializeField] private BackgroundManager backgroundManager;
        [SerializeField] private WaveController waveController;

        private void Start()
        {
            StartCoroutine(nameof(MusicCoroutine));
            StartCoroutine(nameof(EventsCoroutine));
        }

        private void Update()
        {
            currentSecond += Time.deltaTime;
            //Debug.Log(source.time);
        }

        private IEnumerator MusicCoroutine()
        {
            foreach (var music in queue)
            {
                source.clip = music.audioClip;
                source.Play();
                yield return new WaitWhile(() => source.isPlaying);
            }
        }

        private IEnumerator EventsCoroutine()
        {
            foreach (var music in queue)
            {
                foreach (var musicEvent in music.events)
                {
                    ExecuteEvent(musicEvent);
                    yield return new WaitForSeconds(musicEvent.secondsToNext);
                    StopEvent(musicEvent);
                }
            }
        }

        private void ExecuteEvent(MusicEvent musicEvent)
        {
            waveController.StartWave(musicEvent.wave);
            
            switch (musicEvent.intensity)
            {
                case MusicEventIntensity.Mild:
                    backgroundManager.ChangeBackgroundAnimation(musicEvent.visuals.mildIntensityAnimationName);
                    break;
                case MusicEventIntensity.Strong:
                    backgroundManager.ChangeBackgroundAnimation(musicEvent.visuals.strongIntensityAnimationName);
                    break;
                case MusicEventIntensity.Pizdec:
                    backgroundManager.ChangeBackgroundAnimation(musicEvent.visuals.pizdecIntensityAnimationName);
                    break;
            }
        }

        private void StopEvent(MusicEvent musicEvent)
        {
            waveController.StopWave(musicEvent.wave);
        }
    }
}
