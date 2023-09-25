using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class AIController : Controller
{
    // The NavMeshAgent component attached to the AI character
    [HideInInspector] public NavMeshAgent agent;

    // Distance at which the AI stops moving towards its target
    public float stoppingDistance = 1.0f;

    // The target that the AI will chase/follow
    public Transform chaseTarget;

    // Function to take control of a Pawn object
    public override void Possess(Pawn pawnToPossess)
    {
        // Set the current pawn to the provided pawn
        pawn = pawnToPossess;

        // Try to get the NavMeshAgent component from the pawn
        agent = pawnToPossess.GetComponent<NavMeshAgent>();

        // If the pawn doesn't have a NavMeshAgent, add one
        if (agent == null)
        {
            pawn.gameObject.AddComponent<NavMeshAgent>();
        }

        // Set the agent's speed and rotation speed based on the pawn's attributes
        agent.speed = pawn.moveSpeed;
        agent.angularSpeed = pawn.rotationSpeed;
        agent.stoppingDistance = stoppingDistance;

        // Disable the agent's automatic updates for position and rotation
        agent.updatePosition = false;
        agent.updateRotation = false;

        // Make the pawn's Rigidbody kinematic (no physics interactions)
        pawn.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Function to release control of a Pawn object
    public override void UnPossess(Pawn pawn)
    {
        // Set the current pawn to null
        pawn = null;

        // Destroy the NavMeshAgent component
        Destroy(agent);

        // Restore physics interactions for the pawn
        pawn.GetComponent<Rigidbody>().isKinematic = false;
    }

    // Initialization function called once at the start
    void Start()
    {
        // If there's a pawn assigned, take control of it
        if (pawn != null)
        {
            Possess(pawn);
        }
    }

    // Function called every frame
    void Update()
    {
        // Set the AI's destination to the chase target's position
        agent.SetDestination(chaseTarget.position);

        // Calculate the movement vector based on the agent's desired velocity
        Vector3 moveVector = new Vector3(agent.desiredVelocity.x, 0, agent.desiredVelocity.z);

        // Move the pawn based on the calculated vector
        pawn.Move(moveVector);

        // Rotate the pawn to face the chase target
        pawn.RotateToLookAt(chaseTarget.position);
    }
}
