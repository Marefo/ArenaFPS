using UnityEngine;

namespace _CodeBase.HeroCode.Data
{
  [CreateAssetMenu(fileName = "CameraRotatorSettings", menuName = "Settings/Hero/CameraRotator")]
  public class CameraRotatorSettings : ScriptableObject
  {
    public float Sensitivity;
  }
}