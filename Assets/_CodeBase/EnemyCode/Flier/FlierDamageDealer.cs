using System;
using _CodeBase.EnemyCode.Flier.Data;
using _CodeBase.HeroCode;
using _CodeBase.Logic;
using _CodeBase.ShooterCode;
using _CodeBase.ShooterCode.Data;
using UnityEngine;

namespace _CodeBase.EnemyCode.Flier
{
  public class FlierDamageDealer : MonoBehaviour
  {
    [SerializeField] private Enemy _enemy;
    [SerializeField] private TriggerListener _zone;
    [Space(10)] 
    [SerializeField] private FlierSettings _settings;
    
    private Hero _hero;

    private void OnEnable() => _zone.Entered += OnZoneEnter;
    private void OnDisable() => _zone.Entered -= OnZoneEnter;

    private void OnZoneEnter(Collider obj)
    {
      if(obj.TryGetComponent(out Hero hero) == false || hero.TryGetComponent(out IHealthDamageable damageable) == false) return;
      damageable.ReceiveHealthDamage(_settings.Damage, DamageType.Shoot);
      _enemy.Die();
    }
  }
}