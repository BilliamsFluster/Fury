using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Character : Pawn
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
       animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Move(Vector3 direction)
    {
        direction = transform.InverseTransformDirection(direction);

        direction = Vector3.ClampMagnitude(direction, 1);
        direction *= moveSpeed;

        animator.SetFloat("Forward", direction.z);
        animator.SetFloat("Right", direction.x);

    }
    public override void Rotate(float direction)
    {
        transform.Rotate(0, direction * rotationSpeed * Time.deltaTime, 0);
    }

    public override void RotateToLookAt(Vector3 position)
    {
        Vector3 vectorToLookDown = position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(vectorToLookDown);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
    }

    public void OnAnimatorMove()
    {
        transform.position += animator.deltaPosition;
        transform.rotation *= animator.deltaRotation;

        AIController aiController = controller as AIController;
        if(aiController != null)
        {
            transform.position = aiController.agent.nextPosition;
        }
    }
}
