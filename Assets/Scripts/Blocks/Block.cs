using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Block : MonoBehaviour
{
    public Cost cost;

    public MatrixCollider matrixCollider;

    public virtual void OnPlace() { }
}
