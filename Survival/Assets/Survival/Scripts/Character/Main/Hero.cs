using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class Hero : Character
{
    [SerializeField] private HeroSo heroSo;
    
    private HeroValue _heroValue;
    
    [ShowInInspector]
    private float UpgradePerTime { get; set; }
    
    [ShowInInspector]
    private float Level { get; set; }
    
    private void Awake()
    {
        ID = 0;
    }

    private void Start()
    {
        _heroValue = heroSo.heroValues[ID];
        Initialize();
    }

    private void Update()
    {
        CheckHeroDie();
    }

    private void Initialize()
    {
        Health = _heroValue.health;
        Armor = _heroValue.armor;
        Speed = _heroValue.speed;
        Experience = _heroValue.experience;
        UpgradePerTime = _heroValue.upgradePerTime;
        Level = _heroValue.level;
    }

    public void CheckHeroDie()
    {
        if(Health <= 0) gameObject.SetActive(false);
    }
}
