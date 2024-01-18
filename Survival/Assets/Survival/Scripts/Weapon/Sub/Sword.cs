using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    protected override void ApplyMove()
    {
        transform.RotateAround(transform.parent.position, Vector3.up, Speed * Time.deltaTime);
    }

    protected override void CheckDeSpawn()
    {
        DurationRemain -= Time.deltaTime;
        if (DurationRemain > 0) return;
        Despawn();
    }

    public override void ResetValue()
    {
        DurationRemain = WeaponValue.duration;
    }
}
