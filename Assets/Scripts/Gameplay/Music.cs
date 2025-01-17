using System;
using System.Collections.Generic;
using Gameplay.Waves;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay
{
    public class Music : MonoBehaviour
    {
        public AudioClip audioClip;
        public List<MusicEvent> events;
    }

    [Serializable]
    public struct MusicEvent
    {
        public float secondsToNext;
        public MusicEventIntensity intensity;
        public MusicEventVisuals visuals;

        public Wave wave;
    }

    [Serializable]
    public enum MusicEventIntensity
    {
        Mild, Strong, Pizdec
    }

    [Serializable]
    public struct MusicEventVisuals
    {
        public string mildIntensityAnimationName;
        public string strongIntensityAnimationName;
        public string pizdecIntensityAnimationName;
    }
}