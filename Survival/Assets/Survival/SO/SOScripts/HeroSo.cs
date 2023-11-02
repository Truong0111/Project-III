using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HeroSo", menuName = "SO/HeroSo")]
public class HeroSo : ScriptableObject
{
    public List<HeroValue> heroValues;
}
[System.Serializable]
public class HeroValue
{
    public HeroType type;
    public int id;
    public string name;
    public float health;
    public float armor;
    public float speed;
    public float experience;
    public float upgradePerTime;
    public float level;
}
[System.Serializable]
public enum HeroType
{
    
}