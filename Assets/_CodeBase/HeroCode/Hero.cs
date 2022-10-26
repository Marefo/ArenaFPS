using System;
using _CodeBase.EnemyCode;
using _CodeBase.EnemyCode.Data;
using _CodeBase.HeroCode.Data;
using _CodeBase.IndicatorsCode;
using _CodeBase.ShooterCode;
using _CodeBase.ShooterCode.Data;
using UnityEngine;

namespace _CodeBase.HeroCode
{
  public class Hero : MonoBehaviour, IEnergyDamageable, IHealthDamageable, ISelfGuidedProjectileTarget
  {
    public event Action<ISelfGuidedProjectileTarget, Vector3> Teleported;

    public Transform TargetPoint => transform;
    
    [SerializeField] private EnemiesMonitor _enemiesMonitor;
    [Space(10)] 
    [SerializeField] private Health _health;
    [SerializeField] private UltimateEnergy _ultimateEnergy;
    [SerializeField] private HeroMovement _movement;
    [Space(10)] 
    [SerializeField] private EnemiesData _enemiesData;
    [SerializeField] private RicochetKillAwardsData _ricochetKillAwardsData;

    private void OnEnable()
    {
      _movement.Teleported += OnTeleport;
      _enemiesMonitor.EnemyDead += OnEnemyDie;
    }

    private void OnDisable()
    {
      _movement.Teleported -= OnTeleport;
      _enemiesMonitor.EnemyDead -= OnEnemyDie;
    }

    public void ReceiveHealthDamage(int damage, DamageType damageType) => _health.Decrease(damage);

    public void ReceiveEnergyDamage(int damage) => _ultimateEnergy.Decrease(damage);

    private void OnEnemyDie(Enemy enemy)
    {
      if (enemy.LastDamageType == DamageType.Shoot)
        ReceiveDefaultKillAward(enemy);
      else if (enemy.LastDamageType == DamageType.Ricochet) 
        ReceiveRicochetKillAward();
    }

    private void OnTeleport(Vector3 positionBeforeTeleport) => 
      Teleported?.Invoke(this, positionBeforeTeleport);

    private void ReceiveDefaultKillAward(Enemy enemy)
    {
      int energyAward = _enemiesData.GetEnergyAward(enemy.Type);
      _ultimateEnergy.Increase(energyAward);
    }

    private void ReceiveRicochetKillAward()
    {
      RicochetKillAward award = _ricochetKillAwardsData.GetRandomAward();

      if (award.Type == AwardType.Health)
        _health.Increase(award.Value);
      else if (award.Type == AwardType.UltimateEnergy)
        _ultimateEnergy.Increase(award.Value);
    }
  }
}