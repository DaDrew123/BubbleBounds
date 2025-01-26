using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingVerticalClouds : MonoBehaviour
{
    public float speed = 2f;  // Speed of the platform
    public float moveDistance = 5f;  // How far the platform moves
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;  // Store the initial position
    }

    void Update()
    {
        float movement = Mathf.PingPong(Time.time * speed, moveDistance);  // PingPong creates a back and forth effect
        transform.position = new Vector3(startPosition.x, startPosition.y + movement, startPosition.z);
    }
}
