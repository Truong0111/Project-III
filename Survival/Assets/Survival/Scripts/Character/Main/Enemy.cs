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
    [field: SerializeField]
    public EnemySo EnemySo { get; private set; }

    [field: SerializeField] public ListObjectSo ListObjectSo { get; set; }

    //Variable
    public EnemyValue EnemyValue { get; private set; }

    [ShowInInspector] public float UpgradePerTime { get; private set; }

    [ShowInInspector] public float Drop { get; private set; }

    private void Awake()
    {
        ID = Random.Range(0, EnemySo.enemyValues.Count);

        EnemyValue = EnemySo.enemyValues[ID];
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

    private void SetupValue()
    {
        Health = EnemyValue.health + UpgradePerTime * GameController.Instance.CurrentTime;
        Damage = EnemyValue.damage + UpgradePerTime * GameController.Instance.CurrentTime / 2f;

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