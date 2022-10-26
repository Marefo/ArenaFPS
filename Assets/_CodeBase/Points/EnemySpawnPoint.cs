using _CodeBase.EnemyCode.Data;
using UnityEngine;

namespace _CodeBase.Points
{
  public class EnemySpawnPoint : Point
  {
    [field: SerializeField] public EnemyType Type { get; private set; }
  }
}