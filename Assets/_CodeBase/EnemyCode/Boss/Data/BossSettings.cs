using _CodeBase.ShooterCode;
using UnityEngine;

namespace _CodeBase.EnemyCode.Boss.Data
{
  [CreateAssetMenu(fileName = "BossSettings", menuName = "Settings/Enemy/Boss")]
  public class BossSettings : ScriptableObject
  {
    public float DistanceFromHero;
    [Space(10)]
    public float ShootFrequency;
    public int Damage;
    public float ProjectileSpeed;
    public SelfGuidedProjectile ProjectilePrefab;
  }
}