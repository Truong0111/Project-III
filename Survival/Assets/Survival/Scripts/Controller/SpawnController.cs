using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : Singleton<SpawnController>
{
    [SerializeField] private GameObject experiencePrefab;
    
    public void DropExperience(Enemy enemy)
    { 
        var rotation = Quaternion.Euler(Vector3.one * 45f);
        var obj = SimplePool.Spawn(experiencePrefab, enemy.transform.position, rotation);
        var experience = obj.GetComponent<Experience>();
        experience.Value = enemy.Experience;
    }
}
