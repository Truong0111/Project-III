using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "WeaponSo", menuName = "SO/WeaponSo")]
public class WeaponSo : ScriptableObject
{
    public GameObject checkEnemyInRange;
    [FormerlySerializedAs("weapons")] public List<WeaponValue> weaponValues;
}
[System.Serializable]
public class WeaponValue
{
    public GameObject prefab;

    public int id;
    public WeaponType weaponType;
    public string name;
    
    public int level;
    
    public int count;
    public float spawnTime;
    
    public float damage;
    public float speed;
    public float duration;

}

[EnumToggleButtons]
public enum WeaponType
{
    MagicBall,
    Gun,
    Shuriken,
    Pike,
    Sword,
    EnergyBlast
}