using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : CharacterMovement
{
    private Transform _targetPosition;
    
    public override void Start()
    {
        base.Start();
        var hero = FindFirstObjectByType<Hero>();
        if (hero == null)
        {
            enabled = false;
            return;
        }

        _targetPosition = hero.transform;
    }

    public override void ApplyMove()
    {
        Direction = (_targetPosition.position - transform.position).normalized;
        Rigidbody.AddForce(Direction * MoveSpeed, ForceMode.VelocityChange);
    }
}