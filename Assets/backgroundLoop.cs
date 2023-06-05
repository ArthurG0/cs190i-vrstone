using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundLoop : MonoBehaviour
{
    // The speed of the scrolling
    public float scrollSpeed = -5f;

    // The width and height of the screen in world units
private float screenWidth;
private float screenHeight;

// A small value to avoid gaps between sprites
private float choke = 0.5f;

void Start()
{
    // Calculate the screen width and height using the camera size and aspect ratio
    screenWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
    screenHeight = Camera.main.orthographicSize;
}

void Update()
{
    // Loop through each child sprite
    foreach (Transform child in transform)
    {
        // Move the sprite by the scroll speed
        child.position += Vector3.right * scrollSpeed * Time.deltaTime;

        // Check if the sprite has gone off-screen horizontally
        if (child.position.x < -screenWidth - choke)
        {
            // Reposition it to the right end of the screen
            child.position += Vector3.right * 2 * (screenWidth + choke);
        }
        else if (child.position.x > screenWidth + choke)
        {
            // Reposition it to the left end of the screen
            child.position -= Vector3.right * 2 * (screenWidth + choke);
        }

        // Check if the sprite has gone off-screen vertically
        if (child.position.y < -screenHeight - choke)
        {
            // Reposition it to the top end of the screen
            child.position += Vector3.up * 2 * (screenHeight + choke);
        }
        else if (child.position.y > screenHeight + choke)
        {
            // Reposition it to the bottom end of the screen
            child.position -= Vector3.up * 2 * (screenHeight + choke);
        }
    }
}
}