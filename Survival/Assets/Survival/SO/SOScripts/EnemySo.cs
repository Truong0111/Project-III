using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySo", menuName = "SO/EnemySo")]
public class EnemySo : ScriptableObject
{
    public List<EnemyValue> enemyValues;
    public List<EnemyTurn> enemyTurns;
}
[System.Serializable]
public class EnemyValue
{
    public EnemyType type;
    public int id;
    public string name;
    public float health;
    public float damage;
    public float armor;
    public float speed;
    public float experience;
    public float upgradePerTime;
    public float drop;
}
[System.Serializable]
public class EnemyTurn
{
    public int number;
    public float timeSpawn;
    public float timeExtend;
}
[System.Serializable]
public enum EnemyType
{
    Normal,
    MiniBoss,
    Boss
}