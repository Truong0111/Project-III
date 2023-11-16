using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : Character
{
    [field: Header("SO")]
    [field: SerializeField] public EnemySo EnemySo { get; private set; }
    [field: SerializeField] public ListObjectSo ListObjectSo { get; set; }
    
    //Variable
    public EnemyValue EnemyValue { get; private set; }
    
    [ShowInInspector]
    public float UpgradePerTime { get; private set; }
    
    [ShowInInspector]
    public float Drop { get; private set; }

    private void Awake()
    {
        ID = Random.Range(0, 2);
        
        EnemyValue = EnemySo.enemyValues[ID];
        Initialize();
        
    }

    private void OnEnable()
    {
        SetupValue();
        ListObjectSo.enemyInRanges.Add(this);
    }

    private void OnDisable()
    {
        ListObjectSo.enemyInRanges.Remove(this);
    }

    private void Initialize()
    {
        
    }

    private void SetupValue()
    {
        Health = EnemyValue.health * (1.0f + UpgradePerTime);
        Damage = EnemyValue.damage * (1.0f + UpgradePerTime);
        
        Armor = EnemyValue.armor;
        Speed = EnemyValue.speed;
        Experience = EnemyValue.experience;
        UpgradePerTime = EnemyValue.upgradePerTime;
        Drop = EnemyValue.drop;
    }

    public void CheckEnemyDie()
    {
        if (Health <= 0f)
        {
            SimplePool.Despawn(gameObject);
            SpawnController.Instance.DropExperience(this);
        }
    }
}