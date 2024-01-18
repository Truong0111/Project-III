using System;
using System.Collections;
using UnityEngine;

public class WeaponSpawnController : Singleton<WeaponSpawnController>
{
    [SerializeField] private WeaponSo weaponSo;

    private Hero _hero;

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => GameController.Instance.Hero);
        _hero = GameController.Instance.Hero;
    }
    public WeaponSpawner SpawnWeaponParent(WeaponType type)
    {
        var weaponParentValue = weaponSo.weaponValues.Find(x => x.weaponType == type);
        var newWeaponParent = new GameObject(weaponParentValue.name)
        {
            transform =
            {
                localPosition = Vector3.zero,
                rotation = Quaternion.identity
            }
        };
        
        LevelManager.Instance.MoveObjectToScene(newWeaponParent);
        
        WeaponSpawner weaponSpawnInit;

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
        return weaponSpawnInit;
    }
}