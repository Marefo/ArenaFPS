using System;
using UnityEngine;

namespace _CodeBase.IndicatorsCode
{
  public abstract class Indicator : MonoBehaviour
  {
    public event Action<int> Changed;
    
    public int CurrentValue { get; private set; }

    [SerializeField] private IndicatorSettings _settings;

    private int _maxValue;
    
    private void Start() => Initialize();

    public void Increase(int value) => ChangeValue(Mathf.Abs(value));
    public void Decrease(int value) => ChangeValue(-Mathf.Abs(value));

    private void ChangeValue(int value)
    {
      CurrentValue = Mathf.Clamp(CurrentValue + value, 0, _maxValue);
      Changed?.Invoke(CurrentValue);
    }

    private void Initialize()
    {
      _maxValue = _settings.MaxValue;
      CurrentValue = _settings.StartValue;
    }
  }
}