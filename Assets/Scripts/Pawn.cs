using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public Controller controller;
    public float moveSpeed;
    public float rotationSpeed;

    public abstract void Move(Vector3 direction);
    public abstract void Rotate(float direction);
    public abstract void RotateToLookAt(Vector3 position);
    

}
