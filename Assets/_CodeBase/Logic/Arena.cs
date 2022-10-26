using System;
using _CodeBase.EnemyCode;
using _CodeBase.HeroCode;
using _CodeBase.Logging;
using _CodeBase.Points;
using UnityEngine;

namespace _CodeBase.Logic
{
  public class Arena : MonoBehaviour
  {
    [SerializeField] private EnemiesMonitor _enemiesMonitor;
    [Space(10)] 
    [SerializeField] private TriggerListener _zone;
    [SerializeField] private DefaultPointsStorage _pointsStorage;

    private void OnEnable() => _zone.Canceled += OnZoneCancel;
    private void OnDisable() => _zone.Canceled -= OnZoneCancel;

    private void OnZoneCancel(Collider obj)
    {
      if(obj.TryGetComponent(out HeroMovement heroMovement) == false) return;
      Point safestPoint = GetSafestPoint();
      heroMovement.Teleport(safestPoint);
    }

    private Point GetSafestPoint()
    {
      float minDistanceToEnemy = float.MinValue;
      Point safestPoint = _pointsStorage.GetPoint();
      
      foreach (Point point in _pointsStorage.Points)
      {
        float minDistance = float.MaxValue;

        foreach (Enemy enemy in _enemiesMonitor.Enemies)
        {
          float distance = Vector3.Distance(point.Position, enemy.transform.position);

          if (distance < minDistance)
            minDistance = distance;
        }

        if (minDistanceToEnemy < minDistance)
        {
          minDistanceToEnemy = minDistance;
          safestPoint = point;
        }
      }

      return safestPoint;
    }
  }
}