using UnityEngine;

namespace _Project.Scripts.PlayerLogic
{
    public class PlayerMovement : MonoBehaviour
    {
        private Vector3 _moveDirection;
        
        // Начало временных полей. К тому же PlayerInputService висит на игроке
        private PlayerInputService _playerInputService;
        private Rigidbody _rigidbody;
        private float _moveSpeed = 3;
        // Конец временных полей

        private void Start()
        {
            _playerInputService = FindObjectOfType<PlayerInputService>();
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
            if (_moveDirection.magnitude > 1)
            {
                _moveDirection.Normalize();
            }
            _rigidbody.MovePosition(transform.position + _moveDirection * _moveSpeed * Time.deltaTime);
        }

        private void RotatePlayerInMoveDirection()
        {
            if (_moveDirection != Vector3.zero)
                transform.forward = _moveDirection;
        }
    }
}
