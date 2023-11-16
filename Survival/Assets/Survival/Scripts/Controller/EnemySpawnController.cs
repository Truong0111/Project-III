using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnController : Singleton<EnemySpawnController>
{
    [SerializeField] private EnemySo enemySo;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float range = 15f;
    private Transform _hero;
    
    private static float ScreenWidth => Screen.width;
    private static float ScreenHeight => Screen.height;

    private void Start()
    {
        var hero = FindFirstObjectByType<Hero>();
        if (hero == null)
        {
            enabled = false;
            return;
        }

        _hero = hero.transform;
        
        StartCoroutine(SpawnEnemy());
    }

    [Button]
    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if(!_hero) yield break;
            var spawnPos = RandomOnUnitCircle(range);

            yield return new WaitForSeconds(2f);
            var spawnPosition = _hero.position + new Vector3(spawnPos.x, 0f, spawnPos.y);
            var spawnRotation = Quaternion.identity;
            var enemySpawn = SimplePool.Spawn(enemyPrefab, spawnPosition, spawnRotation);
            enemySpawn.SetActive(true);
        }
    }
    
    public Vector2 RandomOnUnitCircle(float radius)
    {
        var randomAngle = Random.Range(0f, 360f);

        var radians = Mathf.Deg2Rad * randomAngle;

        var x = radius * Mathf.Cos(radians);
        var y = radius * Mathf.Sin(radians);

        var randomPoint = new Vector2(x, y);
        return randomPoint;
    }
}