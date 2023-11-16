using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenSpawner : WeaponSpawner
{
    public override void AddWeapon(int newCount)
    {
        for (var i = 0; i < newCount; i++)
        {
            var spawnWeapon = SimplePool.Spawn(Prefab, Vector3.zero, Quaternion.identity);
            var weapon = spawnWeapon.GetComponent<Weapon>();
            weapon.Initialize(WeaponValue, Hero, null);
            spawnWeapon.SetActive(false);
            weapons.Add(weapon);
        }
    }

    public override IEnumerator SpawnWeapon()
    {
        
        for (var index = 0; index < weapons.Count; index++)
        {
            var weapon = weapons[index];
            var spawnWeapon = weapon.gameObject;
            if(spawnWeapon.activeSelf) continue;
            SetupPosition(spawnWeapon.transform);
            spawnWeapon.SetActive(true);
            yield return new WaitForSeconds(SpawnTime);
        }
    }

    public override void CheckTimeSpawn()
    {
        SpawnTime -= Time.deltaTime;
        if (SpawnTime > 0) return;
        StartCoroutine(SpawnWeapon());
        SpawnTime = WeaponValue.spawnTime;
    }

    private void SetupPosition(Transform objTransform)
    {
        objTransform.position = transform.position;
    }
}
