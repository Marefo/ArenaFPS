using System.Collections.Generic;
using _CodeBase.HeroCode;
using UnityEngine;

namespace _CodeBase.Pointers
{
  public class PointerManager : MonoBehaviour
  {
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private Camera _camera;
    [SerializeField] private PointerUI _pointerPrefab;
    
    private readonly Dictionary<WorldPointer, PointerUI> Data = new Dictionary<WorldPointer, PointerUI>();

    public void AddToList(WorldPointer worldPointer)
    {
      PointerUI newPointer = Instantiate(_pointerPrefab, transform);
      newPointer.Initialize(_shootPoint, _camera, worldPointer);
      Data.Add(worldPointer, newPointer);
    }

    public void RemoveFromList(WorldPointer botPointer)
    {
      Destroy(Data[botPointer].gameObject);
      Data.Remove(botPointer);
    }
  }
}