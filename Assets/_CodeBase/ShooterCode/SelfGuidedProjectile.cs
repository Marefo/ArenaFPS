using System.Collections;
using _CodeBase.Logic;
using UnityEngine;

namespace _CodeBase.ShooterCode
{
  public class SelfGuidedProjectile : Projectile
  {
    [SerializeField] private Chaser _chaser;
    
    private int _damage;
    private float _speed;
    private ISelfGuidedProjectileTarget _currentTarget;
    private Coroutine _chaseCoroutine;

    private void OnDestroy() => 
      _currentTarget.Teleported -= OnTargetTeleport;

    public void OnShoot(ISelfGuidedProjectileTarget target, int damage, float speed)
    {
      _damage = damage;
      _speed = speed;
      
      Chase(target);
    }
    
    protected override void OnHealthDamageableZoneEnter(IHealthDamageable damageable)
    {
    }

    protected override void OnEnergyDamageableZoneEnter(IEnergyDamageable damageable)
    {
      damageable.ReceiveEnergyDamage(_damage);
      Destroy();
    }

    protected override void Destroy()
    {
      _chaser.StopChasing();
      Destroy(gameObject);
    }

    private void Chase(ISelfGuidedProjectileTarget target)
    {
      _currentTarget = target;
      target.Teleported += OnTargetTeleport;
      _chaser.Chase(target.TargetPoint, _speed);
    }

    private void OnTargetTeleport(ISelfGuidedProjectileTarget target, Vector3 positionBeforeTeleport)
    {
      target.Teleported -= OnTargetTeleport;
      _chaser.StopChasing();
      Move(positionBeforeTeleport);
    }

    private void Move(Vector3 to) => StartCoroutine(MoveCoroutine(to));

    private IEnumerator MoveCoroutine(Vector3 targetPosition)
    {
      while (true)
      {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
          Destroy();
          yield break;
        }
        else
          yield return null;
      }
    }
  }
}