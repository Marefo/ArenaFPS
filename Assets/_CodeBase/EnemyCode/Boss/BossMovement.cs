using System.Collections;
using _CodeBase.EnemyCode.Boss.Data;
using _CodeBase.HeroCode;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace _CodeBase.EnemyCode.Boss
{
  public class BossMovement : MonoBehaviour, IEnemyMovement
  {
    [SerializeField] private NavMeshAgent _agent;
    [Space(10)]
    [SerializeField] private BossSettings _settings;

    private Hero _hero;

    public void Initialize(Hero hero)
    {
      _hero = hero;
      StartCoroutine(KeepDistanceFromHeroCoroutine());
    }

    private IEnumerator KeepDistanceFromHeroCoroutine()
    {
      while (true)
      {
        float distance = Vector3.Distance(_hero.transform.position, transform.position);

        if (distance < _settings.DistanceFromHero)
        {
          Vector3 direction = Vector3.Normalize(transform.position - _hero.transform.position);
          Vector3 targetPosition = _hero.transform.position + direction * _settings.DistanceFromHero;
          Move(targetPosition);
        }
        
        yield return null;
      }
    }

    private void Move(Vector3 to) => _agent.SetDestination(to);
  }
}