using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSpawner : WeaponSpawner
{
    [SerializeField] private float time = 0.1f;

    public override void AddWeapon(int newCount)
    {
        for (var i = 0; i < newCount; i++)
        {
            var spawnWeapon = SimplePool.Spawn(WeaponValue.prefab, transform.position, Quaternion.identity);
            var weapon = spawnWeapon.GetComponent<Weapon>();
            weapon.Initialize(WeaponValue, Hero, null);
            spawnWeapon.SetActive(false);
            weapons.Add(weapon);
        }
    }

    public override IEnumerator SpawnWeapon()
    {
        if(!CanSpawn) yield break;
        yield return new WaitUntil(() => Hero);
        for (var index = 0; index < weapons.Count; index++)
        {
            var weapon = weapons[index];
            var spawnWeapon = weapon.gameObject;
            if (Hero) transform.rotation = Hero.transform.rotation;
            spawnWeapon.SetActive(true);
            SetupPosition(spawnWeapon.transform, index);
            yield return new WaitForSeconds(time);
        }
    }

    protected override void CheckTimeSpawn()
    {
        SpawnTime -= Time.deltaTime;
        if (SpawnTime > 0) return;
        StartCoroutine(SpawnWeapon());
        SpawnTime = WeaponValue.spawnTime;
    }

    private void SetupPosition(Transform objTransform, int index)
    {
        if (Hero) objTransform.rotation = Hero.transform.rotation;
        objTransform.position = transform.position + transform.right * (index % 2 == 0 ? 0.2f : -0.2f);
    }
}