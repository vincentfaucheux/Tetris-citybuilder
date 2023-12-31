using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class BlockGroup : MonoBehaviour
{
    public int cost = 10;
    
    MatrixCollider[] childColliders;
    CollisionMatrix _matrix{ get => CollisionMatrix.instance; }
    Vector2Int _matrixPosition { get => CollisionMatrix.instance.GetMatrixPos(transform); }

    void Start()
    {
        childColliders = GetComponentsInChildren<MatrixCollider>(true);
    }

    public Vector2Int GetLowestPosition(int x)
    {
        int y = 0;
        while (true)
        {
            Vector2Int basePosition = new Vector2Int(x, y);
            if (!IsValidPosition(basePosition))
                continue;

            return basePosition;
        }
    }

    public bool IsValidPosition(Vector2Int basePosition)
    {
        foreach (MatrixCollider childCollider in childColliders)
        {
            Vector2Int relativePosition = childCollider.matrixPosition - _matrixPosition;
            Vector2Int positionToCheck = basePosition + relativePosition;

            if (!CollisionMatrix.instance.IsValidPosition(positionToCheck))
                return false;

            List<MatrixCollider> collidersAtPosition = _matrix.GetCollidersAtPosition(positionToCheck).Where(col => !childColliders.Contains(col)).ToList();
            if (collidersAtPosition.Any())
                return false;
        }
        return true;
    }



    public void Move(Vector2Int position)
    {
        transform.position = CollisionMatrix.instance.GetRealWorldPosition(position);
        SynchronizePosition();
    }
    
    public void SynchronizePosition()
    {
        foreach(MatrixCollider childCollider in childColliders)
            childCollider.SynchronizePosition();
    }
}
