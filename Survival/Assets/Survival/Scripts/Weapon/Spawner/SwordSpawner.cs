using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSpawner : WeaponSpawner
{
    
    public override IEnumerator SpawnWeapon()
    {
        yield return new WaitUntil(() => Hero);
        var weaponCount = weapons.Count;

        for (var index = 0; index < weaponCount; index++)
        {
            var spawnWeapon = weapons[index].gameObject;
            if (Hero) transform.rotation = Hero.transform.rotation;
            spawnWeapon.SetActive(true);
            SetupPosition(spawnWeapon.transform, weaponCount, index);
        }
        yield return new WaitForSeconds(0f);
    }

    private void SetupPosition(Transform objTransform, int count, int index)
    {
        var range = objTransform.localScale.z / 2f;
        objTransform.position = transform.position + transform.forward * (range * objTransform.localScale.z);
        objTransform.rotation = transform.rotation;
    }
}