using System;
using Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

public class Snowflake : Obstacle
{
    private float _horizontalSpeed;
    private float _verticalSpeed;
    
    private void Start()
    {
        _horizontalSpeed = Random.Range(minHorizontalSpeed, maxHorizontalSpeed);
        _verticalSpeed = Random.Range(minVerticalSpeed, maxVerticalSpeed);
    }

    private void Update()
    {
        transform.position += new Vector3(
            _horizontalSpeed * Time.deltaTime, 
            _verticalSpeed * Time.deltaTime,
            0);
    }
}
