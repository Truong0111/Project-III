using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSo", menuName = "SO/WeaponSo")]
public class WeaponSo : ScriptableObject
{
    public GameObject checkEnemyInRange;
    public List<WeaponValue> weapons;
}
[System.Serializable]
public class WeaponValue
{
    public GameObject prefab;
    
    public WeaponType weaponType;
    public string name;
    
    public int count;
    public float spawnTime;
    
    public float damage;
    public float speed;
    public float duration;
    
}

public enum WeaponType
{
    MagicBall,
    Gun,
    Shuriken,
    Pike,
    Sword,
    EnergyBlast
}