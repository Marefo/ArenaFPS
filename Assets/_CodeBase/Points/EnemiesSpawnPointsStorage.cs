using System.Linq;
using _CodeBase.EnemyCode.Data;
using _CodeBase.Extensions;

namespace _CodeBase.Points
{
  public class EnemiesSpawnPointsStorage : PointsStorage<EnemySpawnPoint>
  {
    public EnemySpawnPoint GetPoint(EnemyType type) => Points.Where(point => point.Type == type).ToList().GetRandomValue();
  }
}