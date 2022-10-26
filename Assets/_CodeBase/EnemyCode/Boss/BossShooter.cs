using System.Collections;
using _CodeBase.EnemyCode.Boss.Data;
using _CodeBase.HeroCode;
using _CodeBase.ShooterCode;
using UnityEngine;

namespace _CodeBase.EnemyCode.Boss
{
  public class BossShooter : MonoBehaviour, IEnemyDamageDealer
  {
    [SerializeField] private BossSettings _settings;
    
    private Hero _hero;
    
    public void Initialize(Hero hero)
    {
      _hero = hero;
      StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
      while (true)
      {
        Shoot();
        yield return new WaitForSeconds(_settings.ShootFrequency);
      }
    }

    private void Shoot()
    {
      SelfGuidedProjectile projectile = Instantiate(_settings.ProjectilePrefab, transform.position, Quaternion.identity);
      projectile.OnShoot(_hero, _settings.Damage, _settings.ProjectileSpeed);
    }
  }
}