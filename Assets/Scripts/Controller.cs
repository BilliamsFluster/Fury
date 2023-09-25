using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Define an abstract class named Controller, which inherits from MonoBehaviour
public abstract class Controller : MonoBehaviour
{
    // Reference to the Pawn that this Controller controls
    public Pawn pawn;

    // Abstract method to take control (possess) of a specified Pawn
    // This method must be implemented by any non-abstract class that inherits from Controller
    public abstract void Possess(Pawn pawn);

    // Abstract method to release control (unpossess) of a Pawn
    // This method must be implemented by any non-abstract class that inherits from Controller
    public abstract void UnPossess(Pawn pawn);
}
