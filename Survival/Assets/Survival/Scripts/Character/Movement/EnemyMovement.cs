using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : CharacterMovement
{
    private Transform _target;

    public override void Start()
    {
        base.Start();
        var hero = FindFirstObjectByType<Hero>();
        if (hero == null)
        {
            enabled = false;
            return;
        }

        _target = hero.transform;
    }

    public override void ApplyMove()
    {
        Direction = _target.position - transform.position;
        transform.position 
            = Vector3.MoveTowards(transform.position, _target.position, MoveSpeed * Time.fixedDeltaTime);
    }
}