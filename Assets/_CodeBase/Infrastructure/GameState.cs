using System;
using _CodeBase.EnemyCode;
using _CodeBase.HeroCode;
using _CodeBase.Services;
using UnityEngine;

namespace _CodeBase.Infrastructure
{
  public class GameState : MonoBehaviour
  {
    public event Action<int> Finished;
    
    [SerializeField] private Hero _hero;
    [SerializeField] private EnemiesMonitor _enemiesMonitor;
    [SerializeField] private TimeService _timeService;

    private void OnEnable() => _hero.Dead += OnHeroDie;
    private void OnDisable() => _hero.Dead -= OnHeroDie;

    private void Start() => _timeService.Normalize();

    private void OnHeroDie()
    {
      _timeService.Stop();
      Finished?.Invoke(_enemiesMonitor.KilledEnemies);
    }
  }
}