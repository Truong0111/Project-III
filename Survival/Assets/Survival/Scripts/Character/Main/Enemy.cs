using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private IntVariable enemyHeath;
    [SerializeField] private EnemySo enemySo;
    
    private EnemyValue _enemyValue;
    private float UpgradePerTime { get; set; }
    private float Drop { get; set; }
    private void Awake()
    {
        ID = 0;
    }

    private void Start()
    {
        _enemyValue = enemySo.enemyValues[ID];
        Initialize();
    }

    private void Initialize()
    {
        Heath = _enemyValue.health;
        Armor = _enemyValue.armor;
        Speed = _enemyValue.speed;
        Experience = _enemyValue.experience;
        UpgradePerTime = _enemyValue.upgradePerTime;
        Drop = _enemyValue.drop;
    }
}
