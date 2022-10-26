using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _CodeBase.EnemyCode
{
  public class EnemiesMonitor : MonoBehaviour
  {
    public event Action<Enemy> EnemyDead;

    public IReadOnlyList<Enemy> Enemies => _enemies;

    private readonly List<Enemy> _enemies = new List<Enemy>();

    private void OnDestroy()
    {
      foreach (Enemy enemy in _enemies) 
        enemy.Dead -= RemoveEnemy;
    }

    public void KillAllEnemies()
    {
      List<Enemy> enemies = new List<Enemy>(_enemies);
      enemies.ForEach(enemy => enemy.Die());
    }

    public Enemy GetClosestEnemy(Vector3 to)
    {
      List<Enemy> enemies = _enemies.Where(enemy => enemy.IsDead == false).ToList();
      Enemy closest = enemies.FirstOrDefault();
      float minDistance = float.MaxValue;

      foreach (Enemy enemy in enemies)
      {
        float distance = Vector3.Distance(enemy.transform.position, to);

        if (distance > minDistance) continue;
			
        minDistance = distance;
        closest = enemy;
      }

      return closest;
    }
    
    public void AddEnemy(Enemy enemy)
    {
      _enemies.Add(enemy);
      enemy.Dead += RemoveEnemy;
    }

    private void RemoveEnemy(Enemy enemy)
    {
      enemy.Dead -= RemoveEnemy;
      EnemyDead?.Invoke(enemy);
      _enemies.Remove(enemy);
    }
  }
}