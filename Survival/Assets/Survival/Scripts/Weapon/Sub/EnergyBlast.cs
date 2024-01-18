using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class EnergyBlast : Weapon
{
    [SerializeField] private ListObjectSo listObjectSo;
    [ShowInInspector] private Transform Target { get; set; }

    public override void OnEnable()
    {
        base.OnEnable();
        
    }

    protected override void ApplyMove()
    {
        if (!Target)
        {
            FindNearestEnemy();
            return;
        }
        var targetPosition = Target.position;
        var direction = (targetPosition - transform.position).normalized;
        var targetRotation = Quaternion.LookRotation(direction, Vector3.up);

        transform.position += direction * (Speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 45f);
        
        if(Vector3.Distance(transform.position, Target.position) < 0.1f) ResetValue();
    }

    protected override void CheckDeSpawn()
    {
        DurationRemain -= Time.deltaTime;
        if (DurationRemain > 0) return;
        Despawn();
    }

    public override void ResetValue()
    {
        transform.position = Hero.transform.position;
        DurationRemain = WeaponValue.duration;
        Target = null;
    }

    private List<Enemy> Enemies => listObjectSo.enemyInRanges;

    private void FindNearestEnemy()
    {
        if (Enemies.Count <= 0)
        {
            Target = null;
            return;
        }

        var distance = float.MaxValue;
        foreach (var enemy in Enemies)
        {
            var distanceToEnemy = Vector3.Distance(enemy.transform.position, Hero.transform.position);
            if (distanceToEnemy >= distance) continue;
            distance = distanceToEnemy;
            Target = enemy.transform;
        }
    }
}