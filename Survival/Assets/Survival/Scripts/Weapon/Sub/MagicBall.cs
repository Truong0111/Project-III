using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : Weapon
{
    protected override void ApplyMove()
    {
        transform.RotateAround(transform.parent.position, Vector3.up, Speed * Time.deltaTime);
    }

    protected override void CheckDeSpawn()
    {
        Duration -= Time.deltaTime;
        if (Duration > 0) return;
        Despawn();
    }

    public override void ResetValue()
    {
        if (WeaponValue == null)
        {
            Duration = 9999f;
            return;
        }

        Duration = WeaponValue.duration;
    }
}