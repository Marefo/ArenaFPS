using System;
using System.Collections;
using _CodeBase.EnemyCode.Data;
using _CodeBase.HeroCode;
using _CodeBase.Logging;
using _CodeBase.Points;
using UnityEngine;

namespace _CodeBase.EnemyCode
{
  public class EnemySpawner : MonoBehaviour
  {
    [SerializeField] private AnimationCurve _difficultyCurve;
    [Space(10)]
    [SerializeField] private Hero _hero;
    [Space(10)]
    [SerializeField] private EnemiesSpawnPointsStorage _spawnPointsStorage;
    [SerializeField] private EnemiesMonitor _monitor;
    [Space(10)] 
    [SerializeField] private SpawnerSettings _settings;
    [SerializeField] private EnemiesData _prefabsData;

    private int _spawnedFliers;

    private void Start()
    {
      InitializeDifficultyCurve();
      StartCoroutine(SpawnCoroutine());
    }

    private void InitializeDifficultyCurve()
    {
      _difficultyCurve.MoveKey(0, new Keyframe(0, _settings.StartDelay));
      _difficultyCurve.MoveKey(1, new Keyframe(_settings.MinDelayApplyTime, _settings.MinDelay));
    }

    private IEnumerator SpawnCoroutine()
    {
      while (true)
      {
        EnemySpawnPoint spawnPoint = null;
        
        if (_spawnedFliers == _settings.FliersPerBoss)
        {
          _spawnedFliers = 0;
          spawnPoint = _spawnPointsStorage.GetPoint(EnemyType.Boss);
        }
        else
        {
          _spawnedFliers += 1;
          spawnPoint = _spawnPointsStorage.GetPoint(EnemyType.Flier);
        }
        
        SpawnEnemy(spawnPoint);

        float delay = _difficultyCurve.Evaluate(Time.timeSinceLevelLoad);
        yield return new WaitForSeconds(delay);
      }
    }

    private void SpawnEnemy(EnemySpawnPoint spawnPoint)
    {
      GameObject prefab = _prefabsData.GetPrefab(spawnPoint.Type);
      Enemy enemy = Instantiate(prefab, spawnPoint.transform).GetComponent<Enemy>();
      enemy.transform.localPosition = Vector3.zero;
      enemy.Initialize(spawnPoint.Type, _hero);
      _monitor.AddEnemy(enemy);
    }
  }
}