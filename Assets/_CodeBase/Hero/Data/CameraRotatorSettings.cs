using UnityEngine;

namespace _CodeBase.Hero.Data
{
  [CreateAssetMenu(fileName = "CameraRotatorSettings", menuName = "Settings/CameraRotator")]
  public class CameraRotatorSettings : ScriptableObject
  {
    public float Sensitivity;
  }
}