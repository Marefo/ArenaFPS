using System.Collections;
using _CodeBase.EnemyCode;
using _CodeBase.HeroCode;
using _CodeBase.HeroCode.Data;
using _CodeBase.Infrastructure;
using _CodeBase.Logic;
using _CodeBase.ShooterCode.Data;
using UnityEngine;

namespace _CodeBase.ShooterCode
{
  public class HeroBullet : Projectile
  {
    private Vector3 _startPosition;
    private Vector3 _direction;
    private IRicochetChanceCalculator _ricochetChanceCalculator;
    private EnemiesMonitor _enemiesMonitor;
    private HeroShooterSettings _settings;
    private Coroutine _moveCoroutine;
    private int _ricochetTimes;

    public void OnShoot(Vector3 direction, IRicochetChanceCalculator ricochetChanceCalculator, EnemiesMonitor enemiesMonitor, HeroShooterSettings settings)
    {
      _startPosition = transform.position;
      _direction = direction;
      _ricochetChanceCalculator = ricochetChanceCalculator;
      _enemiesMonitor = enemiesMonitor;
      _settings = settings;
      StartMovement();
    }

    protected override void OnEnergyDamageableZoneEnter(IEnergyDamageable damageable)
    {
    }
    
    protected override void OnHealthDamageableZoneEnter(IHealthDamageable damageable)
    {
      StopMovement();

      DamageType damageType = _ricochetTimes == 0 ? DamageType.Shoot : DamageType.Ricochet;
      damageable.ReceiveHealthDamage(_settings.Damage, damageType);
      float ricochetChance = _ricochetChanceCalculator.GetRicochetChance();
      bool isChanceWorked = Helpers.IsChanceWorked(ricochetChance);
      Enemy closestEnemy = _enemiesMonitor.GetClosestEnemy(transform.position);

      if (_ricochetTimes < _settings.MaxRicochetTimes && isChanceWorked && closestEnemy != null)
        Ricochet(closestEnemy);
      else
        Destroy();
    }

    private void Ricochet(Enemy closestEnemy)
    {
      _ricochetTimes += 1;
      _startPosition = transform.position;
      _direction = Vector3.Normalize(closestEnemy.transform.position - transform.position);
      StartMovement();
    }

    private void StartMovement() => 
      _moveCoroutine = StartCoroutine(MoveCoroutine());

    private IEnumerator MoveCoroutine()
    {
      while (true)
      {
        transform.position += _direction * _settings.ProjectileSpeed * Time.deltaTime;
        float reachedDistance = Vector3.Distance(_startPosition, transform.position);

        if (reachedDistance >= _settings.ShootDistance)
        {
          Destroy();
          yield break;
        }
        else
          yield return null;
      } 
    }

    private void StopMovement()
    {
      if(_moveCoroutine == null) return;
      StopCoroutine(_moveCoroutine);
    }

    protected override void Destroy()
    {
      StopMovement();
      Destroy(gameObject);
    }
  }
}