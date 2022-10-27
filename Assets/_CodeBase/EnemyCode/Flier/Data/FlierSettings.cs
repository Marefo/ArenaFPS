using UnityEngine;

namespace _CodeBase.EnemyCode.Flier.Data
{
  [CreateAssetMenu(fileName = "FlierSettings", menuName = "Settings/Enemy/Flier")]
  public class FlierSettings : ScriptableObject
  {
    public float Height;
    public float FlySpeed;
    public float ChaseDelay;
    public float ChaseSpeed;
    public int Damage;
  }
}