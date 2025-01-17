using System;
using System.Collections;
using Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

public class Snowflake : Obstacle
{
    private float _horizontalSpeed;
    private float _verticalSpeed;

    public float liveTime;
    
    private void Start()
    {
        _horizontalSpeed = Random.Range(minHorizontalSpeed, maxHorizontalSpeed);
        _verticalSpeed = Random.Range(minVerticalSpeed, maxVerticalSpeed);

        StartCoroutine(nameof(SnowflakeCoroutine));
    }

    private void Update()
    {
        transform.position += new Vector3(
            _horizontalSpeed * Time.deltaTime, 
            _verticalSpeed * Time.deltaTime,
            0);
    }

    private IEnumerator SnowflakeCoroutine()
    {
        yield return new WaitForSeconds(liveTime);
        Destroy(gameObject);
    }
}
