using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponInteraction : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    
    private void Awake()
    {
        if (!weapon) weapon = GetComponent<Weapon>();
        if (!weapon) weapon = GetComponentInParent<Weapon>();
    }

    private void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            var damage = weapon.Damage;
            enemy.Health -= damage;
            enemy.CheckEnemyDie();
            if (TryGetComponent<EnergyBlast>(out var energyBlast))
            {
                energyBlast.ResetValue();
            }
        }
    }
}