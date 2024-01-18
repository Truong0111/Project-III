using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInteraction : MonoBehaviour
{
    private Enemy Enemy => gameObject.GetComponentInParent<Enemy>();

    [SerializeField] private float timePerPushDamage;
    private float _timePerPushDamage;

    private void Update()
    {
        _timePerPushDamage -= Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Hero>(out var hero))
        {
            if (_timePerPushDamage > 0) return;
            hero.UpdateHealth(-(Enemy.Damage + hero.Armor));
            _timePerPushDamage = timePerPushDamage;
        }
    }
}
