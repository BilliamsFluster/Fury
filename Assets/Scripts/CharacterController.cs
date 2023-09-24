using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : Controller
{
    public bool isMouseRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        moveDirection = pawn.transform.InverseTransformDirection(moveDirection);
        
        pawn.Move(moveDirection);
        if(isMouseRotation)
        {
            Vector3 pointToLookAt;
            Plane plane = new Plane(Vector3.up, pawn.transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float distance;
            plane.Raycast(ray, out distance);
            pointToLookAt = ray.GetPoint(distance);
            pawn.RotateToLookAt(pointToLookAt);
        }
        
        else
            pawn.Rotate(Input.GetAxis("Rotation"));
    }

    public override void Possess(Pawn pawn)
    {

    }

    public override void UnPossess(Pawn pawn)
    {

    }
}
