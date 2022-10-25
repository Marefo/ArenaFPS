using UnityEngine;

namespace _CodeBase.Hero.Data
{
  [CreateAssetMenu(fileName = "HeroMovementSettings", menuName = "Settings/HeroMovement")]
  public class HeroMovementSettings : ScriptableObject
  {
    public float MoveSpeed;
  }
}