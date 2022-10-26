using _CodeBase.EnemyCode;
using _CodeBase.HeroCode.Data;
using _CodeBase.IndicatorsCode;
using _CodeBase.Logic;
using _CodeBase.ShooterCode;
using UnityEngine;

namespace _CodeBase.HeroCode
{
  public class HeroShooter : MonoBehaviour, IRicochetChanceCalculator
  {
    [SerializeField] private EnemiesMonitor _enemiesMonitor;
    [Space(10)] 
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Health _health;
    [Space(10)] 
    [SerializeField] private HeroShooterSettings _settings;

    private float? _lastShootTime;
    
    public float GetRicochetChance()
    {
      float percent = Mathf.InverseLerp(_health.MaxValue, _settings.HealthValueForGuaranteedRicochet,
        _health.CurrentValue);

      return Mathf.Lerp(_settings.MinRicochetPercent, 100, percent);
    }

    public void TryShoot()
    {
      if (_lastShootTime == null || Time.time > _lastShootTime.Value + _settings.Delay) 
        Shoot();
    }

    private void Shoot()
    {
      HeroBullet projectile = Instantiate(_settings.ProjectilePrefab, _shootPoint.position, Quaternion.identity);
      projectile.OnShoot(_camera.forward, this, _enemiesMonitor, _settings);
    }
  }
}