using _CodeBase.Hero.Data;
using _CodeBase.Hero.Infrastructure;
using _CodeBase.Services;
using UnityEngine;
using UnityEngine.InputSystem.Controls;

namespace _CodeBase.Hero
{
  public class HeroCameraRotator : MonoBehaviour
  {
    [SerializeField] private InputService _inputService;
    [Space(10)]
    [SerializeField] private Transform _camera;
    [Space(10)] 
    [SerializeField] private CameraRotatorSettings _settings;

    private float _cameraPitch;

    private void Update()
    {
      Vector2? handledInput = HandleInput();
      
      if(handledInput != null)
        Look(handledInput.Value);
    }

    private Vector2? HandleInput()
    {
      Vector2? lookInput = null;
      
      if(_inputService.Touchscreen == null || _inputService.Touchscreen.touches.Count == 0) return null;

      foreach (TouchControl touch in _inputService.Touchscreen.touches)
      {
        if (Helpers.IsPointOverUIObject(touch.startPosition.ReadValue()) == false)
        {
          Vector2 touchDeltaPosition = touch.delta.ReadValue();
          lookInput = touchDeltaPosition * _settings.Sensitivity * Time.deltaTime;
          break;
        }
        else
          continue;
      }

      return lookInput;
    }
    
    private void Look(Vector2 lookInput)
    {
      _cameraPitch = Mathf.Clamp(_cameraPitch - lookInput.y, -90f, 90f);
      _camera.localRotation = Quaternion.Euler(_cameraPitch, 0, 0);
      transform.Rotate(transform.up, lookInput.x);
    }
  }
}