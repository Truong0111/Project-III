using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyInRange : Singleton<CheckEnemyInRange>
{
    [SerializeField] private ListObjectSo listObjectSo;
    public EnergyBlastSpawner EnergyBlastSpawner { get; set; }
    
    private List<Enemy> Enemies
    {
        get => listObjectSo.enemyInRanges;
        set => listObjectSo.enemyInRanges = value;
    }

    private void Awake()
    {
        Enemies = new List<Enemy>();
    }

    private void Update()
    {
        if (Enemies.Count <= 0) return;
        StartCoroutine(EnergyBlastSpawner.SpawnWeapon());
    }
}