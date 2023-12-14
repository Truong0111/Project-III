using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenSpawner : WeaponSpawner
{
    public override void AddWeapon(int newCount)
    {
        for (var i = 0; i < newCount; i++)
        {
            var spawnWeapon = SimplePool.Spawn(Prefab, transform.position, Quaternion.identity);
            var weapon = spawnWeapon.GetComponent<Weapon>();
            weapon.Initialize(WeaponValue, Hero, null);
            spawnWeapon.SetActive(false);
            weapons.Add(weapon);
        }
    }

    public override IEnumerator SpawnWeapon()
    {
        yield return new WaitUntil(() => Hero);
        for (var index = 0; index < weapons.Count; index++)
        {
            var weapon = weapons[index];
            var spawnWeapon = weapon.gameObject;
            if(spawnWeapon.activeSelf) continue;
            spawnWeapon.SetActive(true);
            SetupPosition(spawnWeapon.transform);
            yield return new WaitForSeconds(SpawnTime);
        }
    }

    protected override void CheckTimeSpawn()
    {
        SpawnTime -= Time.deltaTime;
        if (SpawnTime > 0) return;
        StartCoroutine(SpawnWeapon());
        SpawnTime = WeaponValue.spawnTime;
    }

    private void SetupPosition(Transform objTransform)
    {
        objTransform.position = transform.position;
        objTransform.rotation = transform.rotation;
    }
}
