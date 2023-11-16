using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBallSpawner : WeaponSpawner
{
    [SerializeField] private float radius = 3f;
    
    public override IEnumerator SpawnWeapon()
    {
        var weaponCount = weapons.Count;
        
        for (var index = 0; index < weaponCount; index++)
        {
            var spawnWeapon = weapons[index].gameObject;
            SetupPosition(spawnWeapon.transform, weaponCount, index);
            spawnWeapon.SetActive(true);
        }
        yield return new WaitForSeconds(0f);
    }

    private void SetupPosition(Transform objTransform, int count, int index)
    {
        var angle = 360f * index / count * Mathf.Deg2Rad;
        objTransform.position = transform.position;
        objTransform.localPosition
            += (Vector3.right * Mathf.Cos(angle) + Vector3.forward * Mathf.Sin(angle)).normalized * radius;
    }
    
}
