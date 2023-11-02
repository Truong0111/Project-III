using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class WeaponSpawn : MonoBehaviour
{
    public WeaponValue WeaponValue { get; private set; }

    private GameObject _prefab;
    private int _count;
    private float _spawnTime;

    public void Initialize(WeaponValue value)
    {
        WeaponValue = value;
        _prefab = value.prefab;
        _count = value.count;
        _spawnTime = 0;
    }

    private void Update()
    {
        CheckTimeSpawn();
    }

    public void SpawnSetup()
    {
    }

    public void AddWeapon()
    {
    }

    private void CheckTimeSpawn()
    {
        _spawnTime -= Time.deltaTime;
        if (_spawnTime > 0) return;
        SpawnWeapon();
        _spawnTime = WeaponValue.spawnTime;
    }

    [Button]
    public virtual void SpawnWeapon()
    {
        for (var index = 0; index < _count; index++)
        {
            var spawnWeapon = SimplePool.Spawn(_prefab, Vector3.zero, Quaternion.identity);
            var weapon = spawnWeapon.GetComponent<Weapon>();
            SetupPosition(spawnWeapon.transform, _count, index);
            weapon.Initialize(WeaponValue, transform);
            spawnWeapon.SetActive(true);
        }
    }

    private void SetupPosition(Transform objTransform, int count, int index)
    {
        switch (WeaponValue.weaponMovementType)
        {
            case WeaponMovementType.Around:
                var speed = WeaponValue.speed;
                objTransform.position = transform.position;
                objTransform.localPosition
                    += (Vector3.right * Mathf.Cos(speed * index / count * Mathf.Deg2Rad)
                        + Vector3.forward * Mathf.Sin(speed * index / count * Mathf.Deg2Rad)).normalized * 2f;
                break;
        }
    }
}