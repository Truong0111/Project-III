using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class WeaponSpawnController : Singleton<WeaponSpawnController>
{
    [SerializeField] private WeaponSo weaponSo;

    private Transform _heroTransform;
    private void Start()
    {
        _heroTransform = FindFirstObjectByType<Hero>().transform;
        SpawnWeaponParent(0);
    }

    [Button]
    private void SpawnWeaponParent(int id)
    {
        var weaponParentValue = weaponSo.weapons.Find(x => x.id == id);
        var newWeaponParent = new GameObject(weaponParentValue.name)
        {
            transform =
            {
                parent = _heroTransform,
                localPosition = Vector3.zero,
                rotation = Quaternion.identity
            }
        };
        var weaponSpawnInit = newWeaponParent.AddComponent<WeaponSpawn>();
        weaponSpawnInit.Initialize(weaponParentValue);
    }
    
    [Button]
    private void DespawnWeaponParent(int id)
    {
        
    }
}
