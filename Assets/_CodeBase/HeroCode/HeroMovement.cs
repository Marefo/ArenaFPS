using System;
using _CodeBase.HeroCode.Data;
using _CodeBase.Points;
using _CodeBase.Services;
using UnityEngine;

namespace _CodeBase.HeroCode
{
  public class HeroMovement : MonoBehaviour
  {
    public event Action<Vector3> Teleported;
    
    [SerializeField] private InputService _inputService;
    [Space(10)]
    [SerializeField] private CharacterController _characterController;
    [Space(10)] 
    [SerializeField] private HeroMovementSettings _settings;

    private void Update() => Move();

    private void Move()
    {
      Vector3 rightRelativeInput = _inputService.Input.x * transform.right;
      Vector3 forwardRelativeInput = _inputService.Input.z * transform.forward;
      Vector3 direction = rightRelativeInput + forwardRelativeInput;
      direction.y = 0;
      _characterController.Move(direction * _settings.MoveSpeed * Time.deltaTime);
    }

    public void Teleport(Point point)
    {
      Teleported?.Invoke(transform.position);
      Vector3 targetPosition = point.Position;
      targetPosition.y = transform.position.y;
      transform.position = targetPosition;
    }
  }
}