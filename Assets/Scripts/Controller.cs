using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public Pawn pawn;
    public abstract void Possess(Pawn pawn);
    public abstract void UnPossess(Pawn pawn);

}
