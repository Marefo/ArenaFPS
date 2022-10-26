using _CodeBase.Logic;
using _CodeBase.ShooterCode;
using UnityEngine;

namespace _CodeBase.HeroCode.Data
{
  [CreateAssetMenu(fileName = "HeroShooterSettings", menuName = "Settings/HeroShooter")]
  public class HeroShooterSettings : ScriptableObject
  {
    public float Delay;
    public int Damage;
    public float ShootDistance;
    public float ProjectileSpeed;
    [Space(10)] 
    public int MaxRicochetTimes;
    public int HealthValueForGuaranteedRicochet;
    [Range(0, 100)] public float MinRicochetPercent;
    [Space(10)]
    public HeroBullet ProjectilePrefab;
  }
}