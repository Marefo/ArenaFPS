using System;
using System.Collections;
using _CodeBase.EnemyCode.Flier.Data;
using _CodeBase.HeroCode;
using _CodeBase.Logic;
using DG.Tweening;
using UnityEngine;

namespace _CodeBase.EnemyCode.Flier
{
  public class FlierMovement : MonoBehaviour, IEnemyMovement
  {
    [SerializeField] private Transform _model;
    [SerializeField] private Chaser _chaser;
    [Space(10)]
    [SerializeField] private FlierSettings _settings;
    
    private Hero _hero;
    private Coroutine _chaseCoroutine;
    private bool _rotateToHero;

    private void Start() => StartCoroutine(FlyUpCoroutine());

    private void Update() => RotateToHero();

    public void Initialize(Hero hero) => _hero = hero;

    private IEnumerator FlyUpCoroutine()
    {
      Vector3 targetPosition = transform.position + Vector3.up * _settings.Height;
      
      while (true)
      {
        transform.position =
          Vector3.MoveTowards(transform.position, targetPosition, _settings.FlySpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
          OnFlyUpComplete();
          yield break;
        }
        else
          yield return null;
      }
    }

    private void OnFlyUpComplete() => DOVirtual.DelayedCall(_settings.ChaseDelay, ChaseHero);

    private void ChaseHero()
    {
      _rotateToHero = true;
      _chaser.Chase(_hero.transform, _settings.ChaseSpeed);
    }

    private void RotateToHero()
    {
      if(_rotateToHero == false) return;
      
      _model.LookAt(_hero.transform);
      _model.localRotation = Quaternion.Euler(_model.localRotation.eulerAngles.x + 90, _model.localRotation.eulerAngles.y, _model.localRotation.eulerAngles.z);
    }
  }
}