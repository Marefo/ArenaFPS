using System;
using System.Drawing;
using UnityEngine;

namespace _CodeBase.ShooterCode
{
  public interface ISelfGuidedProjectileTarget
  {
    event Action<ISelfGuidedProjectileTarget, Vector3> Teleported;

    Transform TargetPoint { get; }
  }
}