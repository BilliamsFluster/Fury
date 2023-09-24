using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.AI;

public class AIController : Controller
{
    [HideInInspector]public NavMeshAgent agent;
    public float stoppingDistance = 1.0f;
    public Transform chaseTarget;

    public override void Possess(Pawn pawnToPossess)
    {
        pawn = pawnToPossess;
        agent = pawnToPossess.GetComponent<NavMeshAgent>();

        if(agent == null) 
        { 
            pawn.gameObject.AddComponent<NavMeshAgent>();
        }
        agent.speed = pawn.moveSpeed;
        agent.angularSpeed = pawn.rotationSpeed;
        agent.stoppingDistance = stoppingDistance;

        agent.updatePosition = false;
        agent.updateRotation = false;

        pawn.GetComponent<Rigidbody>().isKinematic = true;
    }

    public override void UnPossess(Pawn pawn)
    {
        pawn = null;
        Destroy(agent);
        pawn.GetComponent<Rigidbody>().isKinematic = false;

    }

    // Start is called before the first frame update
    void Start()
    {
        if(pawn != null)
        {
            Possess(pawn);
        }
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(chaseTarget.position);
        Vector3 moveVector = new Vector3(agent.desiredVelocity.x, 0, agent.desiredVelocity.z);
        pawn.Move(moveVector);

        pawn.RotateToLookAt(chaseTarget.position);
    }
}
