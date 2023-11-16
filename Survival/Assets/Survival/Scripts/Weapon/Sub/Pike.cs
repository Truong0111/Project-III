using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pike : Weapon
{
    [SerializeField] private Transform pikeChild;
    
    protected override void ApplyMove()
    { 
        var targetPos = transform.position + transform.forward * pikeChild.localScale.z;
        pikeChild.position = Vector3.MoveTowards(pikeChild.position, targetPos, Speed);
        CheckDeSpawn(targetPos);
    }
    
    
    private void CheckDeSpawn(Vector3 targetPos)
    {
        if (Vector3.Distance(pikeChild.position, targetPos) < 0.01f)
        {
            Despawn();
        }
    }

    public override void ResetValue()
    {
        pikeChild.localPosition = Vector3.zero;
    }
}
