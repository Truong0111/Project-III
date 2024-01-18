using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Weapon
{
    [SerializeField] private float range = 50f;
    
    public override void Initialize(WeaponValue value, Hero hero, Transform parent)
    {
        WeaponValue = value;
        Hero = hero;
    }
    
    protected override void ApplyMove()
    {
        transform.position += transform.forward * (Speed * Time.deltaTime);
        CheckDeSpawn();
    }
    
    private new void CheckDeSpawn()
    {
        var distanceToHero = Hero.transform.position - transform.position;
        if (distanceToHero.magnitude > range)
        {
            Despawn();
        }
    }

    public override void ResetValue()
    {
        transform.position = Hero.transform.position;
    }
}
