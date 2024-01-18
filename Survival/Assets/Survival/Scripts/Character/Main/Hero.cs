using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class Hero : Character
{
    [Title("SO")] [SerializeField] private HeroSo heroSo;
    [SerializeField] private LevelSo levelSo;

    [Title("Event")] [SerializeField] private FloatEvent playerHeathChangeEvent;
    [SerializeField] private FloatEvent playerExperienceChangeEvent;
    [SerializeField] private VoidEvent startGameEvent;
    [SerializeField] private VoidEvent winEvent;
    [SerializeField] private VoidEvent loseEvent;
    [SerializeField] private VoidEvent levelUpEvent;
    [SerializeField] private VoidEvent stopGameEvent;
    [SerializeField] private VoidEvent pauseGameEvent;
    [SerializeField] private VoidEvent continueGameEvent;

    [ShowInInspector] private float UpgradePerTime { get; set; }
    [ShowInInspector] public int Level { get; set; }

    [ShowInInspector] public List<WeaponSpawner> WeaponSpawners { get; set; } = new();
    [ShowInInspector] public int RemainChooseWeapon { get; set; }
    private HeroValue _heroValue;
    private bool IsDead() => Health <= 0;
    private bool _canCheck = true;

    private void Awake()
    {
        winEvent.Register(NoCheck);
        loseEvent.Register(NoCheck);
        stopGameEvent.Register(NoCheck);
        pauseGameEvent.Register(NoCheck);
        startGameEvent.Register(Check);
        continueGameEvent.Register(Check);
        ID = 0;
    }

    private void OnDestroy()
    {
        winEvent.Unregister(NoCheck);
        loseEvent.Unregister(NoCheck);
        stopGameEvent.Unregister(NoCheck);
        pauseGameEvent.Unregister(NoCheck);
        startGameEvent.Unregister(Check);
        continueGameEvent.Unregister(Check);
    }

    private void NoCheck()
    {
        _canCheck = false;
        foreach (var weaponSpawner in WeaponSpawners)
        {
            weaponSpawner.CanSpawn = false;
        }
    }

    private void Check()
    {
        _canCheck = true;
        foreach (var weaponSpawner in WeaponSpawners)
        {
            weaponSpawner.CanSpawn = true;
        }
    }

    private void Start()
    {
        _heroValue = heroSo.heroValues[ID];
        Initialize();
        GameController.Instance.Hero = this;
        CheckLevel();
    }

    private void Update()
    {
        if (!_canCheck) return;
        CheckHeroDie();
    }

    private void Initialize()
    {
        Health = _heroValue.health;
        MaxHealth = Health;
        Armor = _heroValue.armor;
        Speed = _heroValue.speed;
        Experience = _heroValue.experience;
        UpgradePerTime = _heroValue.upgradePerTime;
        Level = _heroValue.level;

        HealthBar.Instance.PlayerHealth = Health;
        HealthBar.Instance.PlayerMaxHealth = MaxHealth;
    }

    public void CheckHeroDie()
    {
        if (Health <= 0) gameObject.SetActive(false);
    }

    public void UpdateHealth(float value)
    {
        Health += value;
        if (Health > MaxHealth) Health = MaxHealth;
        playerHeathChangeEvent.Raise(value);
        CheckDead();
    }

    public void UpdateExperience(float value)
    {
        ExperienceBar.Instance.PlayerExperience = Experience;
        Experience += value;
        playerExperienceChangeEvent.Raise(value);
        CheckLevel();
    }

    public void CheckDead()
    {
        if (IsDead())
        {
            Animator.SetTrigger(AnimatorConstant.DieHashed);
            loseEvent.Raise();
        }
    }

    public void CheckLevel()
    {
        var needExperience = levelSo.heroExperiencePerLevels[Level].experience;
        ExperienceBar.Instance.PlayerMaxExperience = needExperience;
        if (Experience >= needExperience)
        {
            Experience -= needExperience;
            Level += 1;
            RemainChooseWeapon += 1;
            levelUpEvent.Raise();
        }
    }

    public void AddWeapon(WeaponType type)
    {
        foreach (var weaponSpawner in WeaponSpawners)
        {
            if (weaponSpawner.WeaponValue.weaponType == type)
            {
                
                weaponSpawner.UpLevel();
                WeaponGroup.Instance.UpdateWeaponShowUI();
                return;
            }
        }
        var newSpawner = WeaponSpawnController.Instance.SpawnWeaponParent(type);
        WeaponSpawners.Add(newSpawner);
        WeaponGroup.Instance.AddWeaponShowUI(newSpawner);
    }
}