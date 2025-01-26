using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingClouds : MonoBehaviour
{

    private Renderer platformRenderer;  // To control the visibility of the platform
    private Collider2D platformCollider;  // To disable/enable the platform's collision
    public float disappearTime = 2f;  // Time for the platform to remain disappeared
    private bool playerOnPlatform = false;  // To check if player is on the platform
    private float timeSincePlayerStepped = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Get the platform's Renderer and Collider
        platformRenderer = GetComponent<Renderer>();
        platformCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is on the platform, start the timer to disappear
        if (playerOnPlatform)
        {
            timeSincePlayerStepped += Time.deltaTime;

            if (timeSincePlayerStepped >= disappearTime)
            {
                DisappearPlatform();
            }
        }
        else
        {
            // Reset the time if the player is no longer on the platform
            timeSincePlayerStepped = 0f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))  // Ensure it's the player
        {
            Debug.Log("Player Detected");
            playerOnPlatform = true;
        }
    }

    // When the player exits the platform's trigger area
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))  // Ensure it's the player
        {
            Debug.Log("Player Out");
            playerOnPlatform = false;
            ReappearPlatform();
        }
    }

    // Make the platform disappear (disable renderer and collider)
    private void DisappearPlatform()
    {
        platformRenderer.enabled = false;
        platformCollider.enabled = false;
    }

    // Make the platform reappear (enable renderer and collider)
    private void ReappearPlatform()
    {
        platformRenderer.enabled = true;
        platformCollider.enabled = true;
    }
}
