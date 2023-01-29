using System;
using UnityEngine;

namespace _Project.Scripts.PlayerLogic
{
    public class PlayerInputService : MonoBehaviour
    {
        public event Action? OnInteract;
        
        public Vector3 MoveDirection => new(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        private void Update()
        {
            if (Input.GetKeyDown("space"))
                OnInteract?.Invoke();
        }
    }
}
