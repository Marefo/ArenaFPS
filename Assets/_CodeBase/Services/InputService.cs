using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _CodeBase.Services
{
  public class InputService : MonoBehaviour
  {
    public Touchscreen Touchscreen => Touchscreen.current;
    public Vector3 Input => GetInput();

    [SerializeField] private Joystick _joystick;

    private InputActions _inputActions;
    private Vector3? _pcInput;

    private void Awake() => _inputActions = new InputActions();

    private void OnEnable() => _inputActions.Enable();
    private void OnDisable() => _inputActions.Disable();

    private void Update()
    {
      #if UNITY_EDITOR
        Vector2 pcInput = _inputActions.Game.Movement.ReadValue<Vector2>();
        _pcInput = new Vector3(pcInput.x, 0, pcInput.y);
      #endif
    }

    private Vector3 GetInput()
    {
      if (_pcInput != null)
        return _pcInput.Value;
      else
        return new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);
    }
  }
}