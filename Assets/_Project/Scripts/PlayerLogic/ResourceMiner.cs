using _Project.Scripts.Descriptors;
using _Project.Scripts.EnvironmentResources;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.PlayerLogic
{
    public class ResourceMiner : MonoBehaviour
    {
        [Inject]
        private PlayerInputService _playerInputService = null!;
        [Inject] 
        private PlayerDescriptor _playerDescriptor = null!;
        
        private bool _isMining;
        private Resource? _currentResourceForMining;


        public void SetResourceForMining(Resource resource)
        {
            _currentResourceForMining = resource;
        }

        public void ClearResourceForMining()
        {
            _currentResourceForMining = null;
        }
        
        private void OnEnable()
        {
            _playerInputService.OnInteract += TryStartMining;
        }

        private void OnDisable()
        {
            _playerInputService.OnInteract -= TryStartMining;
        }

        private void TryStartMining()
        {
            if (_isMining || _currentResourceForMining == null)
            {
                return;
            }

            StartMining();
        }

        private void StartMining()
        {
            _isMining = true;
            // TODO Анимация
            Debug.Log("Mining hit");
            if (_currentResourceForMining.TryToDestroy(_playerDescriptor.BaseDamageToResources))
            {
                _currentResourceForMining = null;
            }
            _isMining = false;
        }
    }
}
