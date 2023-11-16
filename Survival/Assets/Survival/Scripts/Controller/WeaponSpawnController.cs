using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class WeaponSpawnController : Singleton<WeaponSpawnController>
{
    [SerializeField] private WeaponSo weaponSo;

    private Hero _hero;

    private void Start()
    {
        _hero = FindFirstObjectByType<Hero>();
    }

    [Button]
    private void SpawnWeaponParent(WeaponType type)
    {
        var weaponParentValue = weaponSo.weapons.Find(x => x.weaponType == type);
        var newWeaponParent = new GameObject(weaponParentValue.name)
        {
            transform =
            {
                localPosition = Vector3.zero,
                rotation = Quaternion.identity
            }
        };

        WeaponSpawner weaponSpawnInit = null;

        switch (type)
        {
            case WeaponType.MagicBall:
                weaponSpawnInit = newWeaponParent.AddComponent<MagicBallSpawner>();
                break;
            case WeaponType.Gun:
                weaponSpawnInit = newWeaponParent.AddComponent<GunSpawner>();
                break;
            case WeaponType.Shuriken:
                weaponSpawnInit = newWeaponParent.AddComponent<ShurikenSpawner>();
                break;
            case WeaponType.Pike:
                weaponSpawnInit = newWeaponParent.AddComponent<PikeSpawner>();
                break;
            case WeaponType.Sword:
                weaponSpawnInit = newWeaponParent.AddComponent<SwordSpawner>();
                break;
            case WeaponType.EnergyBlast:
                weaponSpawnInit = newWeaponParent.AddComponent<EnergyBlastSpawner>();
                var obj = SimplePool.Spawn(weaponSo.checkEnemyInRange, Vector3.zero, Quaternion.identity);
                obj.transform.parent = newWeaponParent.transform;
                obj.GetComponent<CheckEnemyInRange>().EnergyBlastSpawner = (EnergyBlastSpawner)weaponSpawnInit;
                
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
        if (weaponSpawnInit != null) weaponSpawnInit.Initialize(weaponParentValue,_hero);
    }

    [Button]
    private void DespawnWeaponParent(int id)
    {
    }
}