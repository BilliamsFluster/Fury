using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControlls : MonoBehaviour
  
{
    private Rigidbody mainRigidbody;
    private Collider mainCollider;
    private Rigidbody[] rigidbodies;
    private Collider[] colliders;
    private Animator animator;
    public bool isRagdoll;
    // Start is called before the first frame update
    void Start()
    {
        mainCollider = GetComponent<Collider>();
        mainRigidbody = GetComponent<Rigidbody>();
        rigidbodies = GetComponentsInChildren<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();
        animator = GetComponent<Animator>();

        if (isRagdoll)
            EnableRagdoll();
        else
            DisableRagdoll();

    }
    public void EnableRagdoll()
    {
        foreach(Collider collider in colliders)
        {
            collider.enabled = true;
        }
        foreach(Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = false;
        }
        mainRigidbody.isKinematic = true;
        mainCollider.enabled = true;
        isRagdoll = true;
        animator.enabled = false;
    }
    public void DisableRagdoll()
    {
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
        }
        foreach (Rigidbody rigidbody in rigidbodies)
        {
            rigidbody.isKinematic = true;
        }
        mainRigidbody.isKinematic = false;
        mainCollider.enabled = true;
        animator.enabled = true;

        isRagdoll = false;
    }

    public void ToggleRagdoll() 
    { if (isRagdoll)
            DisableRagdoll();
        else
            EnableRagdoll();
    }
    
}
