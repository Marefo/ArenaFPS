using System;
using _CodeBase.EnemyCode;
using _CodeBase.HeroCode;
using _CodeBase.ShooterCode.Data;
using _CodeBase.UI.Data;
using DG.Tweening;
using UnityEngine;

namespace _CodeBase.UI
{
  public class HitVisualizer : MonoBehaviour
  {
    [SerializeField] private EnemiesMonitor _enemiesMonitor;
    [Space(10)]
    [SerializeField] private GameObject _visual;
    [Space(10)] 
    [SerializeField] private HitVisualizerSettings _settings;

    private Tween _hideTween;
    
    private void OnEnable() => _enemiesMonitor.EnemyDead += OnEnemyDie;
    private void OnDisable() => _enemiesMonitor.EnemyDead -= OnEnemyDie;

    private void OnEnemyDie(Enemy enemy)
    {
      if(enemy.LastDamageType == DamageType.None) return;
      Show();
    }

    private void Show()
    {
      _hideTween.Kill();
      _visual.SetActive(true);
      _hideTween = DOVirtual.DelayedCall(_settings.ShowTime, () => _visual.SetActive(false));
    }
  }
}