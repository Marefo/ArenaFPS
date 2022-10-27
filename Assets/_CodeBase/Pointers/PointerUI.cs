
using System.Collections;
using _CodeBase.HeroCode;
using _CodeBase.Logging;
using UnityEngine;
using UnityEngine.UI;

namespace _CodeBase.Pointers
{
  public class PointerUI : MonoBehaviour
  {
    [SerializeField] private Image _image;

    private Camera _camera;
    private WorldPointer _worldPointer;
    private Transform _shootPoint;
    private bool _isShown;

    private void LateUpdate()
    {
      if(_worldPointer == null) return;
      
      Plane[] planes = GeometryUtility.CalculateFrustumPlanes(_camera);

      Vector3 toEnemy = _worldPointer.transform.position - _shootPoint.position;
      Ray ray = new Ray(_shootPoint.position, toEnemy);
      Debug.DrawRay(_shootPoint.position, toEnemy);
      
      float rayMinDistance = Mathf.Infinity;
      int index = 0;

      for (int p = 0; p < 4; p++)
      {
        if (planes[p].Raycast(ray, out float distance))
        {
          if (distance < rayMinDistance)
          {
            rayMinDistance = distance;
            index = p;
          }
        }
      }

      rayMinDistance = Mathf.Clamp(rayMinDistance, 0, toEnemy.magnitude);
      Vector3 worldPosition = ray.GetPoint(rayMinDistance);
      Vector3 position = _camera.WorldToScreenPoint(worldPosition);
      Quaternion rotation = GetIconRotation(index);

      if (toEnemy.magnitude > rayMinDistance)
        Show();
      else
        Hide();

      SetIconPosition(position, rotation);
    }

    public void Initialize(Transform shootPoint, Camera mainCamera, WorldPointer botPointer)
    {
      _shootPoint = shootPoint;
      _worldPointer = botPointer;
      _camera = mainCamera;
      HideFast();
    }

    private Quaternion GetIconRotation(int planeIndex)
    {
      if (planeIndex == 0)
        return Quaternion.Euler(0f, 0f, 90f);
      else if (planeIndex == 1)
        return Quaternion.Euler(0f, 0f, -90f);
      else if (planeIndex == 2)
        return Quaternion.Euler(0f, 0f, 180);
      else if (planeIndex == 3)
        return Quaternion.Euler(0f, 0f, 0f);

      return Quaternion.identity;
    }

    private void SetIconPosition(Vector3 position, Quaternion rotation)
    {
      transform.position = position;
      transform.rotation = rotation;
    }

    private void Show()
    {
      if (_isShown) return;
      _isShown = true;
      StopAllCoroutines();
      StartCoroutine(ShowProcess());
    }

    private void Hide()
    {
      if (!_isShown) return;
      _isShown = false;

      StopAllCoroutines();
      StartCoroutine(HideProcess());
    }

    private void HideFast()
    {
      _isShown = false;
      StopAllCoroutines();
      transform.localScale = Vector3.zero;
      _image.enabled = false;
    }

    private IEnumerator ShowProcess()
    {
      transform.localScale = Vector3.zero;
      _image.enabled = true;
      
      for (float t = 0; t < 1f; t += Time.deltaTime * 6f)
      {
        transform.localScale = Vector3.one * t;
        yield return null;
      }

      transform.localScale = Vector3.one;
    }

    private IEnumerator HideProcess()
    {
      for (float t = 0; t < 1f; t += Time.deltaTime * 6f)
      {
        transform.localScale = Vector3.one * (1f - t);
        yield return null;
      }

      _image.enabled = false;
    }
  }
}