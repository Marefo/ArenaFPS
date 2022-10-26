using System;
using _CodeBase.IndicatorsCode;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _CodeBase.UI
{
  public class IndicatorVisualizer : MonoBehaviour
  {
    [SerializeField] private Indicator _indicator;
    [Space(10)] 
    [SerializeField] private Image _fill;
    [SerializeField] private TextMeshProUGUI _textField;

    private void OnEnable() => _indicator.Changed += OnChange;
    private void OnDisable() => _indicator.Changed -= OnChange;

    private void OnChange()
    {
      _textField.text = $"{_indicator.CurrentValue}/{_indicator.MaxValue}";
      float percent = Mathf.InverseLerp(0, _indicator.MaxValue, _indicator.CurrentValue);
      _fill.DOKill();
      _fill.DOFillAmount(percent, 0.25f);
    }
  }
}