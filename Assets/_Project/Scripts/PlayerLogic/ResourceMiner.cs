using _Project.Scripts.Descriptors;
using _Project.Scripts.Logger;
using _Project.Scripts.Resources;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.PlayerLogic
{
    public class ResourceMiner : MonoBehaviour
    {
        private static readonly ICustomLogger _logger = LoggerFactory.GetLogger<ResourceMiner>();
        
        [Inject]
        private PlayerInputService _playerInputService = null!;
        [Inject] 
        private PlayerDescriptor _playerDescriptor = null!;
        
        private bool _isMining;

        public Resource? CurrentResourceForMining { get; set; }

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
            if (_isMining || CurrentResourceForMining == null) {
                return;
            }

            StartMining();
        }

        private void StartMining()
        {
            _isMining = true;
            // TODO Анимация
            _logger.Debug("Mining hit");
            if (CurrentResourceForMining != null && CurrentResourceForMining.TryToDestroy(_playerDescriptor.BaseDamageToResources)) {
                CurrentResourceForMining = null;
            }
            _isMining = false;
        }
    }
}
