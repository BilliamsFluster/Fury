using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

// Define an abstract class named Pawn, which inherits from MonoBehaviour
public abstract class Pawn : MonoBehaviour
{
    // Reference to the Controller that controls this Pawn
    public Controller controller;

    // Movement speed of the Pawn
    public float moveSpeed;

    // Rotation speed of the Pawn
    public float rotationSpeed;

    // Abstract method to move the Pawn in a specified direction
    // This method must be implemented by any non-abstract class that inherits from Pawn
    public abstract void Move(Vector3 direction);

    // Abstract method to rotate the Pawn based on a specified direction
    // This method must be implemented by any non-abstract class that inherits from Pawn
    public abstract void Rotate(float direction);

    // Abstract method to rotate the Pawn to face a specified position
    // This method must be implemented by any non-abstract class that inherits from Pawn
    public abstract void RotateToLookAt(Vector3 position);
}
