using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSo", menuName = "SO/WeaponSo")]
public class WeaponSo : ScriptableObject
{
    public List<WeaponValue> weapons;
}
[System.Serializable]
public class WeaponValue
{
    public GameObject prefab;
    
    public WeaponType weaponType;
    public WeaponMovementType weaponMovementType;
    public int id;
    public string name;
    
    public int count;
    public float spawnTime;
    
    public float damage;
    public float speed;
    public float duration;
    
}

public enum WeaponType
{
    
}

public enum WeaponMovementType
{
    Straight,
    Around,
    Round,
    Random,
    Path
}