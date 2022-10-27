using System;
using _CodeBase.Infrastructure;
using _CodeBase.Infrastructure.Data;
using _CodeBase.Logging;
using DG.Tweening;
using TMPro;
using UnityEngine;

namespace _CodeBase.UI
{
  public class FinishScreen : Screen
  {
    [SerializeField] private GameState _gameState;
    [Space(10)] 
    [SerializeField] private TextMeshProUGUI _killsCounterField;
    [Space(10)] 
    [SerializeField] private GameStateSettings _settings;
    
    private void OnEnable() => _gameState.Finished += OnGameFinish;
    private void OnDisable() => _gameState.Finished -= OnGameFinish;

    private void Start() => HideFast();

    private void OnGameFinish(int killedEnemiesNumber)
    {
      _killsCounterField.text = $"Killed - {killedEnemiesNumber} enemies";
      DOVirtual.DelayedCall(_settings.FinishScreenShowDelay, Show).SetUpdate(true);
    }
  }
}