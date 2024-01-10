using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnController : Singleton<EnemySpawnController>
{
    [SerializeField] private VoidEvent startGameEvent;
    [SerializeField] private VoidEvent stopGameEvent;
    [SerializeField] private VoidEvent pauseGameEvent;
    [SerializeField] private VoidEvent continueGameEvent;
    [SerializeField] private EnemySo enemySo;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float range = 15f;
    private Transform _heroTransform;
    
    private static float ScreenWidth => Screen.width;
    private static float ScreenHeight => Screen.height;

    private bool CanSpawn { get; set; }
    private void Awake()
    {
        startGameEvent.Register(Init);
        stopGameEvent.Register(StopSpawnEnemy);
        pauseGameEvent.Register(StopSpawnEnemy);
        continueGameEvent.Register(ContinueSpawnEnemy);
    }

    public void OnDisable()
    {
        startGameEvent.Unregister(Init);
        stopGameEvent.Unregister(StopSpawnEnemy);
        pauseGameEvent.Unregister(StopSpawnEnemy);
        continueGameEvent.Unregister(ContinueSpawnEnemy);
    }

    private IEnumerator Start()
    {
        yield return new WaitUntil(() => GameController.Instance.Hero != null);
        var hero = GameController.Instance.Hero;
        _heroTransform = hero.transform;
        startGameEvent.Raise();
    }

    private void Init()
    {
        StartCoroutine(SpawnEnemy());
    }

    private void StopSpawnEnemy()
    {
        CanSpawn = false;
        StopCoroutine(SpawnEnemy());
    }
    
    private void ContinueSpawnEnemy()
    {
        CanSpawn = true;
        StartCoroutine(SpawnEnemy());
    }
    
    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            if (!CanSpawn) break;
            if(!_heroTransform) yield break;
            var spawnPos = RandomOnUnitCircle(range);

            yield return new WaitForSeconds(2f);
            var spawnPosition = _heroTransform.position + new Vector3(spawnPos.x, 0f, spawnPos.y);
            var spawnRotation = Quaternion.identity;
            var enemySpawn = SimplePool.Spawn(enemyPrefab, spawnPosition, spawnRotation);
            enemySpawn.SetActive(true);
        }
    }

    private static Vector2 RandomOnUnitCircle(float radius)
    {
        var randomAngle = Random.Range(0f, 360f);

        var radians = Mathf.Deg2Rad * randomAngle;

        var x = radius * Mathf.Cos(radians);
        var y = radius * Mathf.Sin(radians);

        var randomPoint = new Vector2(x, y);
        return randomPoint;
    }
}