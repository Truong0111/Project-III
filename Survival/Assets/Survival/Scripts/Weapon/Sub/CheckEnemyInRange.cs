using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemyInRange : MonoBehaviour
{
    [SerializeField] private ListObjectSo listObjectSo;
    public EnergyBlastSpawner EnergyBlastSpawner { get; set; }

    private bool _isEnergyBlastSpawnerActive;

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
        if (Enemies.Count <= 0)
        {
            _isEnergyBlastSpawnerActive = false;
            return;
        }
        if (_isEnergyBlastSpawnerActive) return;
        StartCoroutine(EnergyBlastSpawner.SpawnWeapon());
        _isEnergyBlastSpawnerActive = true;
    }
}