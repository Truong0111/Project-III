using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSpawner : WeaponSpawner
{
    public override IEnumerator SpawnWeapon()
    {
        var weaponCount = weapons.Count;

        for (var index = 0; index < weaponCount; index++)
        {
            var spawnWeapon = weapons[index].gameObject;
            if (Hero) transform.rotation = Hero.transform.rotation;
            SetupPosition(spawnWeapon.transform, weaponCount, index);
            spawnWeapon.SetActive(true);
        }
        yield return new WaitForSeconds(0f);
    }

    private void SetupPosition(Transform objTransform, int count, int index)
    {
        var angle = 360f * index / count * Mathf.Deg2Rad;
        var range = objTransform.localScale.z / 2f;
        objTransform.position = transform.position + range * transform.forward * objTransform.localScale.z;
    }
}