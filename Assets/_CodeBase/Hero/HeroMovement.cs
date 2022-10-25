using System;
using _CodeBase.Hero.Data;
using _CodeBase.Hero.Infrastructure;
using _CodeBase.Logging;
using _CodeBase.Services;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _CodeBase.Hero
{
  public class HeroMovement : MonoBehaviour
  {
    [SerializeField] private InputService _inputService;
    [Space(10)]
    [SerializeField] private Transform _camera;
    [SerializeField] private CharacterController _characterController;
    [Space(10)] 
    [SerializeField] private HeroMovementSettings _settings;

    private void Update() => Move();

    private void Move()
    {
      Vector3 rightRelativeInput = _inputService.Input.x * transform.right;
      Vector3 forwardRelativeInput = _inputService.Input.z * transform.forward;
      Vector3 direction = rightRelativeInput + forwardRelativeInput;
      _characterController.Move(direction * _settings.MoveSpeed * Time.deltaTime);
    }
  }
}