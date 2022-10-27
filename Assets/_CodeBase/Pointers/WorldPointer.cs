using UnityEngine;

namespace _CodeBase.Pointers
{
  public class WorldPointer : MonoBehaviour
  {
    private PointerManager _pointerManager;

    public void Initialize(PointerManager pointerManager)
    {
      _pointerManager = pointerManager;
      _pointerManager.AddToList(this);
    }

    public void OnDie() => _pointerManager.RemoveFromList(this);
  }
}