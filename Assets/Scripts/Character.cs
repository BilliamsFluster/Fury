using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : Pawn
{
    // Reference to the Animator component, which controls animations
    private Animator animator;

    // Initialization function called once at the start
    void Start()
    {
        // Get the Animator component attached to this GameObject
        animator = GetComponent<Animator>();
    }

    // Function called every frame (currently empty)
    void Update()
    {

    }

    // Override the Move function to handle character-specific movement
    public override void Move(Vector3 direction)
    {
        // Convert the direction from world space to local space
        direction = transform.InverseTransformDirection(direction);

        // Clamp the magnitude of the direction vector to a maximum of 1
        direction = Vector3.ClampMagnitude(direction, 1);

        // Scale the direction by the character's move speed
        direction *= moveSpeed;

        // Update the animator's parameters to control movement animations
        animator.SetFloat("Forward", direction.z);
        animator.SetFloat("Right", direction.x);
    }

    // Override the Rotate function to handle character-specific rotation
    public override void Rotate(float direction)
    {
        // Rotate the character around the Y-axis based on the given direction and rotation speed
        transform.Rotate(0, direction * rotationSpeed * Time.deltaTime, 0);
    }

    // Override the RotateToLookAt function to make the character face a specific position
    public override void RotateToLookAt(Vector3 position)
    {
        // Calculate the direction vector pointing towards the target position
        Vector3 vectorToLookDown = position - transform.position;

        // Calculate the desired rotation to face the target position
        Quaternion lookRotation = Quaternion.LookRotation(vectorToLookDown);

        // Smoothly rotate the character towards the desired rotation
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }

    // Function called by the Animator component when it updates
    public void OnAnimatorMove()
    {
        // Apply the movement and rotation calculated by the Animator
        transform.position += animator.deltaPosition;
        transform.rotation *= animator.deltaRotation;

        // Check if the character is controlled by an AIController
        AIController aiController = controller as AIController;
        if (aiController != null)
        {
            // Update the character's position based on the AI's navigation path
            transform.position = aiController.agent.nextPosition;
        }
    }
}
