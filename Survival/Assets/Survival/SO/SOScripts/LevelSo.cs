using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "LevelSo", menuName = "SO/LevelSo")]
public class LevelSo : ScriptableObject
{
    public List<HeroExperiencePerLevel> heroExperiencePerLevels;
    public List<EnemyExperiencePerLevelDrop> enemyExperiencePerLevels;

    [Button]
    private void CreateExpHero()
    {
        heroExperiencePerLevels = new List<HeroExperiencePerLevel>();
        for (var i = 0; i < 200; i++)
        {
            var experience = i == 0 ? 0 : heroExperiencePerLevels[i - 1].experience + i * 40f;
            var expPerLevel = new HeroExperiencePerLevel
            {
                level = i,
                experience = experience
            };
            heroExperiencePerLevels.Add(expPerLevel);
        }
    }
    
    [Button]
    private void CreateExpEnemy()
    {
        enemyExperiencePerLevels = new List<EnemyExperiencePerLevelDrop>();
        for (var i = 0; i < 31; i++)
        {
            var experience = i == 0 ? 0 : enemyExperiencePerLevels[i - 1].experience + 10f;
            var expPerLevel = new EnemyExperiencePerLevelDrop
            {
                level = i,
                experience = experience
            };
            enemyExperiencePerLevels.Add(expPerLevel);
        }
    }
}

[Serializable]
public class HeroExperiencePerLevel
{
    public int level;
    public float experience;
}

[Serializable]
public class EnemyExperiencePerLevelDrop
{
    public int level;
    public float experience;
}
