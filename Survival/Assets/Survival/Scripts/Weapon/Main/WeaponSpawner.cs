using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    protected WeaponValue WeaponValue { get; set; }

    public List<Weapon> weapons = new();

    protected Hero Hero { get; set; }

    protected GameObject Prefab { get; set; }
    protected int Count { get; set; }
    protected float SpawnTime { get; set; }

    public virtual void Initialize(WeaponValue value, Hero hero)
    {
        WeaponValue = value;
        Hero = hero;
        Prefab = value.prefab;
        SpawnTime = 0;
        AddWeapon(value.count);
    }

    protected virtual void Update()
    {
        if (Hero) transform.position = Hero.transform.position;
        CheckTimeSpawn();
    }

    [Button]
    public virtual void AddWeapon(int newCount)
    {
        for (var index = 0; index < newCount; index++)
        {
            var spawnWeapon = SimplePool.Spawn(Prefab, transform.position, Quaternion.identity);
            var weapon = spawnWeapon.GetComponent<Weapon>();
            spawnWeapon.SetActive(false);
            weapon.Initialize(WeaponValue, Hero, transform);
            weapons.Add(weapon);
        }

        Count += newCount;
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
}