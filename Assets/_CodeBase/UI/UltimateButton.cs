using System;
using _CodeBase.IndicatorsCode;
using DG.Tweening;
using UnityEngine;

namespace _CodeBase.UI
{
  public class UltimateButton : MonoBehaviour
  {
    [SerializeField] private UltimateEnergy _ultimateEnergy;

    private bool _visible => transform.localScale.magnitude > 0;
    
    private void OnEnable() => _ultimateEnergy.Changed += OnEnergyValueChange;
    private void OnDisable() => _ultimateEnergy.Changed -= OnEnergyValueChange;

    private void OnEnergyValueChange()
    {
      if (_ultimateEnergy.IsMaxValue && _visible == false)
        Show();
      else if(_ultimateEnergy.IsMaxValue == false && _visible)
        Hide();
    }
    
    private void Show() => ChangeScale(1);
    private void Hide() => ChangeScale(0);

    private void ChangeScale(float targetScale)
    {
      transform.DOKill();
      transform.DOScale(Vector3.one * targetScale, 0.25f);
    }
  }
}