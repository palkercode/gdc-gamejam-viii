using UnityEngine;

namespace Enemies
{
    public abstract class Obstacle : MonoBehaviour
    {
        public float minHorizontalSpeed, maxHorizontalSpeed;
        public float minVerticalSpeed, maxVerticalSpeed;
    }
}