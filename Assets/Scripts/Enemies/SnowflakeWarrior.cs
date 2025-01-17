using System;
using Player;
using UnityEngine;

public class SnowflakeWarrior : MonoBehaviour
{
    [SerializeField] private Transform player;

    public float speed;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        // TODO: Change lerp to smoothdamp
        transform.position = Vector3.Lerp(transform.position, player.position, speed * Time.deltaTime);
    }
}
