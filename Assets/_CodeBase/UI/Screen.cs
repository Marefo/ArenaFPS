using DG.Tweening;
using UnityEngine;

namespace _CodeBase.UI
{
  public class Screen : MonoBehaviour
  {
    [SerializeField] private Transform _visual;

    public void Show()
    {
      _visual.DOKill();
      _visual.DOScale(Vector3.one, 0.25f).SetUpdate(true);
    }

    public void Hide()
    {
      _visual.DOKill();
      _visual.DOScale(Vector3.zero, 0.25f).SetUpdate(true);
    }

    public void ShowFast() => _visual.localScale = Vector3.one;
    public void HideFast() => _visual.localScale = Vector3.zero;
  }
}