using System;
using UnityEngine;

namespace _Project.Scripts.PlayerLogic
{
    public class PlayerInputService : MonoBehaviour
    {
        public event Action? OnInteract;

        private void Update()
        {
            if (Input.GetKeyDown("space")) {
                OnInteract?.Invoke();
            }
        }

        public Vector3 MoveDirection
        {
            get { return new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")); }
        }
    }
}
