using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public WeaponValue WeaponValue { get; private set; } = new();
    public List<Weapon> weapons = new();

    [ShowInInspector] public Hero Hero { get; set; }

    public bool CanSpawn { get; set; }
    protected float SpawnTime;
    public virtual void Initialize(WeaponValue value, Hero hero)
    {
        WeaponValue.damage = value.damage;
        WeaponValue.count = value.count;
        WeaponValue.duration = value.duration;
        WeaponValue.count = value.count;
        WeaponValue.id = value.id;
        WeaponValue.level = value.level;
        WeaponValue.speed = value.speed;
        WeaponValue.spawnTime = value.spawnTime;
        WeaponValue.sprite = value.sprite;
        WeaponValue.weaponType = value.weaponType;
        WeaponValue.prefab = value.prefab;
        SpawnTime = 0;
        Hero = hero;
        UpLevel();
        AddWeapon(value.count);
    }

    protected virtual void Update()
    {
        if (Hero) transform.position = Hero.transform.position;
        CheckTimeSpawn();
    }
    
    public virtual void AddWeapon(int newCount)
    {
        for (var index = 0; index < newCount; index++)
        {
            var spawnWeapon = SimplePool.Spawn(WeaponValue.prefab, transform.position, Quaternion.identity);
            var weapon = spawnWeapon.GetComponent<Weapon>();
            spawnWeapon.SetActive(false);
            weapon.Initialize(WeaponValue, Hero, transform);
            weapons.Add(weapon);
        }

        WeaponValue.count += newCount;
    }

    
    protected virtual void CheckTimeSpawn()
    {
        SpawnTime -= Time.deltaTime;
        if (SpawnTime > 0) return;
        StartCoroutine(SpawnWeapon());
        SpawnTime = WeaponValue.spawnTime;
    }

    public virtual IEnumerator SpawnWeapon()
    {
        return null;
    }

    public virtual void UpLevel()
    {
        WeaponValue.level += 1;
        InitUpLevel();
    }

    public virtual void InitUpLevel()
    {
        WeaponValue.damage += 2f;
        WeaponValue.count += 1;
        // WeaponValue.duration -= Level * 0.02f;
        // Count = Level;
        // SpawnTime -= Level * 0.02f;
    }
}