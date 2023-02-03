using _Project.Scripts.Resources;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.PlayerLogic
{
    [RequireComponent(typeof(Inventory))]
    public class ItemCollector : MonoBehaviour
    {
        [Inject]
        private PlayerInputService _playerInputService = null!;

        private Inventory _inventory = null!;
        private bool _isCollecting;

        public Item? CurrentItemForCollecting { get; set; }

        private void Awake()
        {
            _inventory = GetComponent<Inventory>();
        }

        private void OnEnable()
        {
            _playerInputService.OnInteract += TryStartCollecting;
        }

        private void OnDisable()
        {
            _playerInputService.OnInteract -= TryStartCollecting;
        }

        private void TryStartCollecting()
        {
            if (_isCollecting || CurrentItemForCollecting == null)
            {
                return;
            }

            if (_inventory.TryCollectItem(CurrentItemForCollecting))
            {
                StartCollecting();
            }
        }

        private void StartCollecting()
        {
            _isCollecting = true;
            // TODO Анимация
            Debug.Log($"Collect item. name={CurrentItemForCollecting?.name}");
            CurrentItemForCollecting.Collect();
            _isCollecting = false;
        }
    }
}