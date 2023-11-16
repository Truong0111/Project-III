using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBlast : Weapon
{
    [SerializeField] private ListObjectSo listObjectSo;

    protected override void ApplyMove()
    {
        var target = FindNearestEnemy();
        if (!target)
        {
            ResetValue();
            return;
        }

        var targetPosition = target.position;
        var direction = targetPosition - transform.position;
        transform.position
            = Vector3.MoveTowards(transform.position, targetPosition, Speed * Time.fixedDeltaTime);

        var targetRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 20f);
    }

    private List<Enemy> Enemies => listObjectSo.enemyInRanges;

    private Transform FindNearestEnemy()
    {
        if (Enemies.Count <= 0) return null;
        var distance = float.MaxValue;
        Transform target = null;
        foreach (var enemy in Enemies)
        {
            var distanceToEnemy = Vector3.Distance(enemy.transform.position, Hero.transform.position);
            if (distanceToEnemy >= distance) continue;
            distance = distanceToEnemy;
            target = enemy.transform;
        }

        return target;
    }

    public override void ResetValue()
    {
        transform.position = Hero.transform.position;
    }
}