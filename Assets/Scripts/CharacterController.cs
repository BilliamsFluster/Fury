using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : Controller
{
    // Boolean to determine if the character should rotate based on mouse position
    public bool isMouseRotation;

    // Initialization function called once at the start (currently empty)
    void Start()
    {

    }

    // Function called every frame
    void Update()
    {
        // Get the movement direction based on player input (Horizontal and Vertical axes)
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        // Move the pawn (character) in the specified direction
        pawn.Move(moveDirection);

        // If mouse-based rotation is enabled
        if (isMouseRotation)
        {
            Vector3 pointToLookAt;
            // Create a plane at the character's position, facing upwards
            Plane plane = new Plane(Vector3.up, pawn.transform.position);

            // Create a ray from the camera through the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            


            float distance;
            // Check if the ray intersects with the plane
            plane.Raycast(ray, out distance);

            // Get the intersection point on the plane
            pointToLookAt = ray.GetPoint(distance);

            // Rotate the pawn to face the intersection point
            pawn.RotateToLookAt(pointToLookAt);
        }

        // If mouse-based rotation is not enabled
        else
        {
            // Rotate the pawn based on the "Rotation" axis input
            pawn.Rotate(Input.GetAxis("Rotation"));
        }
        if (pawn != null)
        {
            Vector3 cameraPosition = Camera.main.transform.position;
            cameraPosition.x = pawn.transform.position.x;
            cameraPosition.z = pawn.transform.position.z;
            Camera.main.transform.position = cameraPosition;

        }

    }

    // Function to possess a pawn (currently empty)
    public override void Possess(Pawn pawn)
    {

    }

    // Function to unpossess a pawn (currently empty)
    public override void UnPossess(Pawn pawn)
    {

    }
}
