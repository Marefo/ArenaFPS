using UnityEngine;

namespace _CodeBase.HeroCode.Data
{
  [CreateAssetMenu(fileName = "HeroMovementSettings", menuName = "Settings/Hero/HeroMovement")]
  public class HeroMovementSettings : ScriptableObject
  {
    public float MoveSpeed;
  }
}