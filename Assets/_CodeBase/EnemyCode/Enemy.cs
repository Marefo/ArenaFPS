using System;
using _CodeBase.EnemyCode.Data;
using _CodeBase.HeroCode;
using _CodeBase.IndicatorsCode;
using _CodeBase.Logic;
using _CodeBase.Pointers;
using _CodeBase.ShooterCode;
using _CodeBase.ShooterCode.Data;
using UnityEngine;

namespace _CodeBase.EnemyCode
{
  public class Enemy : MonoBehaviour, IHealthDamageable
  {
    public event Action<Enemy> Dead;

    public EnemyType Type { get; private set; }
    public DamageType LastDamageType { get; private set; } = DamageType.None;
    public bool IsDead { get; private set; }

    [SerializeField] private Health _health;
    [SerializeField] private WorldPointer _pointer;

    private IEnemyMovement _movement;
    private IEnemyDamageDealer _damageDealer;

    private void Awake()
    {
      _movement = GetComponent<IEnemyMovement>();
      _damageDealer = GetComponent<IEnemyDamageDealer>();
    }

    private void OnEnable() => _health.ValueCameToZero += Die;
    private void OnDisable() => _health.ValueCameToZero -= Die;

    public void Initialize(EnemyType enemyType, Hero hero, PointerManager pointerManager)
    {
      Type = enemyType;
      _movement?.Initialize(hero);
      _damageDealer?.Initialize(hero);
      _pointer.Initialize(pointerManager);
    }

    public void Die()
    {
      if(IsDead) return;
      IsDead = true;
      _pointer.OnDie();
      Dead?.Invoke(this);
      gameObject.SetActive(false);
    }

    public void ReceiveHealthDamage(int damage, DamageType damageType)
    {
      LastDamageType = damageType;
      _health.Decrease(damage);
    }
  }
}