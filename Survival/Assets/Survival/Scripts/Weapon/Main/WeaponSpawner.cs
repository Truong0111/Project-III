using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public WeaponValue WeaponValue { get; protected set; }

    public List<Weapon> weapons = new();

    public Hero Hero { get; set; }

    public GameObject Prefab { get; set; }
    public int Count { get; set; }
    public float SpawnTime { get; set; }

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
        CheckTimeSpawn();
        if (Hero) transform.position = Hero.transform.position;
    }

    public virtual void SpawnSetup()
    {
    }

    [Button]
    public virtual void AddWeapon(int newCount)
    {
        for (var index = 0; index < newCount; index++)
        {
            var spawnWeapon = SimplePool.Spawn(Prefab, Vector3.zero, Quaternion.identity);
            var weapon = spawnWeapon.GetComponent<Weapon>();
            spawnWeapon.SetActive(false);
            weapon.Initialize(WeaponValue, Hero, transform);
            weapons.Add(weapon);
        }

        Count += newCount;
    }

    public virtual void CheckTimeSpawn()
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

    public virtual void SetupPosition()
    {
    }
}