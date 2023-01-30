using _Project.Scripts.Descriptors;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.PlayerLogic
{
    public class PlayerMovement : MonoBehaviour
    {
        [Inject]
        private PlayerInputService _playerInputService = null!;
        [Inject]
        private PlayerDescriptor _playerDescriptor = null!;

        private Rigidbody _rigidbody = null!;
        
        private Vector3 _moveDirection;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            Move();
            RotatePlayerInMoveDirection();
        }

        private void Move()
        {
            _moveDirection = _playerInputService.MoveDirection;
            if (_moveDirection.magnitude > 1) {
                _moveDirection.Normalize();
            }
            _rigidbody.MovePosition(transform.position + _moveDirection * _playerDescriptor.MoveSpeed * Time.deltaTime);
        }

        private void RotatePlayerInMoveDirection()
        {
            if (_moveDirection == Vector3.zero) {
                return;
            }
            transform.forward = _moveDirection;
        }
    }
}
