using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PikeSpawner : WeaponSpawner
{
    public override IEnumerator SpawnWeapon()
    {
        if (Hero) transform.rotation = Hero.transform.rotation;
        foreach (var weapon in weapons)
        {
            var spawnWeapon = weapon.gameObject;
            SetupPosition(spawnWeapon.transform);
            spawnWeapon.SetActive(true);
            yield return new WaitForSeconds(0.3f);
        }
    }

    private void SetupPosition(Transform objTransform)
    {
        objTransform.position = transform.position - transform.forward * objTransform.localScale.z / 2f;
    }
}