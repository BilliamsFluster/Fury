using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHealthBarToCamera : MonoBehaviour
{
    public Camera playerCamera;

    void Update()
    {
        if (playerCamera == null)
        {
            // Find the player's camera if not set
            playerCamera = Camera.main;
        }

        // Make the health bar face the camera
        transform.LookAt(transform.position + playerCamera.transform.rotation * Vector3.forward,
            playerCamera.transform.rotation * Vector3.up);
    }
}
