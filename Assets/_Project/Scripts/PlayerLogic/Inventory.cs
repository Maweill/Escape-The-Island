using _Project.Scripts.Descriptors.Resources;
using _Project.Scripts.Resources;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.PlayerLogic
{
    public class Inventory : MonoBehaviour
    {
        [Inject]
        private ItemDescriptorCollection _itemDescriptorCollection = null!;

        private InventoryModel _inventoryModel = null!;

        private void Awake()
        {
            _inventoryModel = new InventoryModel();
        }

        public bool TryCollectItem(Item item)
        {
            // TODO Проверка на свободное место в инвентаре
            _inventoryModel.AddItem(_itemDescriptorCollection.GetDescriptor(item.Type), item.Quantity);
            return true;
        }
    }
}