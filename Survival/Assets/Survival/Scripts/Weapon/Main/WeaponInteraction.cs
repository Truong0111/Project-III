using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInteraction : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    
    private void Awake()
    {
        if (!weapon) weapon = GetComponent<Weapon>();
        if (!weapon) weapon = GetComponentInParent<Weapon>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            var damage = weapon.Damage;
            enemy.Health -= damage - enemy.Armor;
            enemy.CheckEnemyDie();
        }
    }

    private IEnumerator OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Enemy>(out var enemy))
        {
            if (weapon.WeaponValue.weaponType == WeaponType.Shuriken)
            {
                var damage = weapon.Damage;
                enemy.Health -= damage;
                enemy.CheckEnemyDie();
                yield return new WaitForSeconds(0.25f);
            }
        }
    }
}