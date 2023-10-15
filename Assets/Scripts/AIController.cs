using UnityEngine;
using UnityEngine.AI;

public class AIController : Controller
{
    [Header("AI Components")]
    [Tooltip("The NavMeshAgent component attached to the AI character.")]
    [HideInInspector]public NavMeshAgent agent; // Made private as it should not be exposed in the inspector

    [Header("AI Settings")]
    [Tooltip("Distance at which the AI stops moving towards its target.")]
    public float stoppingDistance = 1.0f;

    [Tooltip("The target that the AI will chase/follow.")]
    public Transform chaseTarget;

    /// <summary>
    /// Takes control of a Pawn object.
    /// </summary>
    /// <param name="pawnToPossess">The pawn to possess.</param>
    public override void Possess(Pawn pawnToPossess)
    {
        agent = pawnToPossess.GetComponent<NavMeshAgent>();
        if (agent == null)
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

    /// <summary>
    /// Releases control of a Pawn object.
    /// </summary>
    /// <param name="pawn">The pawn to unpossess.</param>
    public override void UnPossess(Pawn pawn)
    {
        Destroy(agent);
        pawn.GetComponent<Rigidbody>().isKinematic = false;
    }

    private void Start()
    {
        if (pawn != null)
        {
            Possess(pawn);
        }
    }

    private void Update()
    {
        agent.SetDestination(chaseTarget.position);
        Vector3 moveVector = new Vector3(agent.desiredVelocity.x, 0, agent.desiredVelocity.z);
        pawn.Move(moveVector);
        pawn.RotateToLookAt(chaseTarget.position);
    }
}
