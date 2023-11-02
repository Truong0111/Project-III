using System;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class Hero : Character
{
    // [SerializeField] private IntVariable playerHeath;
    // [SerializeField] private IntEvent playerHeathChangeEvent;
    [SerializeField] private HeroSo heroSo;
    
    private HeroValue _heroValue;
    private float UpgradePerTime { get; set; }
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

    private void Initialize()
    {
        Heath = _heroValue.health;
        Armor = _heroValue.armor;
        Speed = _heroValue.speed;
        Experience = _heroValue.experience;
        UpgradePerTime = _heroValue.upgradePerTime;
        Level = _heroValue.level;
    }
}
