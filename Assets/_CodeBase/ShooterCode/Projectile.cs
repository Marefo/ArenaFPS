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
  public abstract class Projectile : MonoBehaviour
  {
    [SerializeField] private LayerMask _destroyerLayer;
    [Space(10)]
    [SerializeField] private TriggerListener _zone;

    private void OnEnable() => _zone.Entered += OnZoneEnter;
    private void OnDisable() => _zone.Entered -= OnZoneEnter;

    private void OnZoneEnter(Collider obj)
    {
      if (obj.gameObject.TryGetComponent(out IHealthDamageable damageable))
        OnHealthDamageableZoneEnter(damageable);

      if (obj.gameObject.TryGetComponent(out IEnergyDamageable energyDamageable))
        OnEnergyDamageableZoneEnter(energyDamageable);
      
      if (Helpers.CompareLayers(obj.gameObject.layer, _destroyerLayer))
        OnDestroyerZoneEnter();
    }

    protected abstract void OnHealthDamageableZoneEnter(IHealthDamageable damageable);
    protected abstract void OnEnergyDamageableZoneEnter(IEnergyDamageable damageable);

    protected virtual void OnDestroyerZoneEnter() => Destroy();

    protected abstract void Destroy();
  }
}